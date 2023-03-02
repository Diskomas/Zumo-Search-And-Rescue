#pragma once
#include <Wire.h>

// calculates the amount of turns made to figure out when
// Zumo reaches the starting point
int finishValid = 0;

// --------- Edit Speed Here ----------
const uint16_t mode3Speed = 150;

const uint16_t mode1Speed = 50;
// --------- Edit Speed Here ----------


// does not require any adjustments
const uint16_t leftSpeed = mode3Speed;
const uint16_t mode1LeftSpeed = mode1Speed;
const uint16_t turnSpeed = mode3Speed;
const uint16_t calibrationSpeed = 200;

// compensate for slower right wheel
const uint16_t mode1RightSpeed = (int)mode1LeftSpeed*1.25;
const uint16_t RightSpeed = (int)leftSpeed*1.25;

// drift of a single side motor for finding a line
const uint16_t correctionWheelSpeed = (int)(leftSpeed/1.8);

// adjustable speed for setting drive speeds in different conditions 
int16_t leftMotorSpeed = 0;
int16_t rightMotorSpeed = 0;

// line sensor thresholds 
const uint16_t sensorMinThreshold = 60;
const uint16_t sensorMaxThreshold = 100;

// duratio equal of drive time of the Zumo lenght
// value should be adjusted based on the battery level
// settings for fully charged battery:
int beforeTurnDuration = 400;
int restBeforeTurnDuration = 400;

// check if zumo drove without a line for long enough
// to know it has an option to turn left
int ducarionAtJunction = 70;
int restDucarionAtJunction = 70;

// for driving in the middle of the room for scanning
int roomLength;
int roomLengthRestore;

// timing the Zumo drive for building the map 
unsigned long driveLasted = 0;
unsigned long driveTimeSart;



// stores calibrated line sensor readings into lineSensorValues
// this should be called as many time as possible when driving in the corridor
void readSensor()
{
  lineSensors.readCalibrated(lineSensorValues);
}
// check if we should start turning left to not drive of the line
bool driftingOutside()
{
  return (lineSensorValues[0] < sensorMinThreshold && lineSensorValues[0] > 40);
}

// check if we are touching too much line 
bool driftingInside()
{
  return lineSensorValues[0] > sensorMaxThreshold;
}

// check if we hit a wall
bool hittingWall()
{
  return lineSensorValues[1] >= 80;
}

// function drifts Zumo to the left and right as long
// as the maximum drift time (half the room travel time)
// is reached
bool drivehalf(int currentTimeDrove){

      // at this point it most likely that we are in the middle of the rooms
      if(currentTimeDrove >= (roomLength /2) + beforeTurnDuration){
        motors.setSpeeds(0, 0);
        // require drive time for drawing the map
        driveLasted = (int)((millis() - driveTimeSart)/100);
        // we are scanning the room;
        return true;
      }
      // if we just lost the line try to drift left and find it
      else if(currentTimeDrove < (roomLength /4)){
        rightMotorSpeed = RightSpeed;
        leftMotorSpeed = correctionWheelSpeed;
      }
      // most likely wotn find the line, turn towards right to compensate
      // for left drift inside the room
      else{
        rightMotorSpeed = correctionWheelSpeed;
        leftMotorSpeed = leftSpeed;
      }
      // we are not scalling the room
      return false;
}

// drive straight untill obsticle
char driveStraight()
{
  // used to time drift function
  unsigned long recordedMillis = 0; 
  unsigned long currentMillis = 0;
  
  // start timer for map drawing calculation
  driveTimeSart = millis(); 
  
  while(true){
    // read and store line sensor data in the sensors array
    readSensor();


    if(driftingOutside()){
      // restore room lengh after right turn
      roomLength = roomLengthRestore;
      rightMotorSpeed = RightSpeed;
      leftMotorSpeed = correctionWheelSpeed;
      // reset drifting timer
      recordedMillis = 0;
    }

    else if(driftingInside()){
      roomLength = roomLengthRestore;
      rightMotorSpeed = correctionWheelSpeed;
      leftMotorSpeed = leftSpeed;
      recordedMillis = 0;
    }

    else if(hittingWall()){
      // back up from the wall
       motors.setSpeeds(-turnSpeed, -RightSpeed);
       delay(100);

       driveLasted = (int)((millis() - driveTimeSart)/100);

      // check if left turn is available
       if(currentMillis > ducarionAtJunction){
        // requires a bit more backing up 
        motors.setSpeeds(-turnSpeed, -RightSpeed);
        delay(50);
        motors.setSpeeds(0, 0);
        // turn left
        return 'L';
       }else{
        ducarionAtJunction = restDucarionAtJunction;
        motors.setSpeeds(0, 0);
        // turn right
        return 'R';
       }
      break;
    }

    // we are not toucking the line
    else{
      if(recordedMillis == 0){
        // start timing how long we drive withouth a line 
        recordedMillis = millis();
      }

      // how long Zumo is looking for the line
      currentMillis = millis() - recordedMillis;

      if(drivehalf(currentMillis)){
        // scan the room
        return 'T';
        recordedMillis = 0;
      }
    }

    motors.setSpeeds(leftMotorSpeed, rightMotorSpeed);
  }
}

// turn zumo 90 degree to the left or right
void turn(char dirrection)
{
  // reset the gyroscope
  turnSensorReset();

  switch(dirrection)
  {
    case 'L':
      finishValid += 90;

      // allow more time to fing the line 
      roomLength = roomLength *2;
      ducarionAtJunction = ducarionAtJunction *2;

      // turn the motors
      motors.setSpeeds(-turnSpeed, RightSpeed);

      // wait until turned 90 degrees 
      while((int32_t)turnAngle < (turnAngle1 * 90) )
      {
        // update gyroscope
        turnSensorUpdate();
      }
      // stop
      motors.setSpeeds(0, 0);
    break;

    // the same pcedure as left turn
    case 'R':
      finishValid -= 90;
      roomLength = roomLength *2;
      motors.setSpeeds(turnSpeed, -RightSpeed);
      while((int32_t)turnAngle > - (turnAngle1 * 90))
      {
        turnSensorUpdate();
      }

    break;
  }
}

void junctionDecision(char res){
  switch(res){

      // Turn zumo to the right
      case 'R':
      turnSensorReset();

      // check if zumo reached starting point
      if(finishValid == -180){
        XbeeSendPacket("MFINISHED!");
        finish = true;
      }
        // update map by drwaing a line 
        XbeeSendMap(dir, driveLasted);

        // update real Zumo direction
        if (dir == 3) { dir = 0; }
        else { dir += 1; }      

        turn(res);
        motors.setSpeeds(0, 0);
      break;
      
      // Turn the zumo to the left (the same procedure and right turn)
      case 'L':
        turnSensorReset();
        XbeeSendMap(dir, driveLasted);
        if (dir == 0) {dir = 3;}
        else{dir -= 1;}

        turn(res);
        motors.setSpeeds(0, 0);
      break;


      // found a room
      case 'T':
        // draw half of the room
        XbeeSendMap(dir, driveLasted);
        if (dir == 0) {dir = 3;}
        else{dir -= 1;}

        XbeeSendMap(dir, 20);
        if (dir == 3) { dir = 0; }
        else { dir += 1; }   

        XbeeSendMap(dir, 15);
              
        // turn 180 degrees to start scanning from the corridor 
        turnSensorReset();
        motors.setSpeeds(-turnSpeed + 10, RightSpeed - 5);
        while((int32_t)turnAngle <= (turnAngle1 * 179))
        {
          turnSensorUpdate();
        }
        motors.setSpeeds(0, 0);

        // start turning back
        motors.setSpeeds(turnSpeed, -RightSpeed);
        delay(50);

        bool foundAPerson = false;
        while((int32_t)turnAngle > (turnAngle1 * 1))
        {
          turnSensorUpdate();
          // while turning check if someone is in the room
          if(getProximity()){
            foundAPerson = true;
          }
        }
        motors.setSpeeds(0, 0);

        // draw a person on the map if one was found
        if(foundAPerson){
          XbeeSendPacket("MFound a person!");
          XbeeSendPacket("P");
          XbeeSendMap(4, 15);
        }
        

        // custom drift left procedure to recover after room scan
        unsigned long recordedMillisT;
        unsigned long currentMillisT;

        recordedMillisT = millis();
        // left motor speed based on turn angle drift and battery level
        motors.setSpeeds(correctionWheelSpeed + 30, RightSpeed);

          while(true){
            currentMillisT = millis() - recordedMillisT;
            // 250 mls of longer drive based on battery efficiency
            if(currentMillisT >= (roomLength /2) + 250){
              motors.setSpeeds(0, 0);
              break;
            }
          }

          // allow more time to find the line 
          roomLength = roomLength *2;

          // draw the rest of the room
          XbeeSendMap(dir, 15);
          if (dir == 3) { dir = 0; }
          else { dir += 1; }   
          XbeeSendMap(dir, 20);
          
          if (dir == 0) {dir = 3;}
          else{dir -= 1;}
          
          // some left over stream from serial (disposal)
          Serial.print("Dignored delim/");
        break;
      }
}

// calibaring line sensors
void calibrateSensors()
{
  // reset gyroscope to 0
  turnSensorReset();

  // turn to the left 90 degrees
  motors.setSpeeds(-calibrationSpeed, (int)(calibrationSpeed*1.25));

  // While our angle is not 90 degrees from the reset point
  while((int32_t)turnAngle < turnAngle45 * 2)
  {
    lineSensors.calibrate();
    // Keep updating our current angle 
    turnSensorUpdate();
  }

  // Turn to the right 90 degrees
  motors.setSpeeds(calibrationSpeed, -(int)(calibrationSpeed*1.25));
  while((int32_t)turnAngle > -turnAngle45 * 2)
  {
    lineSensors.calibrate();
    turnSensorUpdate();
  }

  // Turn back to the center using the gyro
  motors.setSpeeds(-calibrationSpeed, (int)(calibrationSpeed*1.25));
  while((int32_t)turnAngle <= 0)
  {
    lineSensors.calibrate();
    turnSensorUpdate();
  }

  // Stop
  motors.setSpeeds(0, 0);
}

// used for determiming doom size based on Zumo battery life
void calibrateRoomDistance(){

  // start driving and recorst start time
  motors.setSpeeds(turnSpeed, RightSpeed);
  unsigned long testStart;
  testStart = millis();
  delay(100);

  while(true){
    // wait untill a line is hit
    readSensor();
    if(lineSensorValues[1] >=100){
      roomLength = (millis() - testStart);
      // set a back up value for restoring ariginal room lenght
      roomLengthRestore = roomLength;
      break;
    }
  }
  motors.setSpeeds(0, 0);
}


#include <Wire.h>
#include <Zumo32U4.h>

Zumo32U4Buzzer buzzer;
Zumo32U4LineSensors lineSensors;
Zumo32U4ProximitySensors proxSensors;
Zumo32U4Motors motors;
Zumo32U4ButtonA buttonA;
Zumo32U4IMU imu;

// array to record each line sensor value for comparison
uint16_t lineSensorValues[3] = { 0, 0, 0 };

// turning direction
int dir = 1;

// selected mode ( 1, 2, or 3)
char mode;

// check if automated (mode 3) mode has finished it's search and rescue algorithm
bool finish = false;

// declare calibration functions for ZumoXbee.h to be in scope
void calibrateRoomDistance();
void calibrateSensors();

// activated when scanning the room
#include "ZumoProximity.h"
// activated when turning at a specific angle
#include "ZumoGyro.h"
// activated when sending or receiving a message to/from computer
#include "ZumoXbee.h"
// activated when Zumo requires movement
#include "ZumoMovement.h"

void setup()
{

  // start serial to send messages to the computer / xbee
  Serial1.begin(9600);

  // define usage of 3 sensors
  lineSensors.initThreeSensors();

  // set-up the proximity brigthness levels
  proximitySetUp();

  // sends the user meesage that connection is established and waiting for calibration
  XbeeSerialConnectionSetup(); 

  // instruction - Mode (ask user to select a mode)
  XbeeSendPacket("IM");

  // wait for response of selected mode
  XbeeWaitForPacket(); 

  // confirm correct mode selected
  XbeeSendPacket("MMode " + String(mode) + " selected");

  if(mode == '3'){
    // instruction - Calibrate (wait for user to press calibrate)
    XbeeSendPacket("IC");

    // wait for calibration response and calibrate
    XbeeWaitForPacket(); 
    
    // wait for user to press room calibration button
    XbeeSendPacket("IR");

    // wait for response and start calculating room size
    XbeeWaitForPacket(); 
  }
  
  // send a custom message to developer console
  XbeeSendPacket("MPress \"Start\" to look for people");

  // instruction - Start (ask user to press start)
  XbeeSendPacket("IS");

  // wait for start response and continue to loop();
  XbeeWaitForPacket();  
}

void mode1(){
  while(true){
    // wait for any incoming instructions    
    char res = XbeeReadDrivePacket(); 

    // set motor speed's based on direction received from the packet
    switch(res){
      case 'S':
        motors.setSpeeds(mode1LeftSpeed, mode1RightSpeed);
      break;
      case 'L':
       motors.setSpeeds(-mode1LeftSpeed -50, mode1RightSpeed + 50);
      break;
      case 'R':
      motors.setSpeeds(mode1LeftSpeed + 50, -mode1RightSpeed - 50);
      break;
      case 'B':
      motors.setSpeeds(-mode1LeftSpeed, -mode1RightSpeed);
      break;
      case 'Q':
      motors.setSpeeds(0, 0);
      break;
    }
  }
}

void mode2(){
  // unavailable
}

void mode3(){

  while(!finish){

    // drive straight untill we hit a wall or reach a room
    char res = driveStraight();

    // determine to scan the room or manke a at a junction turn 
    junctionDecision(res);
  }
}


void loop(){

  switch(mode){
    case '1':
      mode1();
    break;

    case '2':
      mode2();
    break;

    case '3':
      mode3();
    break;
  }

  // finished search and find alorithms
  // play some victory music
  buzzer.play("L16 cdegreg4");
  while(buzzer.isPlaying());

  delay(1000000);

}
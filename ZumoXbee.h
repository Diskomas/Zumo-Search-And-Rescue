#pragma once
#include <Wire.h>

// set up line and gyroscope sensors
void XbeeSerialCalibrationSetup(){
  turnSensorSetup();
  calibrateSensors();
}

// establish a connection with the computer
void XbeeSerialConnectionSetup(){

  bool correctConnection = false;

  // Wait for xbee to receive a packet confirming successfull connection
  while (!Serial1.available()  || correctConnection) {  }
  String res = String(Serial1.readString());

  if(res == "AC"){
    correctConnection = true;
    // Send instruction for calibration 
    Serial1.print("MConnected, ready to calibrate/");
  }

}

// sends a custom message to the computer
void XbeeSendPacket(String message){
  // prevent combination of packets
  delay(100);

  // some messages are sent in multiple packets. we use "/" as a delimiter
  String finalMessage = message + "/";

  Serial1.print(finalMessage);
}

// manage incoming packet
void XbeePacketManager(String packet){

  char Type = packet[0];
  char Instruction = packet[1];

  // manage actions based on packet
  switch(Type){
    case 'I':
      // calibration 
      if(Instruction == 'C'){
        XbeeSerialCalibrationSetup();
      }
      // start 
      else if(Instruction == 'S'){
        //buzzer.play("L16 cdegreg4");
        //while(buzzer.isPlaying());
      }
      // mode selection
      else if(Instruction == 'M'){
        mode = packet[2];
      }
      // room distance
      else if(Instruction == 'R'){
        calibrateRoomDistance();
      }
    break;

    // default response for unidentified packet
    default:
      Serial1.print("Continue.../");
    break;
  }
}

// pause and wait for a response from computer
void XbeeWaitForPacket(){

  // Wait for xbee to receive a packet
  while (!Serial1.available()) {  }

  // Read the result from the packet
  String packet = String(Serial1.readString());

  // Deal with incoming data
  XbeePacketManager(packet);

  // reset packet
  packet = "";
}

// update map on GUI
void XbeeSendMap(int dirrection, int time){

  // Prevent xbee sending next message in the same packet
  delay(100);

  Serial1.print("D" + String(dirrection) + String(time) + "/");
}

// packet receive looped for mode 1
char XbeeReadDrivePacket(){
  
  // Wait for xbee to receive a packet
  while (!Serial1.available()) {  }
    
  // Read the result from the packet
  String packet = String(Serial1.readString());
  return packet[0];
}
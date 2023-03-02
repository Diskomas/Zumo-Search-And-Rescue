
bool foundAPerson = false;

// set up proximity sensitivity and values
void proximitySetUp(){
  proxSensors.initThreeSensors();

  uint8_t proxSensorPins[] = { SENSOR_LEFT, SENSOR_FRONT, SENSOR_RIGHT };
  proxSensors.init(proxSensorPins, sizeof(proxSensorPins), SENSOR_LEDON);

  proxSensors.setPeriod(420);
  proxSensors.setPulseOnTimeUs(421);
  proxSensors.setPulseOffTimeUs(578);
  uint16_t levels[] = { 4, 15, 32, 55, 85, 120 };
  proxSensors.setBrightnessLevels(levels, sizeof(levels)/2);

}

// check if a persons is infront
bool getProximity(){
  // read proximity sensor data
  proxSensors.read();

  // we only want to look at front sensors
  int leftSendor = proxSensors.countsFrontWithLeftLeds();
  int rightSensor = proxSensors.countsFrontWithRightLeds();

  // reset sensor when person is out of scope
  if(leftSendor > 3 || rightSensor > 3){
    if(!foundAPerson){
      foundAPerson = true;
      return true;
    }else{
      return false;
    }
  }else{
    foundAPerson = false;
    return false;
  }
}



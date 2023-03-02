# Zumo Search Rescue

This template should help get you set up Zumo robot and GUI interface

[Demonstration Video](https://youtu.be/4ycHbwrv8N8)

## Used IDE for solutions

please use below listed IDE for running the provided code
- GUI [Microsoft Visual Studio](https://visualstudio.microsoft.com/#vs-section) + [.Net Framework](https://dotnet.microsoft.com/en-us/download/dotnet-framework) + [.Net Desktop development](https://visualstudio.microsoft.com/vs/features/net-development/)
- ZumoCode [Arduino IDE](https://www.arduino.cc/en/software)

## GUI Project Setup

### To use GUI

 - download GUI.exe from Zumo_Search_Rescue/GUI/GUI.exe
 - open downloaded GUI.exe

### To edit GUI

- Download "GUI" folder from "Zumo_Search_Rescue/".
- Install required packages provided in the "used IDE for solutions" section.
- In the solution explorer widnows double click "" to open GUI view.
- In the solution explorer widnows doudle click GUI form anywhere to open GUI code.
- In the solution explorer widnows right click GUI and select "Manage NugGet Packages".
- Select installed; in the search bar type "IO.Ports".
- Select System.IO.Ports and update version to 5.0.0 (very important).
- If IO.ports does not exist, use browse tab to download the 5.0.0 version into the project.
- Open the "Form1.cs [design]" tab and select "serialPort" at the bottom left.
- Rename port in properties field if required (default is COM7).
- click start in the top bar.
 

### Instruction to use GUI

- Turn on Zumo robot.
- Open GUI.exe or start inside Microsoft Visual Studio.
- Click "Open serial" (if error occured, act according to the message).
- Click "Connect".
- Click On one of the mode buttons (Mode 2 unavailable).
- 
Mode 1:
 - Click on "Mode 1" button.
 
 GUI button movement:
  - Click any of the arrow buttons presented in the "Movement Controlls" group.
  - To top zumo movement press the "STOP" button.
  
 GUI Keyboard Movement:
  - Click on the text bar below "STOP" button
  - Click any of the arrow keys on the keyboard
  - To stop Zumo movement, press space bar (Make sure you have clicked inside the text bar as instrcuted in the first step).

Mode 3:
- Click on "Mode 3" button.
- Physically move the Zumo robot to sit over the line
- Click "Calibrate" button.
- Wait for Zumo to finish calibration.
- Physically move the Zumo robot to either side of the room facing the oposite side.
- Move the Zumo as close to the end of the line but not over it.
- Click "Room" button and wait for zumo to move and calculate the distance of the room.
- Physically move the Zumo robot to the starting position where the left side motors ar barely touching the left side line.
- Click "Start" button.

if zumo loses track or turn angles are incurrectly - ZumoCode project treshold and other sensor values need to be adjusted

## ZumoCode Project Setup

### To edit ZumoCode

- download "ZumoCode" folder from "Zumo_Search_Rescue/".
- Open Arduino IDE.
- Click File -> Open -> "DownloadDir"/ZumoCode - > select MazeSolver.ino

### To upload ZumoCode

- Complete "To edit ZumoCode" steps.
- Connect Zumo robot via USB
- Click Upload button in the top left corner
- Wait for Arduino to complete upload.
- Disconnect Zumo robot.

### To make compatable for USB Serial

- Inside "ZumoXbee.h" rename "Serial1" to "Serial"
- Inside "MazeSolver.ino" rename "Serial1.begin(9600);" to "Serial.begin(9600);"

### Tip

Use new batteries for best peformance. Additionally speed and other adjustments can be made inside "ZumoMovement.h"

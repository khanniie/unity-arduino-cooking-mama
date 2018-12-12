# unity-arduino-cooking-mama
files for art and arduino interactive project 

it's pretty simple, the buttonpress.ino file sends info through the serial port and Unity grabs the string from the serial port and parses it

you'll need to change your player settings from .NET 2.0 subset to .NET 2.0!

I hard coded my port in ("/dev/....") in the arduinoController.cs file but you might need to check which port your arduino is plugged into and change it to that string instead :)

Thank you to Sidney Church for providing me with starter code and arduino help! 

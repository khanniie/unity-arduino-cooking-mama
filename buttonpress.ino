const int buttonOne = 3;
const int buttonTwo = 4;
const int buttonThree = 5;
const int buttonFour = 6;
const int buttonFive = 7;
const int buttonSix = 8;
const int buttonSeven = 9;

int buttonStateOne = 0;
int buttonStateTwo = 0;
int buttonStateThree = 0;
int buttonStateFour = 0;
int buttonStateFive = 0;
int buttonStateSix = 0;
int buttonStateSeven = 0;

int photocellReadingOne = 0; 
int photocellReadingTwo = 0; 

void setup() {

  Serial.begin(9600);
  pinMode(buttonOne, INPUT);
  pinMode(buttonTwo, INPUT);
  pinMode(buttonThree, INPUT);
  pinMode(buttonFour, INPUT);
  pinMode(buttonFive, INPUT);
  pinMode(buttonSix, INPUT);
  pinMode(buttonSeven, INPUT);
  
}

void loop() {

  buttonStateOne = digitalRead(buttonOne);
  buttonStateTwo = digitalRead(buttonTwo);
  buttonStateThree = digitalRead(buttonThree);
  buttonStateFour = digitalRead(buttonFour);
  buttonStateFive = digitalRead(buttonFive);
  buttonStateSix = digitalRead(buttonSix);
  buttonStateSeven = digitalRead(buttonSeven);

  photocellReadingOne = analogRead(A0);
  photocellReadingTwo = analogRead(A1);
  if(photocellReadingOne > 10) {
    Serial.print("1,"); 
  } else {
    Serial.print("0,"); 
  }
  if(photocellReadingTwo < 20) {
    Serial.print("1,"); 
  } else {
    Serial.print("0,"); 
  }

  if(buttonStateOne == HIGH){
    Serial.print("1,");
  } else {
    Serial.print("0,"); 
  }
  
  if(buttonStateTwo == HIGH){
    Serial.print("1,");
  } else {
    Serial.print("0,"); 
  }
  
  if(buttonStateThree == HIGH){
    Serial.print("1,");
  } else {
    Serial.print("0,"); 
  }

//  if(buttonStateFour == HIGH){
//    Serial.print("1,");
//  } else {
//    Serial.print("0,"); 
//  }
//   
  if(buttonStateFive == HIGH){
    Serial.print("1,");
  } else {
    Serial.print("0,"); 
  }
  
  if(buttonStateSix == HIGH){
    Serial.print("1,");
  } else {
    Serial.print("0,"); 
  }
  
  if(buttonStateSeven == HIGH){
    Serial.print("1,");
  } else {
    Serial.print("0,"); 
  }
  
  Serial.println("");
  delay(100);
  
}

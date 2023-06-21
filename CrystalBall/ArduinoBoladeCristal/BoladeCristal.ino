/*
  Arduino Starter Kit example
  Project 11 - Crystal Ball

  This sketch is written to accompany Project 11 in the Arduino Starter Kit

  Parts required:
  - 220 ohm resistor
  - 10 kilohm resistor
  - 10 kilohm potentiometer
  - 16x2 LCD screen
  - tilt switch

  created 13 Sep 2012
  by Scott Fitzgerald

  https://store.arduino.cc/genuino-starter-kit

  This example code is part of the public domain.
*/

// include the library code:
#include <LiquidCrystal.h>
#include <stdio.h>

// initialize the library with the numbers of the interface pins
LiquidCrystal lcd(12, 11, 2, 3, 4, 5);

// set up a constant for the tilt switch pin
const int switchPin = 13;

// variable to hold the value of the switch pin
int switchState = 0;

// variable to hold previous value of the switch pin
int prevSwitchState = 0;

// a variable to choose which reply from the crystal ball
int reply;

void setup() {
  Serial.begin(9600);
  // set up the number of columns and rows on the LCD
  lcd.begin(16, 2);

  // set up the switch pin as an input
  pinMode(switchPin, INPUT);

  // Print a message to the LCD.
  lcd.print("Pregunta a la");
  // set the cursor to column 0, line 1
  // line 1 is the second row, since counting begins with 0
  lcd.setCursor(0, 1);
  // print to the second line
  lcd.print("Bola de cristal!");
}

void loop() {
  // check the status of the switch
  switchState = digitalRead(switchPin);

  // compare the switchState to its previous state
  if (switchState != prevSwitchState) {
    // if the state has changed from HIGH to LOW you know that the ball has been
    // tilted from one direction to the other
    if (switchState == LOW) {
      // randomly chose a reply
      reply = random(8);
      // clean up the screen before printing a new reply
      lcd.clear();
      // set the cursor to column 0, line 0
      lcd.setCursor(0, 0);
      // print some text
      lcd.print("La bola dice:");
      // move the cursor to the second line
      lcd.setCursor(0, 1);

      int op;
      // choose a saying to print based on the value in reply
      switch (reply) {
        case 0:
          lcd.print("Si");
          op = 0;
          break;
        case 1:
          lcd.print("Muy probable");
          op = 1;
          break;
        case 2:
          lcd.print("Ciertamente");
          op = 2;
          break;
        case 3:
          lcd.print("Parece bien");
          op = 3;
          break;
        case 4:
          lcd.print("No es seguro");
          op = 4;
          break;
        case 5:
          lcd.print("Intenta de nuevo");
          op = 5;
          break;
        case 6:
          lcd.print("Es incierto");
          op = 6;
          break;
        case 7:
          lcd.print("No");
          op = 7;
          break;
      }
      Serial.println(op);
      Serial.println("-");
    }
  }
  // save the current switch state as the last state
  prevSwitchState = switchState;
}

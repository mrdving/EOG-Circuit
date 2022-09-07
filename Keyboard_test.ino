#include<Keyboard.h>

const int pin_L = 2;
const int pin_R = 3;
const int pin_active = 4;
const int pin_Rect = A0;
const int pin_Schmitt = A5;
const int pin_BPF = A1;

const char key_L = 'a';
const char key_R = 'd';

void setup() {
  pinMode(pin_L, INPUT);
  pinMode(pin_R, INPUT);
  pinMode(pin_Rect, INPUT);
  pinMode(pin_Schmitt, INPUT);
  pinMode(pin_BPF, INPUT);
  
  
  Keyboard.begin();
  Serial.begin(9600);
}

void loop() {
  delay(100);
  Serial.print(digitalRead(pin_L)? 1 : 0);
  Serial.print(digitalRead(pin_active)? 1 : 0);
  Serial.print(digitalRead(pin_R)? 1 : 0);

  Serial.print(" BPF :");
  Serial.print(analogRead(pin_BPF));
  Serial.print(" Sch :");
  Serial.print(analogRead(pin_Schmitt));
  Serial.print(" Rec :");
  Serial.print(analogRead(pin_Rect));

  Serial.println("");

  
  //*
  if(digitalRead(pin_L) && digitalRead(pin_active))Keyboard.press(key_L);
  else Keyboard.release(key_L);
  
  if(digitalRead(pin_R) && digitalRead(pin_active))Keyboard.press(key_R);
  else Keyboard.release(key_R);
  //*/
}

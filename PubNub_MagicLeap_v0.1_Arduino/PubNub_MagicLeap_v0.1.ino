#include <ESP8266WiFi.h>
#define PubNub_BASE_CLIENT WiFiClient
#include <PubNub.h>
 
const static char ssid[] = "MySpectrumWiFic0-5G";
const static char pass[] = "goldcar996";

int rled = 14; // The PWM pins the LED is attached to.
int gled = 12;
int bled = 15;


int mode = 0;
bool on = false;

//Light 2
// The PWM pins the LED is attached to.
int rled2 = 16; 
int gled2 = 5;
int bled2 = 4;

int mode2 = 0;
bool on2 = false;


void setup() {
    //Light 1
    pinMode(rled, OUTPUT);
    pinMode(gled, OUTPUT);
    pinMode(bled, OUTPUT);
    
    //Light 2
    pinMode(rled2, OUTPUT);
    pinMode(gled2, OUTPUT);
    pinMode(bled2, OUTPUT);
    Serial.begin(9600);
    WiFi.begin(ssid, pass);
    if(WiFi.waitForConnectResult() == WL_CONNECTED){
      PubNub.begin("pub-c-270dafe4-6c23-47e4-b9eb-62d9590a9846", "sub-c-2e822568-1d76-11eb-8a07-eaf684f78515");
    } else {
      Serial.println("Couldn't get a wifi connection");
      while(1) delay(100);
    }
}
 
void loop() {
    PubNub_BASE_CLIENT *client;
    
    Serial.println("waiting for a message (subscribe)");
    PubSubClient *pclient = PubNub.subscribe("control"); // Subscribe to the control channel.
    if (!pclient) {
        Serial.println("subscription error");
        delay(1000);
        return;
    }
    String message;
    while (pclient->wait_for_data()) {
        char c = pclient->read();
        message = message+String(c); // Append to string.
    }
    pclient->stop();
    if(message.indexOf("lgt-1-on") > 0) {
        on = true;
        Serial.print("on");
    } else if (message.indexOf("lgt-1-off") > 0) {
        on = false;
    } else if (message.indexOf("lgt-1-changel") > 0) {
      if (mode > 0) {
        mode=mode-1;
      } else if (mode == 0) {
        mode=5;
      }
    } else if (message.indexOf("lgt-1-changer") > 0) {
      if (mode < 5) {
        mode=mode+1;
      } else if (mode == 5) {
        mode=0;
      }
    }//Light2 Commands
    else if(message.indexOf("lgt-2-on") > 0) {
        on2 = true;
        Serial.print("on2");
    } else if (message.indexOf("lgt-2-off") > 0) {
        on2 = false;
    } else if (message.indexOf("lgt-2-changel") > 0) {
      if (mode2 > 0) {
        mode2 = mode2-1;
      } else if (mode2 == 0) {
        mode2=5;
      }
    } else if (message.indexOf("lgt-2-changer") > 0) {
      if (mode2 < 5) {
        mode2=mode2+1;
      } else if (mode2 == 5) {
        mode2=0;
      }
    }

    //---------- Light 1 Logic -------------------------
    if (on == true) { // Turn on led.
      if (mode == 0) { // White
        analogWrite(rled, 255);
        analogWrite(gled, 255);
        analogWrite(bled, 255);
        Serial.println("Mode 0 White");
      } else if (mode == 1) { // Less Bright White
        analogWrite(rled, 255);
        analogWrite(gled, 165);
        analogWrite(bled, 0);
        Serial.println("Mode 1 less White");
      } else if (mode == 2) { // Red
        analogWrite(rled, 255);
        analogWrite(gled, 0);
        analogWrite(bled, 0);
        Serial.println("Mode 2 Red");
      } else if (mode == 3) { // Green
        analogWrite(rled, 0);
        analogWrite(gled, 255);
        analogWrite(bled, 0);
        Serial.println("Mode 3 Green");        
      } else if (mode == 4) { // Blue
        analogWrite(rled, 0);
        analogWrite(gled, 0);
        analogWrite(bled, 255); 
        Serial.println("Mode 4 Blue");
      } else if (mode == 5) { // Purple
        analogWrite(rled, 255);
        analogWrite(gled, 0);
        analogWrite(bled, 255);
        Serial.println("Mode 5 Purple");
      }
    } else { // Turn off led
      analogWrite(rled, 0);
      analogWrite(gled, 0);
      analogWrite(bled, 0);
    }

    
    if (on2 == true) { // Turn on led.
        Serial.println("On 2");

      if (mode2 == 0) { // White
        analogWrite(rled2, 255);
        analogWrite(gled2, 255);
        analogWrite(bled2, 255);
        Serial.println("Light 2 - Mode 0 White");
      } else if (mode2 == 1) { // Less Bright White
        analogWrite(rled2, 255);
        analogWrite(gled2, 165);
        analogWrite(bled2, 0);
        Serial.println("Light 2 - Mode 1 less White");
      } else if (mode2 == 2) { // Red
        analogWrite(rled2, 255);
        analogWrite(gled2, 0);
        analogWrite(bled2, 0);
        Serial.println("Light 2 - Mode 2 Red");
      } else if (mode2 == 3) { // Green
        analogWrite(rled2, 0);
        analogWrite(gled2, 255);
        analogWrite(bled2, 0);
        Serial.println("Light 2 - Mode 3 Green");        
      } else if (mode2 == 4) { // Blue
        analogWrite(rled2, 0);
        analogWrite(gled2, 0);
        analogWrite(bled2, 255); 
        Serial.println("Light 2 - Mode 4 Blue");
      } else if (mode2 == 5) { // Purple
        analogWrite(rled2, 255);
        analogWrite(gled2, 0);
        analogWrite(bled2, 255);
        Serial.println("Light 2 - Mode 5 Purple");
      }
    } else { // Turn off led
      analogWrite(rled2, 0);
      analogWrite(gled2, 0);
      analogWrite(bled2, 0);
    }
    
    Serial.print(message);
    Serial.println();
    delay(5);
}

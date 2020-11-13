# Magic-Leap-Playground
 
M8s Smart Home 11 13 20

# Arduino

Arduino Board: ESP8266 NodeMCU CP2102 ESP-12E
Magic Leap / Pubnub LED control - 2 individual LEDS.
Program file: PubNub_MagicLeap_v0.1_Arduino/PubNub_MagicLeap_v0.1.ino

Next goals: WS2812B LED Strip control & Color wheel interactions. ( I think i should probably grab some resistors and capacitors)

Pictures, Videos, and wiring diagrams to come.

# Unity
Project Scene: Scenes/M8s Smart Home - V 0.1
Gathered different functionalities from samples and started brainstorming my requirements.
Functionalities I'm playing with: 
* Image Tracking (would be fun to have interactions with art around the house)
* Meshing (being wonky right now. bottle necking of Zero iteration debuging maybe?)
* Persistent Coordinate Frames (Need to change some of the controller bindings around before enabling it)
* Planes (For device placement snapping? might be easier to work with than the raw meshes)
* RayCast Modes (controller, head, eye (needs smoothing & interpolation), index finger (needs a lot of smoothing lol.)
* Virtual Keyboard (For user input & voice input trigger?)

Functions Enabled Right Now:
Hand Gestures & direct Pubnub interactions
Raycast mode toggles - controller - head - eye


Next Goal
Reenable Persistent Coordinate Frames & static object placement

Program interactions when head raycast hits a placed object (create a tag / layer for PlacedDevices)

Program Device Binding after placing persistent object. (UI & Buttons?)
 - It at least needs to let a user choose from a list of available devices. (Configuration Walk through to come)
 
# Focus on design. 
I need to start creating a UX look and feel. 

Building from the example debug UI is a little convoluted and its too windows-esqe, but theres definitely some good features to rip out.



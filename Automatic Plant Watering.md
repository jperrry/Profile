---
title: Arduino - Automatic Plant Watering
date: 2025-02-12
modified: 2025-02-12 10:32
tags:
  - Hardware
  - Arduino
  - Automation
status: Completed
---

# 📝 Project Overview

This project was my introduction to working with Arduino and my first hands-on experience with electronics beyond typical PC hardware. I began with a period of research, spending about a week going through tutorials, forum discussions, and technical documentation to build a foundation.

I started by learning the basics of electrical principles such as AC vs DC, voltage, and current, before moving into common components used in small automation projects—resistors, transistors, breakout modules, and GPIO headers. As I gained familiarity, I was able to look at simple prototypes and understand both the parts involved and the logic driving them.

To bridge the gap between theory and practice, I watched complete project walkthroughs, particularly those focused on microcontroller-based automation and plant watering systems. This helped me see how individual concepts and components integrate into a finished product.

Once I was confident in the fundamentals, I sourced components and tools from **Core Electronics**, an Australian supplier known for reliability and clear documentation. Their selection and quality gave me a solid starting point for building and experimenting with my own Arduino-based automation projects.

---
### Quick Breakdown

1. Installed Arduino IDE and configured CH340 board drivers.

2. Tested power flow on breadboard using USB connection.

3. Connected and validated soil moisture sensor (debugged analog input issue).

4. Integrated water pump via relay module (troubleshooted reversed ports).

5. Improved wiring with Dupont connectors and crimping tool.

6. Wrote Arduino program to trigger pump based on soil moisture levels.

7. Transferred build to Arduino Uno R3 with acrylic case.

8. Switched from battery power to stable USB adapter for reliability.

---
## ✅ Steps

1. **Initial Setup** – I picked up the microcontrollers second-hand ($10 AUD) before the rest of the components arrived. To get started, I installed the [Arduino IDE](https://www.arduino.cc/en/software) on my Linux laptop. My first attempt was unsuccessful due to downloading an incompatible version, but once I corrected that, the installation and setup were straightforward.

2. **Board Configuration** – With the IDE installed and the board connected, I configured the settings. Since I was using a CH340-based board, I needed to install additional drivers before the board was recognized. Once installed, I selected the correct board model and COM port to complete setup.

3. **Breadboard Testing** – When the rest of the parts arrived, I connected the controller to a breadboard and ran basic power tests to ensure the circuit was functioning. During prototyping, I powered the system via USB from my laptop for consistency.

4. **Moisture Sensor Setup** – After confirming stable connections with jumper wires and a multimeter, I connected the soil moisture sensor. This was straightforward, with three labelled connections: power, ground, and analog output.

5. **Sensor Debugging** – To validate the sensor, I uploaded a simple test script to output readings to the IDE’s serial monitor. Initially, I received the same value (~350) regardless of conditions. After troubleshooting, I discovered I hadn’t properly declared the analog pin. Updating the variable from `0` to `A0` resolved the issue and provided accurate readings.

6.  **Pump Integration** – The water pump required a relay module to trigger water flow when moisture levels fell below a set threshold. Wiring was simple (Vin and GND), but the relay presented challenges due to unclear documentation.

7. **Relay Troubleshooting** – During testing, the pump continuously ran instead of responding to sensor input. After several hours of trial and error, I discovered the relay ports were effectively reversed compared to an English relay module I used as reference. Rewiring to the alternate port resolved the issue, allowing the pump to trigger correctly.

8. **Connector Improvements** – The pump’s default wires were too thin for reliable use. I researched connectors and settled on using Dupont connectors with a basic crimping tool. This significantly improved connection stability and made future adjustments easier.

9. **Program Development** – I wrote a simple Arduino program to combine sensor input with pump control. Using ChatGPT as a starting point, I debugged and adjusted the code until it worked reliably. The program currently takes one reading per second and triggers the pump as needed. Future improvements include averaging multiple readings to reduce the risk of unnecessary pump activation.

10. **Final Board Selection** – Initially, I planned to solder directly onto a microcontroller without headers for a compact build. However, with limited soldering experience and no proper casing, I instead opted for an Arduino Uno R3. A low-cost acrylic case provided a simple housing solution.

11. **Transfer and Enclosure** – Moving the connections to the R3 board was straightforward thanks to the female GPIO headers. Once secured inside the case, I used zip ties for cable management. While the relay and power supply had no dedicated mounts, electrical tape provided a functional (if not aesthetic) solution.

12. **Power Considerations** – My first attempt at using a battery pack failed within two days due to higher-than-expected power consumption, likely caused by false sensor triggers. To simplify, I switched to powering the system through the Uno’s USB power jack with a standard adapter, which has proven reliable.

---

## 🛠 Tools

- [Digikey CH340 Microcontroller](https://www.digikey.com/en/htmldatasheets/production/3552695/0/0/1/dev-15096) - Prototype Testing Board
- [Arduino UNO Controller Board](https://docs.arduino.cc/hardware/uno-rev3/) - Production Controller Board
- Solderless Breadboard - 830 Tie Point
- Diagonal Cutters
- Tubing for Submersible Pumps - PVC 6mm ID - 1 Meter Long
- Capacitive Soil Moisture Sensor (v2.0)
- 5V Single Channel Relay Module 10A
- Needle Nose Pliers
- Jumper Wires (Various)
- Dupont Connectors
- Wire Crimper
- [Arduino IDE](https://www.arduino.cc/en/software) 
- Digital Multimeter
- 9V Battery
- 9V Battery Clip (3.5mm Power Jack Adapter)
- USB Power/Data Cable

---

## 🔗 References

- [Core Electronics](https://core-electronics.com.au/) - DIY Electronics Hobbyist Store

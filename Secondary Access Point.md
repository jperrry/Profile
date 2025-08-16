# Access Point Configuration
## Overview

This project focused on configuring a secondary router to operate as an access point, extending both Wi-Fi coverage and wired connectivity to a part of the house that was outside the primary router’s range. The setup not only improved wireless performance in weaker zones but also acted as a small hub for devices requiring reliable Ethernet access.

Since the network was previously limited to a single PoE line, the main objective was to increase flexibility and stability without investing in new hardware. While configuring the AP, I also ensured the mirrored security settings (such as WPA2 encryption and consistent SSID/password policies) aligned with the primary router to avoid misconfigurations that could introduce vulnerabilities. This way, the extended coverage provided both performance and security consistency across the network.

---
## Skills & Technologies Used

- [ ] Networking
- [ ] Security
- [ ] System Administration
- [ ] Research & Documentation

---
## ⚙️ Setup & Installation

### **Installation Steps**

1. **Access Admin Portal** 
	Start by logging into the primary router’s administration portal (commonly at `192.168.1.1`).  
	- Security note: Always change default login credentials before proceeding. Leaving factory defaults poses an unnecessary risk.

2. **System Administration (Optional but Recommended)**  
	Before introducing the second router, it’s good practice to tidy up existing configurations. This includes setting strong, unique passwords across all entry points, renaming generic device identifiers to meaningful labels, and familiarizing yourself with available settings.

3. **Power On Second Router** 
	Connect and power on the second router. Make sure the power supply is secure and the DSL port remains unused, as all internet traffic will be routed through the primary device.

4. **Access New Admin Portal**
	Connect a personal device directly to the new router and navigate to its local admin page. As with the primary router, update default login credentials immediately to avoid exposing a weak point in the network.

5.  **Configuring Second Access Point**:
	   - **If router has AP/Bridge mode** - Enable “Access Point” or “Bridge” mode from the administration panel. Once connected to the primary router, the secondary device will automatically function as an extension of the main network.
	     ![[AP_mode.png]]
	
	- **If AP/Bridge Mode is Not Available:**  
		Navigate to the internet connection setup page and configure the router to obtain its network details dynamically. In this case, the primary router effectively acts as the ISP, providing the necessary configuration values.
		  ![[Pasted image 20250319101321.png]]

6. **Configure New Wireless Networks**
	With the access point online, configure the 2.4GHz and 5GHz networks. Assign meaningful SSIDs, apply WPA2 or WPA3 security, and set strong passwords to ensure both accessibility and security consistency across the extended network.
   ![[Pasted image 20250319102357.png]]

---
## 🔍 Troubleshooting

| Issue                      | Cause                                  | Solution                                                                                                                                                           |
| -------------------------- | -------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Unknown Router Credentials | First time accessing router admin page | Identify  model/serial number generally underneath the device and check it against a [default password directory](https://portforward.com/router-password/#B)      |
| Connecting Access Points   | Physical Distance                      | In my case, I've had a long-term positive experience with TP-Link PoE connections allowing you to send an *ethernet* connection through existing electrical lines. |
| Power Overload             | Inappropriate Power Supply Unit        | Ensure your PSU is correctly rated for your router, supplying too much power *will* fry the internal components                                                    |

---
## 📚 References

- https://portforward.com/router-password/#B
- https://bitwarden.com/resources/the-state-of-password-security/
- https://community.cisco.com/t5/networking-knowledge-base/configuring-the-access-point-for-the-first-time/ta-p/3154316
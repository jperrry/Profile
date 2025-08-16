---
title: DIY NAS
date: 2025-02-12
modified: 2025-02-12 13:25
tags:
  - Hardware
  - Storage
  - Network
  - PC
  - Ethernet
status: Completed
---

# 📝 Project Overview

This project involved the planning and construction of a custom Network Attached Storage (NAS) system, designed to provide reliable, secure, and cost-efficient storage accessible across a local network. A NAS functions as a dedicated storage device that can be accessed by multiple users and devices, often serving as a private cloud solution for file sharing, backup, and data management.

**Objective**  
The primary goal of this project was to build a fully functional NAS using repurposed and second-hand hardware components. This approach ensured minimal cost while demonstrating effective system design, optimization, and resource efficiency.

**Planning & Design**

- Conducted research into NAS architectures and compared software platforms (e.g., FreeNAS/TrueNAS, OpenMediaVault) to determine the best fit for stability and security.
- Designed a system that balanced performance, storage capacity, and energy efficiency while prioritizing data integrity and secure access.
- Planned for scalability, allowing future storage expansion without requiring a complete rebuild.

**Key Takeaways**

- Gained hands-on experience in planning and deploying a network-based storage system.
- Reinforced understanding of file sharing protocols, network configuration, and access controls.
- Demonstrated ability to optimize and secure a system using limited resources.
- Highlighted the importance of scalability and redundancy in storage infrastructure.

---

## ✅ Steps

1. **Motherboard Installation** – Mounted the motherboard within the frame and secured it at key points to provide a stable base for the build.
    
2. **Drive Bay Setup** – Installed the HDD bay and drives, ensuring they were firmly seated. Applied basic cable management during installation to maintain airflow and simplify future troubleshooting.
    
3. **Component Installation** – Added RAM modules and refreshed thermal paste on the CPU before installation. Installed a Noctua CPU cooler to ensure stable thermal performance.
    
4. **Cooling** – Repurposed case fans from an older chassis to provide additional airflow across the system.
    
5. **Power Supply** – Secured the PSU in place and ensured stable connections for all components.
    
6. **Operating System Deployment** –
    
    - Prepared a bootable USB drive to host the NAS operating system.
    - Attempted installation with _OpenMediaVault_, but after persistent issues switched to _TrueNAS_, which installed successfully on the first attempt.
    - Opted to run the OS from USB media to support continuous operation and minimize hardware requirements.
    
7. **Network Configuration** – Assigned a static IP address and added the NAS to the local DNS server for reliable access. Logged into the TrueNAS web UI to perform initial configuration and verification.

---
## Security Considerations

- Configured **role-based access controls (RBAC)** to restrict data access by user and group.
- Applied **strong authentication** and enforced password complexity policies.
- Enabled **encryption at rest** for sensitive data where supported by the NAS OS.
- Implemented **automated backups and redundancy** to protect against data loss.
- Limited **network exposure** by keeping the NAS accessible only within the local network and not exposing services directly to the internet.

---
## 🛠 Tools

- 32GB USB 3.0 - Host OS Software
- 16GB RAM 
- 4 x 4TB 3.5" SATA HDD
- Intel Core i5 8600k CPU 
- Prime Z370-A Motherboard
- 5 x 3.5" SATA HDD Cage
- 550w Thermaltake 80 Gold + PSU

---

## 🔗 References

YouTube
- [Custom NAS Build](https://www.youtube.com/watch?v=-lCYducWCMM) - Lenovo ThinkCentre Repurposing
- [TrueNas Web UI Tutorial](https://www.youtube.com/watch?v=XCouS6Zw5vA)
- [OpenMediaVault - Blue Screen Install Troubleshooting](https://www.youtube.com/watch?v=ZuhmnwUWAms) 
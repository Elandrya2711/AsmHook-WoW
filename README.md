# Project Overview

This project was originally developed in 2015/2016 and has now been reuploaded to GitLab for archival purposes. The primary goal was to create a bot for the online game World of Warcraft, specifically tailored for version 3.3.5a on private servers. This project was primarily a learning and research exercise, focusing on reverse engineering and Assembly programming.

## Interesting Classes

- **[D3DHook.cs](Hooks/D3DHook.cs)**
  Executing Assembly code by manually hooking into the D3D render function and looping to execute all needed commands in one frame.

- **[GameObject.cs](WoWObjects/GameObject.cs)**
  Reading properties from game memory and interacting with objects using in-game APIs and Assembly.

## Disclaimer

Please note that this project was developed for educational purposes only and was intended for use on private servers. It was never intended for malicious exploitation or use on official game servers. This project served as a means to deepen my understanding of reverse engineering and Assembly language programming.

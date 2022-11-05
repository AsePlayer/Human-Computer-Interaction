# CST-320
GCU - Human Computer Interaction - Team 9

Authors: Andrew Esch, Diego Guerra, and Ryan Scott

Statement of Own Work: We certify that this program is our own work and ideas, verifying that no help was provided. All sources for this project are licensed under the Creative Commons or the Unity Asset store. We are aware that the incorporation of material from other's work without acknowledgement is treated as plagiarism.


## Space Trooper Project
Goal: To imagine what it would be like for an astronaut to live and complete tasks in outer space for long periods of time.

Demo Video: https://www.loom.com/share/989a0b55662a4fed9ec819b9341064b1

## Build Instructions
To load the SpaceTrooper project directly from Unity onto an Oculus Quest device, ensure the project has the following settings below.

### Setting the Unity Install Version
The team build the SpaceTrooper project under Unity 2021.1.20f1. However, any Unity 2021 install version is compatible with the SpaceTrooper project. 

### Package Imports
To run the application, ensure that the project has all default unity packages and the following packages:
1. XR Interaction Toolkit (version 1.0.0-pre.6)
2. XR Plugin Management (version 4.1.0+)
3. Oculus XR Plugin (version 1.10.0+)
4. Version Control (version 1.13.5+)
5. TextMesh Pro (version 3.0.6+)
6. Post Processing (version 3.1.1)

### Project Settings
Under the Player tab, follow these steps to ensure the project will run as intended:
1. Ensure the company and product name have been set to "BrewVR" and "SpaceTrooper" respectively.
2. Under the "Other Settings" tab in "Settings for Android", ensure the project has the following settings:
- Set color space to "Linear".
- Set "Minimum API Level" to "Android 6.0 'Marshmellow' (API Level 23)".
- Set Target API Level to "Automatic (highest installed)".
- IMPORTANT: Set "Active Input Handling" to "Input Manager (Old)". This will cause the application to reload when enabling this option. Moreover, a pop-up will appear about the input manager when the project reloads. Remember to click "No" each time the project reloads.
- Leave all other settings as default and confirm that these project settings match the attached image: https://drive.google.com/file/d/1e8XVu-MY0YZMv4dfTx_PDhnkrjRqeNwH/view?usp=sharing

Next, under the XR Plug-in Management tab, check the option for "Oculus" under "Plug-in Providers". This will import and generate a new sub-tab called "Oculus". Under the new sub-tab, follow these steps to enable Oculus integration:
1. Set "Studio Rendering Mode" to "Multi Pass".
2. Enable the option for "Optimize Buffer Discards (Vulkan)".
3. Target devices are set to "Quest" and "Quest 2".
4. Leave all other options as unchecked or as default.

### Build Settings
To build and run the project, install Android Studio with any SDK version later than 4.4 Kitkat, API Level 23 (see https://developer.android.com/studio)

Also, ensure that the Oculus Quest device has Developer Mode enabled by following the device step instructions at this link: https://developer.oculus.com/documentation/native/android/mobile-device-setup/.

If the project is being built on a Windows device, ensure that Oculus ADB Drivers are installed on the device (see https://developer.oculus.com/downloads/package/oculus-adb-drivers/).

Then, under build settings in Unity, follow these steps to ensure the project will build onto an Oculus Quest:
2. Change texture compression to "ASTC".
3. Set ETC2 fallback to 32-bit (if it is not the default).
4. Change compression method to "LZ4" (if it is not the default).
5. Ensure that the Oculus Device appears under "Run Device" when plugged into the computer.
6. Keep all other settings as default (or unchecked). 

Finally, under build settings, ensure the "Scenes to Build" has the following scenes (in order):
1. Scenes/FinalProject/IntroSceneLoadingScreen
2. Scenes/FinalProject/IntroScene
3. Scenes/FinalProject/SpaceHallwayLoadingScreen
4. Scenes/FinalProject/spaceHallway
5. Scenes/FinalProject/FireExtinguisherLoadingScreen
6. Scenes/FinalProject/FireExtinguisherTestRoom
7. Scenes/FinalProject/SpaceInvadersLoadingScreen
8. Scenes/FinalProject/SpaceInvaders
9. Scenes/FinalProject/SpaceKitchenLoadingScreen
10. Scenes/FinalProject/SpaceKitchen

The SpaceTrooper project is now ready to load onto an Oculus Quest! Get ready to experience a new out-of-this-world reality!

# Valheim-Gamepad-Interact-Text-Fix
Currently Valheim does not display the correct gamepad button binding when hovering over an interactable item.
This mod will allow you to fix this but **you must specify the button name yourself** as it will **not be automatically detected** in-game (or download one of the preconfigured packs)

# Installation
You must have BenInEx installed.\
Copy **GamepadInteractTextFix.dll** into **Valheim\BepInEx\plugins**\
Alternatively, if you downloaded one of the preconfigured packs then all you need to do is copy the **plugins** and **config** folders into **Valheim\BepInEx**

# Config
In order to specify the text/button that you want to be displayed, navigate to **Valheim\BepInEx\config** and look for a file named **projjm.gamepadInteractTextFix.cfg**.
You **may** need to **run the mod at least once** for this file to show up.

Change the value of **customInteractButton** to your desired button name.
There is also a special set of strings that will convert to symbols if you need them:
 * **PS_X**
 * **PS_SQUARE**
 * **PS_TRIANGLE**
 * **PS_CIRCLE**
 * **DPAD_UP**
 * **DPAD_DOWN**
 * **DPAD_LEFT**
 * **DPAD_RIGHT**
 * **JOYSTICK_RIGHT**
 * **JOYSTICK_LEFT**
 
# Changelog
    - Version 1.0.0 -
        Initial Release. No bugs known.

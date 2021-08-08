# Doors-And-Buttons

This is a tutorial project for beginners that provides examples of how to use abstract classes and inheritance. The project was created with Unity 2018.2.17, but should work in other versions as well.

DoorManager contains information about the doors it controls and the buttons that control it. Different DoorManagers can be setup to have common doors and buttons.

Doors can be setup to be open at start.

DoorButton.cs - is a base class from which other button types inherit. If you want to create a new button type and use it with existing setup you should inherit it from this class.

Switch button - retains state after player exits trigger.  
![Switch button](https://raw.githubusercontent.com/gamedevserj/Images-For-Repo/main/DoorsAndButtons/switch-button.gif)  
Can affect other switch buttons.  
![Button number 3 affects button number 2](https://raw.githubusercontent.com/gamedevserj/Images-For-Repo/main/DoorsAndButtons/switch-button-affects-another.gif)

Press button - reverts to inactive state after player exits the trigger.  
![Press button](https://raw.githubusercontent.com/gamedevserj/Images-For-Repo/main/DoorsAndButtons/press-button.gif)

Timer button - retains state for some time after player exits the trigger.  
![Timer button](https://raw.githubusercontent.com/gamedevserj/Images-For-Repo/main/DoorsAndButtons/timer-button.gif)

Hold button - needs to be held until bar is filled.  
![Hold button](https://raw.githubusercontent.com/gamedevserj/Images-For-Repo/main/DoorsAndButtons/hold-button.gif)

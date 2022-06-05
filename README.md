# Mars Rover Challenge

The project was initially undertaken as part of the Mars Rover Kata Challenge. The initial challenge was to create functionality to move Rovers around the surface of Mars.
In this context, the surface of Mars is represented by a Plateau. The Rovers navigate the Plateau via a set of letters representing move commands 'L,R,M'. The Rovers position is 
represented by X and Y co-ordinates with a direction represented by 'N,S,E,W'.
Having completed the initial challenge, the task was set to extend the program into a Object-Orientated Programming design. 

![grab-landing-page](https://github.com/Hayley96/Mars-Rover/blob/main/GIF/MarsRoverAnimation.gif)

## Description

Upon initial execution, the application will present a menu to the user. You can navigate the menu using the Up Arrow and Down Arrow keys. To enter a menu option 
press Enter.

Selecting option 1 in the menu will start the Mars Rover program. Selecting option 2 will present the user with a small extract about the history of the NASA Mars Rover.

The Mars Rover program flow:

* Select Plateau type/shape
* Input Plateau size X and Y
* Select Vehicle Type
* Apply positional co-ordinates to vehicle instance
* Apply movement commands to vehicle instance
* Repeat steps 3-5 until program exited by user

There is currently only one type of shape available representing the Plateau (Rectangle).
There are currently two versions of Rovers (Rover, SuperRover). The SuperRover is capable of moving two steps per move forward, the Rover is capable of one step per move forward.
The program currently operates with Collision detection and Plateau boundary checks.

## License

This project is licensed under the GNU GENERAL PUBLIC LICENSE Version 3 - see the LICENSE.md file for details
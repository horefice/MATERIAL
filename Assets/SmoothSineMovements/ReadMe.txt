
WHAT DOES IT DO:
This Asset features a very simple Script that can smoothly manipulate the Position, 
Rotation or Scale of an GameObject in the same manner as a sine curve.

USAGE:
1.  Just install the .unitypackage like any other by double-clicking it.
2.  After that import all the Assets.
3.  Attach a "SmoothSineMovement" Script to any GameObject.
4.  You will then be presented my custom Inspector, in here just click "Add movement".
5.  Now you see all possible options for a single movement,
    First select the Axis dropdown and select the Axis you want to manipulate,
    this includes the xyz of the position, rotation and scale.
6.  You can then adjust the max. amplitude
    The maximal amplitude defines what the highest point of acceleration is
7.  Now you can modify the frequency
    The Frequency or wavelength defines how long the distance between
    acceleration and decceleration is
8.  Sometimes you may want to play around with the min. amplitude
    The minimal amplitude is the lowest value your speed can get (default: -10000)
9.  The X-Modifier
    The X-Modifier determines the starting point of the animation,
	it pretty much works like a delay in the animation
    I would leave it at 0 if I was you.
10. Absolute
    The Absolute Boolean defines whether it can grow negatively
    If set to true then it will act like a static object and will bounce positively
    and negatively from the starting position
    If set to false it will only grow positively and back to its origin.
    And by the way, no I didn't mess these two up.
    "Absolute" refers to "absolute position", if its set to true it will select the current
    configuration as it's middle, if set to false then it will kinda act freely.
11. No Negatives
	Now this one actually works like Mathf.Abs(),
	this means that all numbers will be absolutes (no negative values such as -1)
12. The "Delete" and "Copy" Button are pretty self-explaining.

Created by TheBusyBiscuit

Twitter: @TheBusyBiscuit
Website: http://TheBusyBiscuit.github.io
Youtube: https://www.youtube.com/channel/UCNpuxll39TkRJdYVkvgrvgQ

Check the LICENSE.txt file for copyright information.
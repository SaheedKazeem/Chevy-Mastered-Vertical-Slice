//////////
//THANKS//
//////////

Hi there, this is Will from unTied Games! Nice to meet you.

Super huge THANK YOU for downloading this asset... It means a lot to me that you've chosen it for your game!
If you use this asset in your game, give me a shoutout if you can at @untiedgames, so I can follow along on your development journey!
Want to follow me? Sign up for my newsletter! Or follow me using the Twitter / FB / Youtube links below.
Newsletter signup: http://untiedgames.com/signup

Did you know? You can get access to ALL of my assets if you support me on Patreon!
Check it out: http://patreon.com/untiedgames
You read that right! At the $10 tier, you can get access to ALL of my assets. Not your cup of tea? At the $5 tier, you can get access to all my assets that are 1 year old or more. There's also a lot more than just pixel art... I make Youtube videos, indie games, development logs, and more!

MORE LINKS:
Browse my other assets: untiedgames.itch.io/
Watch me make pixel art, games, and more: youtube.com/c/unTiedGamesTV
Follow on Facebook: facebook.com/untiedgames
Follow on Twitter: twitter.com/untiedgames
Visit my blog: untiedgames.com

Thanks again,
- Will

///////////////////
//VERSION HISTORY//
///////////////////

Version 2.0 (5/9/21)
	- Added GUI2PNG tool, so you can create your own premade custom-size window/button PNGs!
	- Added 25 premade window/button sizes.
	- Added Unity-ready 9-slice and 3-slice images. See unity/readme_unity.txt.

Version 1.0 (10/11/19)
	- Initial release

/////////////////////////
//HOW TO USE THIS ASSET//
/////////////////////////

Hello! Thank you for downloading the Candy Pixel Art GUI. Here are a few pointers to help you navigate and make sense of this zip file.

// USING PREMADES AND GUI2PNG (v2.0 update)

This update adds 25 premade window and button sizes that are ready to drag-and-drop into your app. They're located in the premade folder.
Note: You'll find slider scrubbers and window arrow pointers where they were in v1.0, in the non-premade window folder.

If you can't find a size that works for you, try out the included GUI2PNG tool:
First, extract the folder inside the asset pack zip file.
Next, open up a command prompt, navigate to the asset pack folder, and try commands like the following.

GUI2PNG Usage: gui2png width height [-type window | button] [-style style_name] [-match prefix]
Examples:

- Make 200x100 PNGs of everything:
        gui2png 200 100

- Make 200x100 PNGs of only the windows:
        gui2png 200 100 -type window

- Make 200x100 PNGs of only the buttons:
        gui2png 200 100 -type button

- Make 200x100 PNGs of everything in the light style:
        gui2png 200 100 -style light

- Make 200x100 PNGs of only the window/light/panel nine-slice:
        gui2png 200 100 -type window -style light -match panel

Note: Some elements like sliders, meters, and rules can only expand either horizontally or vertically.
      Those elements will expand in the direction they can expand in based on the input dimensions, and be a fixed size in the other direction.

// USING THE 9-SLICES MANUALLY (UNITY)

Use the files in the unity folder. See unity/readme_unity.txt.

// USING THE 9-SLICES MANUALLY (NON-UNITY)

I recommend becoming familiar with nine-slices. Read more here: https://en.wikipedia.org/wiki/9-slice_scaling
Buttons, windows, and panels are split into nine "slices." Imagine a 3x3 grid. You can name each grid square as follows: top-left, top-center, top-right, center-left, center, center-right, bottom-left, bottom-center, and bottom-right. You'll notice a lot of files in this zip have names like that! Now, imagine you stretch that 3x3 grid. Imagine that the corner pieces stay the same size, and all other pieces stretch to fit. That's nine-slice scaling! The Wikipedia page linked above has a great picture illustrating this.

// GENERAL

- In the root folder, you will find four folders. These folders correspond to each component type of the GUI.

- "button" folder: In this folder you will find all buttons, sorted by color theme. In each folder...
	- There are nine-slice buttons here that you can use to create any size of button.
	- There are also premade buttons of sizes 12x12, 16x16, and 24x24.
	- Buttons have three states. You can see them in the filenames.
		- Up: The normal state of the button.
		- Over: The mouseover state of the button.
		- Down: The pressed state of the button.
	- Checkboxes are also in this folder. Please see the icons folder for checkmark-related graphics.

- "icons" folder: Contains all icons included in the asset pack.
	- In this folder you will find two subfolders, "outlined" and "simple". Choose the icon style you want!
	- In either style folder, you will find icons sorted by color theme.
	- To use them with the buttons in your program, simply draw the icon on top of the button.

- "notification" folder: Contains some bonus notification graphics.

- "window" folder: In this folder you'll find all window-related graphics, sorted by color theme. In each folder...
	- The following nine-slice graphics are included:
		- Window
		- Undecorated window (no title bar)
		- Header panel (2 styles per color theme)
		- Panel (includes arrow point to attach to sides)
		- Subpanel (includes arrow point to attach to sides)
		- Area (includes "over" state and optional resizable bottom-right corner)
		- Subarea (includes "over" state and optional resizable bottom-right corner)
		- Scrollbars, progress meters, horizontal and vertical rules
	- Scrollbar graphics are in this folder. These are three-slices, which means you can scale or repeat the middle piece to make the element any length.
	- Scrollbar scrubbers and slider scrubbers are also here. Like buttons, they have up/over/down states.
	- Progress meters and horizontal/vertical rules are also included in this folder. These are three-slices, which means you can scale or repeat the middle piece to make the element any length.

- Be sure to check out the included example images to see how to put the GUI together.

Any questions?
Email me at contact@untiedgames.com and I'll try to answer as best I can!

-Will

/////////////
// CREDITS //
/////////////

The GUI2PNG tool uses the libpng library. Attribution and copyright: http://www.libpng.org/pub/png/src/libpng-LICENSE.txt

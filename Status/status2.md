Video Overview:



Recap of Second 3-Week Plan:

The plan for this 3-week work period involved the continued improvement of the Character Controller and creation
of more advanced Enemy AI. As well as continued work on enemy models and animations, level art creation, 
level design, and implementation of audio resources. Finally, work on menu and UI was to begin.


-   Successes:

    -   Player Controller:

        -	Implementation of character double jump was successfully implemented. Additionally,
			an initial implementation for the tracking of the character's infection rate has begun.
			(\~3 hrs)(CM)

    -   Enemy AI:

        -   Implementation of more advanced enemy AI was successful. This includes implementing the 
			ability for an enemy to jump and to follow the player character over obstacles. This was achieved
			through the creation of a new script AdvancedEnemyAI.cs. AndvancedEnemyAI.cs inherits its attributes
			from EnemyAI.cs and implements other features such as testing when the Enemy is grounded through a boolean
			variable. This prevents the enemy from being able to jump endlessly. Trigger event functionality
			was also implemented into AndvancedEnemyAI.cs to assist in determining when an enemy is grounded
			and to assist in the Advanced Enemy in moving over obstacles. These trigger events utilize CircleColliders2D
			configured to act as a trigger. (\~8 hrs) (CM)

    -   Main Menu:

        -	Main Screen was implemented and the have 3 options to choose from : New Game, Options and Quit Game. This was also added to the overall build setting.(\~4 hrs)(SM) 
		
	-   Pause Menu:

        -	Pause Menu was implemented to use ESC key to pause the game during gameplay mode.(\~2 hrs)(SM)

    -   Audio:

        -	Audio files and AudioManager implemented. (\~4 hrs)(KO)  
	
	-	Art & Animation:

		-	Learned how to use skeletal animation and implemented it in enemies with shopping
			carts, this should cut back on time spent creating animations. At this resolution 
			skeletal animations don’t seem to maintain quite as much detail as animations made 
			with a sprite sheet, but simple animations can be created in a matter of minutes; 
			considering the hours needed to create a decent sprite sheet followed by the hours 
			of small tweaks and copious amounts of trial and error needed to fix graphical 
			inconsistencies, I’d say the time lost in learning how to implement skeletal 
			animations will pay off in the long run. (\~16 hrs)(GB)
			
			STRUGGLES: To the surprise of no one, implementing skeletal animations in Unity was 
			neither easy nor intuitive. It turns out that most of the functionality used in the 
			sprite editor to create the skeletal frame, like the preservation of separate layers,
			just doesn’t work unless you’re using a specific photoshop file type called a PSB, 
			which is just a standard photoshop file PSD but big. For some reason the package used
			to import PSB files for use in the sprite editor is named 2D PSD Importer, the 2D PSD
			Importer does not handle PSD files. Considering PSB files are only really used for 
			projects too big to be saved as a PSD ( > 2GB ), the 2D PSD Importer’s inability to import 
			PSD files makes about as much sense as naming the package after a file type it doesn’t
			support. This is only made more frustrating by the fact that PSB is one of the only 
			image file types that is not yet supported by Photoshop’s open source alternative — GIMP.
			After an unfortunate amount of research and trial and error, I just renamed the PSD I 
			exported from GIMP as a PSB and it worked perfectly. While the solution to the problem 
			is simple, the file types being so similar that Unity can’t tell the difference between
			a file actually saved in the PSB format and a PSD file renamed as a PSB just makes it all
			the more frustrating that PSD files aren’t supported. 

		-	Animation controller for enemy configured to allow for an idle and walk animation, plus
 			tweaks to the animations themself. (\~3 hrs)(GB)

		-	Created tile assets for SuperMarket. (\~2 hrs)(GB)
		
		-	Implemented an animation flip for the enemy characters. (\~1 hrs)(GB)

		-	Started to explore the idea of level lighting and started some early lighting implementation. 
		 	(\~1 hr)(GB) 
			
		-	Enemy collision box no longer gets suck on the ground and the player collision box no longer
			pushes the shopping cart collision box down into the ground when walking against it. 
			(\~0.5 hrs)(GB)
<!-- -->

-   Challenges:

    -   One challenge that we are all facing is the challenge of working
        remotely. Working remotely adds more challenges to a typical
        workflow and adds more time to a project.

    -   The Unity learning curve is another challenge that we continue to face during 
		work on our project.

    -   Time Constraints are another challenge as all in this group try
        to balance jobs and other senior level classes while trying to
        work on this senior design project. As the semester goes on, other classes
		get more busy making it harder  to contribute to this project at the same rate.

    -   Making a game is hard and it takes time with only 4 people.
	
	-   Due to this being the midterm month, individuals were busy with other courseworks and did not have enough time to contribute to this project.
	
	- Level 2 need more time as assets needs to be build for that level.

    

Goals for Mar 10 - Mar 31


-   Art & Animation:
	-	TODO: Add more enemy varients and animations. (GB)
	-	TODO: Create a more modular enemy sprite project with lighter, neutral colored hair and shirts
		separated into their own layers so that they can be colorized in Unity's sprite renderer for 
		quick and easy non-player character diversification. (GB)
	-	TODO: Clean up existing animations. (GB)
	-	TODO: Create more assets for the Super Market level. (GB)
   
-   Audio:
    -   TODO: Add more audio files, and make sure sound effects will persist through scene transitions. (KO)

	
-   Level Design: 
    -   TODO: Need to work on Level 2 and need to add more artifacts to the level design so they look more fleshed out. (SM)


-   Character Controller:

    -   TODO: Continue to fine-tune the Character Controller to make it
        the best it can be. (CM)
		
	- 	TODO: Creation of a script to track health/infection rate of the player character. (CM)


-   Enemy AI:

    -   TODO: Creation of NPC characters that will attempt to move away
        from the character or any enemy. (CM)
		
	-	An enemy "attack" script. (CM) 

-   UI Design: 
    -   TODO: Need to make a more elaborate version of the Main Menu and Pause Menu as well as add more functionality to the Options Menu as well as a Level Select Option.(SM)


Confidence Level for Completion
---------------------------------
  Chance-3
  
  Gage-4
  
  Sid-4
  
  Kaden-4
  
  Average:-4

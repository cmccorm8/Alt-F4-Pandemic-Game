Video Overview:
---------------------------------
The link :



Recap of 4th 3-Week Plan:
---------------------------------

The plan for this 3 week period included: Work on more art and animation assests. Make progress toward compeletion of supermarket level.
Continue work on level and UI design. Implement an enemy agro range to prevent enemies from all over the map from swarming the player. Additional work on the NPC AI.  


Successes:
---------------------------------

    -   Enemy AI:

        -  	Implementation of enemy agro utilizing unity cirlce colliders to determine when the player has entered or exited the circle collider. 
		When the player enters the collider, the enemy will begin pursuit. When the player exits the collider, the enemy will stop pursuit.(\~4 hrs) (CM)

    -   UI:
        Added a more complex version of the Options part of the menu i.e. included a way to change resolution, tweak with graphical settings as well as volume control. (\~5 hrs)(SM)
    
	-   Level:
	    Made a new level called the market with some illumination elements.  (\~4 hrs)(SM)

    -   Audio:
    	- 	Additional audio implemented. (\~3 hrs)(KO)
    
    -   Art and Animation:

        -	Created a female NPC and walking animation. Started working in a higher resolution for character sprites to give 
		more control over the details of the texture and lessen blury artifacts created around the character during rigged
		animations. (\~8 hrs)(GB)
		
        -	Used the GIMP project file for the female NPC to create a templated way to add variations for the female NPCs. Currently
		this includes 3 hair, 4 shirt, 2 skintone, and 2 pants variants as well as masked and unmasked options. (\~5 hrs)(GB)
		
        -	After discovering the lack of ease with which one can replace the prefab root of a game object while maintaining that 
		object's component information, my plans for easily swapped out sprites for simililarly sized and animated characters
		became less feasable. So I had to add this functionality into unity myself, I added a tool that allows you to select a 
		prefab and then select any number of game objects and replace the prefabs of these game objects with one of your choosing.
		While it maintains the component information of my female NPCs, it is by no means a universally applicable solution for this
		problem, this is because Unity also lacks the simple functionality of being able to copy components from object to another 
		through scripting. Because of this, only the component information that I knew needed copied over in my female NPC templates
		are preserved by this script after an objects prefab has been changed. (\~3.5 hrs)(GB)
		
        -	Created some level assets for supermarket. (\~0.5 hrs)(GB)



Challenges:
---------------------------------

    -   One challenge that we are all facing is the challenge of working
        remotely. Working remotely adds more challenges to a typical
        workflow and adds more time to a project.

    -   The Unity learning curve is another challenge that we continue to face during work on our project.

    -   Time Constraints are another challenge as all in this group try
        to balance jobs and other senior level classes while trying to
        work on this senior design project. As the semester goes on, other classes
		get more busy making it harder  to contribute to this project at the same rate.

    -   Making a game is hard and it takes time with only 4 people.
    
    -	Working with free assets is kind of restrictive and making new art as a beginner is almost impossible without dedicating a good amount of your time.
    
    -	This iteration was a short one, so less work was completed.
	
	

    

Goals for Mar 31 - April 21:
---------------------------------

-   Art & Animation:

    - TODO: Create more assets for level design, specifically for the super market (GB)
   
-   Audio:
    - TODO: Continue adding audio as additional scenes/events are added (KO)
	
-   Level Design: 
    
    - 	TODO: Make significant progress towards the completion of the super market level (GB)
    
	- 	TODO: Make the last level and finalize the game. (SM)

-   Character Controller:

    -   TODO: Implement the ability for the character to collect items on the level (CM)
		
	
-   Enemy AI:

    -	TODO: Add Patrol behavior to Enemy for when the enemy has not "seen" the player. 

-   UI Design: 
    
	-	TODO: Add better UI elements to the interface part of the game. As of right now, they perform the task they are meant to but look visually unappealing. (SM) 
	
    


Confidence Level for Completion:
---------------------------------
  Chance-3
  
  Gage-4
  
  Sid-4
  
  Kaden-4
  
  Average:-4

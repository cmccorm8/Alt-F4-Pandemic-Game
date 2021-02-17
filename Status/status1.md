Video Overview:

https://youtu.be/-nUdGaKtVZw

Recap of Initial 3-Week Plan:

The plan for the initial 3-week work period involved Implementation of
player movement, and implementation of Enemy AI and Movement.
Additionally, experimentation with the creation of health bars was to be
conducted.

-   Successes:

    -   Player Controller:

        -   Player Movement was implemented via a custom character
            controller script, CharacterController2D.cs. There are many
            character controllers that are readily available. However,
            we felt it best to create our own custom character
            controller to get exactly what we wanted out of player
            movement, as well as for our own learning experience. (CM)

        -   Player animation transitions were also implemented into the
            Character Controller allowing for transitions to occur at an
            appropriate time. For instance, if the player\'s speed is
            less than 0.01f and the player is not jumping, then the
            player should be in an idle state, and the player\_idle
            animation should be occurring. All potential transition cues
            from the animator had to be coded into the Character
            Controller. The time spent implementing player movement and
            animation transitions into the character controller was \~ 9
            hrs, and \~150 lines of code.(CM)

    -   Animations:

        -   The animations that were incorporated into the demo video
            for the first semester's presentation were completely
            implemented into the current version of the game. (GB)

        -   Partial jump showcased in the demo was completed and
            implemented into the game. (\~3-4 hours) (GB)

        -   Supermarket level prototype with roughly animated prototype
            of an enemy with a shopping cart. (\~4-5 hours) (GB)

    -   Enemy AI:

        -   Utilizing the free version of the A\* Pathfinding Project
            that can be found at
            [[https://arongranberg.com/astar/]{.underline}](https://arongranberg.com/astar/),
            basic enemy AI has been implemented. At this point, an enemy
            will find the shortest path to take to the player and move
            towards them. The time spent implementing a basic enemy
            pathfinding AI was \~6hrs and \~ 80 lines of code. (CM)

    -   Sound Sourcing:

        -   Acquired the audio files for footsteps, jumping, getting
            hit, level ambience, and sound queues for the pause and main
            menu. (KO)

    -   Level Design :

        -   Demo level was designed using Tilemaps and implemented so as
            to test the game as a whole and see if there were any issues
            with anything.The level also has a global light illumination
            system so as to make it more realistic. (4-6 hrs) (SM)

    -   UI elements :

        -   Health Bar was implemented in the game using little bit of
            coding around 50 lines.(1-2 hrs) (SM)

<!-- -->

-   Challenges:

    -   One challenge that we are all facing is the challenge of working
        remotely. Working remotely adds more challenges to a typical
        workflow and adds more time to a project.

    -   The Unity learning curve is another challenge that we faced
        during this first iteration of our project. None of us have ever
        used Unity before and with that comes the challenge of trying to
        create a game while learning Unity.

    -   Time Constraints are another challenge as all in this group try
        to balance jobs and other senior level classes while trying to
        work on this senior design project.

    -   Making a game is hard and it takes time with only 4 people.

    -   Creating the video for this update period took away potential
        time for us to make progress on our project.

    -   Health Bar has issues with working properly because as of right
        now, it works independent to that of the main character and does
        not seem to be following the main camera.

Goals for Feb 17 - Mar10

-   Enemy models and animations

-   Pause Menu

-   Starting Screen

-   Implement level 1 ambient audio, character/enemy movement and death
    audio (KO)

-   Animations:

    -   TODO: Complete and implement a landing animation (GB)

    -   TODO: Create enemy sprites (GB)

-   Art:

    -   TODO: Create supermarket backdrop (GB)

    -   TODO: Create supermarket exterior (GB)

-   Level Design:

    -   TODO: Start work on supermarket level (level 2?) (GB)

    -   TODO: Fully fleshed out Level 1 (SM)

    -   TODO : Work on a Pause Menu and a Start Menu. (SM)

-   Character Controller:

    -   TODO: Continue to fine-tune the Character Controller to make it
        the best it can be. (CM)

    -   TODO: Implement a double-jump feature. (CM)

-   Enemy AI:

    -   TODO: Continue to fine-tune the Enemy AI. (CM)

    -   TODO: Creation of more advanced enemies with more advanced
        abilities. (CM)

    -   TODO: Creation of NPC characters that will attempt to move away
        from the character or any enemy. (CM)

-   Confidence Levels

  Name       Confidence Level for Completion
  ---------- ---------------------------------
  Chance     3
  
  Gage       ?
  
  Sid        ?
  
  Kaden      ?
  
  Average:   ?

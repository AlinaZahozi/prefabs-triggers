# Alina's spaceship

The game was built as part of an assignment in a computer game development course.

* [Click here to play on itch.io](https://alinaandyuval.itch.io/alinas-spaceship)

The purpose of the assignment is to teach about prefabs and triggers:

![image](https://github.com/Computer-game-development-course/Alina_Prefabs_And_Triggers/assets/93255163/a537b04e-db28-4f0f-8f87-ca84cc6d8d96)

**Explanation:** This is the game login screen. The player sees an illustration of a spaceship shooting a laser and can start playing by pressing the "Start Play" button with the mouse.
Once clicked the button will shrink and grow accordingly to simulate a physical action of pressing a button. Of course, after that the player is transferred to the main screen of the game.


![image](https://github.com/Computer-game-development-course/Alina_Prefabs_And_Triggers/assets/93255163/eb9f3c9e-7aed-4b3f-9c67-fd73170ef835)

**Explanation:** This is the main screen of the game - where all the core processes take place:

* The player has to shoot the enemy with his laser beam (by pressing the spacebar on the keyboard).
* The player can move down/up/right/left by the arrow keys on the keyboard.
* Each player starts with 3 hearts that indicate the amount of life he has left, i.e. how many more disqualifications he can make. Every time the enemy touches the spaceship one heart drops until the hearts run out and the player loses.
* The arrow on the upper right shows the player where he must reach with the spaceship in order to win.
* Shield - during the game the player can collect shield bubbles that will protect him for 5 seconds from the enemy, during which time the player will not have any lives.
* "X4" Bubble - During the game the player can collect these bubbles which multiply the spaceship's laser by 4 times for only 5 seconds.
* When the player arrives with the spaceship in the direction the arrow points to in life, he has won the game and is taken to the victory screen.
* If the player is disqualified before arriving with the spaceship in the direction the arrow is pointing, he has lost the game and is transferred to the try again screen.


![image](https://github.com/Computer-game-development-course/Alina_Prefabs_And_Triggers/assets/93255163/622c2239-7012-47dc-8ac4-8bef708765ec)

**Explanation:** This is the victory screen. The screen shows the player that he has won the game and offers to play again by pressing the "Play Again" button with the mouse.
Once clicked the button will shrink and grow accordingly to simulate a physical action of pressing a button. Of course, after that the player is taken back to the main screen of the game to play again.


![image](https://github.com/Computer-game-development-course/Alina_Prefabs_And_Triggers/assets/93255163/596b563d-86f1-4ff2-93b1-381212256637)

**Explanation:** This is the total loss. The screen shows the player that he has lost the game and offers to play again by pressing the "Play Again" button with the mouse.
Once clicked the button will shrink and grow accordingly to simulate a physical action of pressing a button. Of course, after that the player is taken back to the main screen of the game to play again.


* **One change from the list -** the change I chose is "the player's spaceship is not destroyed immediately when it collides with the enemy, but at the beginning of the game it has 3 "hit points", each hit to the enemy reduces it by one point, and only when it reaches zero is it destroyed. I did this using the three hearts which I explained in the explanation on the main screen.
* **One original change -** I added features like a shield bubble and an "X4" bubble to the laser which I explained in the explanation on the main screen.

  
**Finding the files on GitHub -**

I gathered all the scenes I added in the "Assignment" folder, you can find it according to the path:
"Alina_Prefabs_And_Triggers/Assets/Scenes/Assignment"

I gathered all the scripts I added in the "Assignment" folder, you can find it according to the path:
"Alina_Prefabs_And_Triggers/Assets/Scripts/Assignment"

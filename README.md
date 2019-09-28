# Internship Intake Assignment
Unity (V2019.1.10f1) project of my internship intake assignment for a Virtual Reality Game Development company based in the Netherlands.
This project makes use of Unity's new Input System which is something I had never done before. The entire project is created in 3 days of development time.

# The task
Implement an equipment system for the management of items in a player's hands.
Develop this equipment in the language of your choice.

# Explanation
A player has two hands and items can be equipped to  each hand. Items can have different functions, but most of them should be usable in a similar fashion (example: a button on a controller). Items can include weapons or static objects. The player also has a head on which certain items can be equipped, but those cannot be used.

The quality of graphics and animation is of no importance, as long as the system is demonstrated. Your implementation should at least contain the following **items**:

* **Gun**: The gun can contain an ammo-clip which contains the bullets which will be shot by the gun. It should be possible to fire the gun in single mode or full automatic mode. 
* **Ammo-clip**: The ammo-clip has a collection of bullets. Using the ammo-clip in one hand while a gun is equipped in the other hand should reload that gun and consume the ammo-clip.
* **Flashlight**: It should be possible to turn the flashlight on or off.
* **Rock**: Using the rock should throw it and the rock will be unequipped in the process.
* **Hat**: The hat can also be equipped on the head.

# Bonus Task
Implement a system for the player to interact with objects that cannot be equipped by using his hands. Examples are: opening a door, switching a lever, turning a key, press a button.
Deliver your solution both in code and in a working executable form.

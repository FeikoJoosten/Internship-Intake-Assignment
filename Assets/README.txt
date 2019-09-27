Vertigo Games - Intake assignment:

C͟o͟n͟t͟r͟o͟l͟s͟
	Movement:
		Forwards: W key
		Backwards: S key
		Left: A key
		Right: D key

	Looking around:
		Rotate your mouse

	Left hand usage:
		Left mouse button

	Right hand usage:
		Right mouse button

	Equipment screen toggle:
		if closed: Tab key to open
		if opened: Tab key to close

G͟e͟n͟e͟r͟a͟l͟ I͟n͟f͟o͟r͟m͟a͟t͟i͟o͟n͟
	If an item is equipped in the left or right hand, and the related input is triggered (left or right mouse button), the item is used.
	If no item is equipped in the left or right hand, and the related input is triggered (left or right mouse button), you can interact with items in the world.

D͟o͟c͟u͟m͟e͟n͟t͟a͟t͟i͟o͟n͟
	All public functions throughout the codebase have comment using the XML format.
	All SerializeField variables throughout the codebase have tooltips using the Tooltip attribute.
	
S͟c͟r͟i͟p͟t͟a͟b͟l͟e͟O͟b͟j͟e͟c͟t͟s͟
	Each scriptable object can be created by using the create context menu (Create --> Scritable Objects --> XData)

	AmmoData:
		The ammo data scriptable object allows you to define some key settings for the AmmoClip class. For example the clip size, and wheter you can use that clip infinitely.

	BulletData:
		The bullet data scriptable object allows you to define some key settings for the Bullet class. For example the movement speed of the bullet prefab.

	GunData:
		The gun data scriptable object allows you to define some key settings for the Gun class. For example the fire distance of the gun (if using raycast mode), or the reload time.
		The gun data scriptable object also contains information regarding which AmmoTypes can be used to reload a gun with.

	RockData:
		The rock data scriptable object allows you to define some key settings for the Rock class. For example the throw speed of the rock.

	WeaponData:
		The weapon data scriptable object is a parent class for the GunData and the RockData. It allows you to define the damage of the weapon.

	PlayerData:
		The player data scriptable object allows you to define some key settigns for the Player class. For example the starting health of the player, but also settings regarding the controls.

I͟t͟e͟m͟s͟
	Equippables:
		Some items are equippables, whenever you interact with those items, they will be added onto the interactor's inventory. 
		If the auto-equip option is enabled, the interacted item will automatically be equipped onto any available body part which can accept that item type.

		Each equippable has a value that allows them to define the body parts they can be equipped onto. See the variable Available Body Types.

		The following items have valid equip conditions:
			- Hat
				This item is purely visual. It doesn't have any interactions and can only be equipped and unequipped.
			- AmmoClip
				This item is used to reload a gun if it is held onto another body part. However, before the gun is reloaded, the gun confirms if the supplied AmmoData is valid for this gun.
			- Flashlight
				This item will toggle the active status of an attached LightComponent whenever the item is used.
			- Gun
				This item will fire using a raycast to try and detect IDamageables. If an IDamageable is found, it'll apply some damage onto the IDamageable based on the GunData.
				If the AmmoData assigned onto the gun has a Bullet prefab assigned, the fire method will use a projectile instead. This projectile will use the OnCollisionEnter to damage IDamageables.
			- Rock
				This item will throw itself forwards with a force that is calculated based on the throw speed defined in the RockData.
				If the canUseInfinite value is set to true, the rock will not be removed from the players body part, but will create a new instance instead.

	Interactables:
		Some items are interactables, whenever you interact with those items they will invoke their OnInteracted function. Which in term will for example play an animation.

		The following items have valid interact conditions:
			- Button
			- Door
			- Key
			- Lever

E͟q͟u͟i͟p͟m͟e͟n͟t͟ S͟c͟r͟e͟e͟n͟
	You can use the equipment screen to select body parts.
	Once a body part is selected, you'll see a list of items currently in your inventory that could be equipped onto the selected body part. 
	If you equip a new item onto the selected body part, the previous item is replaced with the new item. 
	Next to the item selection there is a drop button. Clicking this button will remove the item from the players inventory and place the item in the world. (Only the items of the types AmmoClip and Rock currently properly support this).
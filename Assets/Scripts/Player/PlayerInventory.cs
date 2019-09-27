using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
	[SerializeField]
	[Tooltip("This value allows you to define if you want to auto equip items whenever they have been added into your inventory. Auto-equip will only happen if the bodypart types for the added item have no items assigned onto it.")]
	private bool autoEquipItems = true;
	[SerializeField]
	[Tooltip("This value allows you to start the game with a couple of items already in the players inventory.")]
	private Item[] startingInventoryItems = null;
	[SerializeField]
	[Tooltip("This value allows you to assign an item onto the left hand of the players body. It'll automatically add the item to the inventory.")]
	private Item startingLeftHandItem = null;
	[SerializeField]
	[Tooltip("This value allows you to assign an item onto the right hand of the players body. It'll automatically add the item to the inventory.")]
	private Item startingRightHandItem = null;
	[SerializeField]
	[Tooltip("This value allows you to assign an item onto the head of the players body. It'll automatically add the item to the inventory.")]
	private Item startingHeadItem = null;

	private List<Item> inventory = new List<Item>();
	public List<Item> Inventory => inventory;
	private Player player; // Player has us listed as a require component
	public Player Player => player;

	private void Awake() {
		player = GetComponent<Player>();

		foreach (Item item in startingInventoryItems) {
			AddItem(item);
		}

		EquipStartingItem(startingLeftHandItem, typeof(LeftHand));
		EquipStartingItem(startingRightHandItem, typeof(RightHand));
		EquipStartingItem(startingHeadItem, typeof(Head));
	}

	private void EquipStartingItem(Item itemToEquip, System.Type bodypartToUse) {
		AddItem(EquipItem(itemToEquip, bodypartToUse), true);
	}

	/// <summary>
	/// This function allows you to add an item to the players inventory.
	/// If autoEquipItems is set to true, this object will automatically equip the item onto an available bodypart.
	/// This function will automatically convert prefabs into scene objects.
	/// </summary>
	/// <param name="itemToAdd">The item you want to add to this players inventory.</param>
	/// <param name="ignoreAutoEquip">This allows you to override the auto equip of this function.</param>
	public void AddItem(Item itemToAdd, bool ignoreAutoEquip = false) {
		if (itemToAdd == null)
			return;

		if (itemToAdd.gameObject.scene.IsValid() == false) {
			itemToAdd = Instantiate(itemToAdd, itemToAdd.transform.position, itemToAdd.transform.rotation, transform);
			itemToAdd.gameObject.SetActive(false);
		}

		inventory.Add(itemToAdd);
		itemToAdd.transform.SetParent(transform);

		if (autoEquipItems == false || ignoreAutoEquip) return;

		itemToAdd.gameObject.SetActive(false);

		foreach (TypeReferences.ClassTypeReference bodyType in itemToAdd.AvailableBodyTypes) {
			if (player.Body.GetBodyPart(bodyType).EquippedItem != null) continue;

			player.Body.GetBodyPart(bodyType).EquipItem(itemToAdd);
			break;
		}
	}

	/// <summary>
	/// This function removes the defined item from the players inventory.
	/// If the item is currently equipped, the item will be unequipped.
	/// After removing the item from the players inventory, the OnDropped function of the item will be invoked.
	/// </summary>
	/// <param name="itemToRemove">The item you wish to remove from the players inventory.</param>
	public void RemoveItem(Item itemToRemove) {
		if (itemToRemove == null)
			return;

		BodyPart relatedBodyPart = player.Body.GetBodyPartFromEquippedItem(itemToRemove);
		if (relatedBodyPart != null) {
			relatedBodyPart.EquipItem(null);
		}

		inventory.Remove(itemToRemove);
		itemToRemove.OnDropped();
	}

	/// <summary>
	/// This function allows you to clear the equipped item from a bodypart.
	/// </summary>
	/// <param name="bodyPartToClear">The bodypart type you wish to clear.</param>
	public void UnequipItemFromBodypart(System.Type bodyPartToClear) {
		EquipItem(null, bodyPartToClear);
	}

	/// <summary>
	/// This function allows you to equip an item onto a bodypart.
	/// This function will NOT add the item onto the players inventory.
	/// </summary>
	/// <param name="itemToEquip">The item you want to equip.</param>
	/// <param name="bodyPartToUse">The bodypart type you wish to equip the item onto.</param>
	/// <returns>Return the item reference on succesfull equip.</returns>
	public Item EquipItem(Item itemToEquip, System.Type bodyPartToUse) {
		if (bodyPartToUse == null) return null;

		return player?.Body?.GetBodyPart(bodyPartToUse)?.EquipItem(itemToEquip);
	}

	/// <summary>
	/// This function allows you to check if an item is currently equiped onto the players body.
	/// </summary>
	/// <param name="itemToCheck">The item you want to check.</param>
	/// <returns>Return true or false based on the is equipped status.</returns>
	public bool IsItemEquippedOnBody(Item itemToCheck) {
		foreach (TypeReferences.ClassTypeReference bodyType in itemToCheck.AvailableBodyTypes) {
			if (player.Body.GetBodyPart(bodyType).EquippedItem == itemToCheck) return true;
		}

		return false;
	}

	/// <summary>
	/// This function allows you to check if an item can be equipped onto the desired bodypart type.
	/// </summary>
	/// <param name="itemToCheck">The item you want to check.</param>
	/// <param name="bodyPartToCheck">The bodypart type you want to check.</param>
	/// <returns>Returns true if this item can be equipped onto the desired bodypart type.</returns>
	public bool CanItemBeEquippedToBodyPart(Item itemToCheck, System.Type bodyPartToCheck) {
		foreach (TypeReferences.ClassTypeReference bodyType in itemToCheck.AvailableBodyTypes) {
			if (bodyType == bodyPartToCheck) return true;
		}

		return false;
	}

	/// <summary>
	/// This function allows you to get a list of items that COULD be equipped onto the defined bodypart type.
	/// </summary>
	/// <param name="bodyPartToUse">The bodypart type you want to use.</param>
	/// <param name="includeEquippedItems">This allows you to include the currently equipped items onto this list.</param>
	/// <returns>Returns the list of items currently in the players inventory that could be equipped onto the defined bodypart type.</returns>
	public List<Item> GetItemsForBodyPart(System.Type bodyPartToUse, bool includeEquippedItems = false) {
		List<Item> availableItems = new List<Item>();

		foreach (Item item in inventory) {
			if (includeEquippedItems == false && IsItemEquippedOnBody(item)) continue;
			if (CanItemBeEquippedToBodyPart(item, bodyPartToUse) == false) continue;

			availableItems.Add(item);
		}

		return availableItems;
	}
}

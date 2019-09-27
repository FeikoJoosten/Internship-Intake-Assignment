using System.Collections.Generic;
using UnityEngine;

public class ItemDisplayer : MonoBehaviour {
	[SerializeField]
	[Tooltip("The prefab used when creating new item slots.")]
	private ItemSlot buttonPrefab = null;
	[SerializeField]
	[Tooltip("The transform at which new items slots will be spawned onto.")]
	private RectTransform itemHolder = null;
	[SerializeField]
	[Tooltip("A reference to the item slot used to define the currently equipped item.")]
	private ItemSlot equippedItemSlot = null;

	private Player owner;
	private System.Type selectedBodyType;

	/// <summary>
	/// This function is used to setup the ItemDisplayer so it knows which player is currently working with this ItemDisplayer and which bodypart type is curently used.
	/// </summary>
	/// <param name="playerRef">The player that is currently using this ItemDisplayer.</param>
	/// <param name="bodyTypeToUse">The bodypart type that is currently used.</param>
	public void Initialize(Player playerRef, System.Type bodyTypeToUse) {
		owner = playerRef;
		selectedBodyType = bodyTypeToUse;
	}

	private void OnEnable() {
		UpdateItemSlots();
	}

	/// <summary>
	/// This function is used to reorganize the list of items in the UI.
	/// Will only spawn new ItemSlots if required.
	/// </summary>
	public void UpdateItemSlots() {
		if (owner == null || selectedBodyType == null || buttonPrefab == null || itemHolder == null)
			return;

		if (equippedItemSlot != null)
			equippedItemSlot.Initialize(owner.Body.GetBodyPart(selectedBodyType).EquippedItem, owner.Inventory, selectedBodyType, this);

		List<Item> availableItems = owner.Inventory.GetItemsForBodyPart(selectedBodyType);

		int count = 0;
		for (; count < availableItems.Count; count++) {
			// Only add a new item to the item holder if needed
			if (itemHolder.childCount <= count) {
				Instantiate(buttonPrefab, itemHolder).transform.SetAsLastSibling();
			}

			ItemSlot itemSlot = itemHolder.GetChild(count).GetComponent<ItemSlot>();
			itemSlot.Initialize(availableItems[count], owner.Inventory, selectedBodyType, this);
			
			// In case we are using a previously disabled object
			itemSlot.gameObject.SetActive(true);
		}

		// Disable the remaining children of itemHolder if required
		for (int i = count; i < itemHolder.childCount; i++) {
			itemHolder.GetChild(i).gameObject.SetActive(false);
		}
	}
}

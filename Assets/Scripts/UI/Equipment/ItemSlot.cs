using UnityEngine;

public class ItemSlot : MonoBehaviour {
	[SerializeField]
	[Tooltip("The button used to (un)equip the assigned item. The item is assigned using code.")]
	private UnityEngine.UI.Button itemButton = null;
	[SerializeField]
	[Tooltip("The button used to drop the assigned item from the players inventory. The item is assigned using code.")]
	private UnityEngine.UI.Button dropButton = null;
	[SerializeField]
	[Tooltip("The text object of the assigned item button. This value is used to update the text to represent the items name.")]
	private UnityEngine.UI.Text text = null;
	public UnityEngine.UI.Text Text => text;

	private PlayerInventory relatedInventory;
	private System.Type relatedBodyType;
	private ItemDisplayer owner;

	private Item assignedItem;
	public Item AssignedItem {
		get { return assignedItem; }
		private set {
			assignedItem = value;

			if (text != null)
				text.text = (assignedItem == null ? "Empty" : assignedItem.name);

			dropButton.gameObject.SetActive(assignedItem != null);
		} 
	}

	/// <summary>
	/// This function allows you to initialize this ItemSlot.
	/// </summary>
	/// <param name="itemToRefer">The Item this ItemSlot refers to.</param>
	/// <param name="inventoryToUse">The players inventory this ItemSlot is currently using.</param>
	/// <param name="bodytypeToUse">The bodypart type this ItemSlot is currently using.</param>
	/// <param name="itemDisplayerToUse">The ItemDisplayer this ItemSlot is a part of.</param>
	public void Initialize(Item itemToRefer, PlayerInventory inventoryToUse, System.Type bodytypeToUse, ItemDisplayer itemDisplayerToUse) {
		AssignedItem = itemToRefer;
		relatedInventory = inventoryToUse;
		relatedBodyType = bodytypeToUse;
		owner = itemDisplayerToUse;
	}

	private void Awake() {
		if (itemButton != null)
			itemButton.onClick.AddListener(OnButtonClick);
		if (dropButton != null)
			dropButton.onClick.AddListener(DropItem);
	}

	private void OnButtonClick() {
		if (relatedInventory == null || relatedBodyType == null) return;

		BodyPart bodyPart = relatedInventory.Player.Body.GetBodyPart(relatedBodyType);

		if (bodyPart == null) return;

		if (bodyPart.EquippedItem == AssignedItem) {
			UnequiSelectedItem();
		}
		else {
			EquipSelectedItem();
		}

		owner?.UpdateItemSlots();
	}

	private void EquipSelectedItem() {
		if (relatedBodyType == null) return;

		relatedInventory?.EquipItem(AssignedItem, relatedBodyType);
	}

	private void UnequiSelectedItem() {
		if (relatedBodyType == null) return;

		relatedInventory?.UnequipItemFromBodypart(relatedBodyType);
		AssignedItem = null;
	}

	private void DropItem() {
		if (relatedBodyType == null) return;

		relatedInventory?.RemoveItem(AssignedItem);
		owner?.UpdateItemSlots();
	}
}

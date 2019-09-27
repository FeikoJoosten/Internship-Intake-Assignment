using UnityEngine;

public class EquipmentScreen : MonoBehaviour {
    [SerializeField]
	[Tooltip("The player that owns this equipment screen.")]
	private Player owner = null;
	[SerializeField]
	[Tooltip("The item displayer used by this equipment screen. A referece is required to reset this object properly whenever the equipment screen is closed.")]
	private ItemDisplayer itemDisplayer = null;
	[SerializeField]
	[Tooltip("The slot selection object used by this equipment screen. A referece is required to reset this object properly whenever the equipment screen is closed.")]
	private RectTransform slotSelection = null;

	/// <summary>
	/// This function allows you to open the equipment screen.
	/// </summary>
	public void OpenEquipmentScreen() {
		gameObject.SetActive(true);
		slotSelection.gameObject.SetActive(true);
	}

	/// <summary>
	/// This function allows you to close the equipment screen.
	/// </summary>
	public void CloseEquipmentScreen() {
		itemDisplayer.gameObject.SetActive(false);
		slotSelection.gameObject.SetActive(false);
		gameObject.SetActive(false);
	}

	/// <summary>
	/// This function will setup the ItemDisplayer with the bodypart type LeftHand.
	/// </summary>
	public void SelectLeftHandScreen() {
		SelectBodypart(typeof(LeftHand));
	}
	
	/// <summary>
	/// This function will setup the ItemDisplayer with the bodypart type RightHand.
	/// </summary>
	public void SelectRightHandScreen() {
		SelectBodypart(typeof(RightHand));
	}

	/// <summary>
	/// This function will setup the ItemDisplayer with the bodypart type Head.
	/// </summary>
	public void SelectHeadScreen() {
		SelectBodypart(typeof(Head));
	}

	private void SelectBodypart(System.Type bodypartToUse) {
		if (owner == null || itemDisplayer == null) return;

		itemDisplayer.Initialize(owner, bodypartToUse);
		itemDisplayer.gameObject.SetActive(true);
	}
}

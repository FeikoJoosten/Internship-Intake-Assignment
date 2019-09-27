using UnityEngine;

public class Flashlight : Item {
	[SerializeField]
	[Tooltip("This is the light component required by this object. It is used when this item is used. Nothing'll happen if this value is not assigned.")]
	private Light lightComponent = null;

	/// <summary>
	/// This function toggles the active status of the light component.
	/// </summary>
	public override void UseItem() {
		if (lightComponent == null) return;

		lightComponent.enabled = !lightComponent.enabled;
	}
}

using UnityEngine;

public class AmmoClip : Item {
	[SerializeField]
	[Tooltip("This is the ammodata object that'll be used with this AmmoClip")]
	private AmmoData data = null;

	private Rigidbody rigidBody = null;

	private void Awake() {
		rigidBody = GetComponent<Rigidbody>();
	}

	/// <summary>
	/// This function disables the rigidbody if attached onto this object and initializes the owner of this object.
	/// Will auto-equip if possible.
	/// </summary>
	/// <param name="newOwner">The new owner of this object.</param>
	public override void OnEquip(Player newOwner) {
		base.OnEquip(newOwner);

		if (rigidBody)
			rigidBody.isKinematic = true;
	}

	/// <summary>
	/// This function enables the rigidbody if attached onto this object and clears the owner of this object.
	/// Will enable this object whenever it's dropped.
	/// </summary>
	public override void OnDropped() {
		base.OnDropped();

		if (gameObject.activeInHierarchy == false)
			gameObject.SetActive(true);

		if (rigidBody)
			rigidBody.isKinematic = false;
	}

	/// <summary>
	/// This function will reload a weapon if the player is holding it in the other hand.
	/// The weapon will only be reloaded if the weapon supports this ammo type. (Based on the AmmoData).
	/// </summary>
	public override void UseItem() {
		if (data == null || owner == null) return;

		BodyPart gunHolder = owner.Body.GetBodyPartFromEquippedItemType(typeof(Gun));
		Gun gunToReload = (Gun) gunHolder?.EquippedItem;

		if (gunToReload == null) return;
		if (gunToReload.IsAmmoSupported(data) == false) return;

		if (gunToReload.Reload(data) == false || data.CanUseInfinite) return;

		owner.Inventory.RemoveItem(this);
		Destroy(gameObject);
	}

	/// <summary>
	/// This method allows you to pickup the item in case it's laying on the ground.
	/// </summary>
	/// <param name="initiator">The object that invoked this function.</param>
	public override void OnInteract(GameObject initiator) {
		if (rigidBody != null)
			if (rigidBody.IsSleeping() == false) return;

		base.OnInteract(initiator);
	}
}

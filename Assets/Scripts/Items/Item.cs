using UnityEngine;
using System.Collections.Generic;

public class Item : MonoBehaviour, IInteractable {
	[SerializeField]
	[Tooltip("This value allows you to define the bodypart types this item can be attached onto.")]
	[TypeReferences.ClassExtends(typeof(BodyPart))]
	protected List<TypeReferences.ClassTypeReference> availableBodyTypes = null;
	public List<TypeReferences.ClassTypeReference> AvailableBodyTypes => availableBodyTypes;

	protected Player owner;

	public virtual void UseItem() { }

	public virtual void StopUseItem() { }

	/// <summary>
	/// This function assigned the owner of this object.
	/// </summary>
	/// <param name="newOwner">The new owner of this object.</param>
	public virtual void OnEquip(Player newOwner) {
		owner = newOwner;
	}

	/// <summary>
	/// This function will disable this gameobject in case it has been unequipped from a bodypart.
	/// </summary>
	public virtual void OnUnEquip() {
		gameObject.SetActive(false);
	}

	/// <summary>
	/// This function will clear the owner of this object and set the transform of this object to null.
	/// </summary>
	public virtual void OnDropped() {
		owner = null;
		transform.SetParent(null, true);
	}

	/// <summary>
	/// This function allows the initiator to pickup the item.
	/// </summary>
	/// <param name="initiator">The object that invoked this function.</param>
	public virtual void OnInteract(GameObject initiator) {
		Player player = initiator.GetComponent<Player>();
		if (player == null)
			return;

		player.Inventory.AddItem(this);
	}
}

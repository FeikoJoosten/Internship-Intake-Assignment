using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rock : Weapon {
	private Rigidbody rigidBody;
	private Collider ownCollider;
	private Player originalThrower;
	private bool hasInflictedDamage;

	private RockData data;

	private void Awake() {
		rigidBody = GetComponent<Rigidbody>();
		ownCollider = GetComponent<Collider>();
		data = (RockData) WeaponData;
	}

	private void OnValidate() {
		if (WeaponData == null) return;
		if (WeaponData.GetType() == typeof(RockData)) return;

		Debug.LogError("This item only accepts weapon data of the type RockData!", this);
		WeaponData = null;
	}

	/// <summary>
	/// Will disabled the rigidbody on this Rock whenever it's equipped.
	/// </summary>
	/// <param name="newOwner">The new owner of this object.</param>
	public override void OnEquip(Player newOwner) {
		base.OnEquip(newOwner);

		rigidBody.isKinematic = true;
		hasInflictedDamage = true;
		originalThrower = null;
	}

	/// <summary>
	/// This will throw the rock based on the values assigned in the RockData.
	/// The rock will be throw based on the current BodyParts forward.
	/// After the rock has been thrown AND the CanUseInfinite in the RockData is set to false, the rock will be removed from the inventory.
	/// </summary>
	public override void UseItem() {
		ThrowRock();

		if (owner && data.CanUseInfinite == false) {
			owner.Inventory.RemoveItem(this);
		}
	}

	private void ThrowRock() {
		Rock rockToUse = this;

		if (data.CanUseInfinite) {
			rockToUse = Instantiate(gameObject, transform.position, transform.rotation, null).GetComponent<Rock>();
			//Prevent collision with the original rock object
			Physics.IgnoreCollision(ownCollider, rockToUse.ownCollider);
		}
		else {
			rockToUse.transform.SetParent(null, true);
		}
		
		//Prevent collision with the player body
		Physics.IgnoreCollision(owner.GetComponent<Collider>(), rockToUse.ownCollider);

		rockToUse.originalThrower = owner;
		rockToUse.hasInflictedDamage = false;
		rockToUse.rigidBody.isKinematic = false;
		rockToUse.rigidBody.velocity = Vector3.zero;
		rockToUse.rigidBody.AddForce(owner.Body.Head.transform.forward * data.ThrowSpeed, ForceMode.Impulse);
	}

	/// <summary>
	/// This function allows the initiator to pickup the item only IF the rigidbody is currently asleep.
	/// </summary>
	/// <param name="initiator">The object that invoked this function.</param>
	public override void OnInteract(GameObject initiator) {
		if (rigidBody.IsSleeping() == false) return;

		base.OnInteract(initiator);
	}

	private void OnCollisionEnter(Collision other) {
		if (originalThrower == null || hasInflictedDamage) return;

		IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

		if (damageable == null) return;
		if (data.CanInflictSelfDamage == false && other.transform == originalThrower.transform) return;

		damageable.Damage(this, data.Damage);
		hasInflictedDamage = true;
	}
}

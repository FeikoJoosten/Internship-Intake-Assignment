using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : Weapon {
	private BulletData data;
	private Rigidbody rigidBody;
	private Transform originalOwner;

	private void Awake() {
		rigidBody = GetComponent<Rigidbody>();

		data = (BulletData) WeaponData;
	}

	private void OnValidate() {
		if (WeaponData == null) return;
		if (WeaponData.GetType() != typeof(BulletData)) {
			Debug.LogError("This item only accepts weapon data of the type BulletData!", this);
			WeaponData = null;

			return;
		}

		data = (BulletData) WeaponData;
	}

	private void Start() {
		if (data == null) return;
		
		rigidBody.AddForce(transform.forward * data.BulletSpeed, ForceMode.Impulse);
	}

	/// <summary>
	/// This function allows you to initialize the bullet object so it can keep track of the self infliction damage.
	/// </summary>
	/// <param name="newOwner">The owner that shot this bullet.</param>
	public void Initialize(Transform newOwner) {
		originalOwner = newOwner;
	}

	private void OnCollisionEnter(Collision other) {
		if (data == null) return;
		if (rigidBody.IsSleeping()) return;

		IDamageable damageable = other.transform.root.GetComponent<IDamageable>();

		if (damageable == null) return;
		if (other.transform.root == originalOwner && data.CanInflictSelfDamage == false) return;

		damageable.Damage(this, data.Damage);
		Destroy(gameObject);
	}

	public override void OnDropped() { }

	public override void OnEquip(Player newOwner) { }

	public override void OnUnEquip() { }

	public override void OnInteract(GameObject initiator) { }

	public override void UseItem() { }
}

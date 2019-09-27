using System.Collections;
using UnityEngine;

public class Gun : Weapon {
	[SerializeField]
	[Tooltip("This value allows you to define the start ammunition clip for this weapon.")]
	private AmmoData startingClip = null;
	[SerializeField]
	[Tooltip("This transform is used to spawn bullet prefabs at. If the AmmoData does not contain a bullet prefab, a raycast is used instead.")]
	private Transform shotSpawnLocation = null;

	private GunData data;
	private int currentAmmoCount;
	private Coroutine reloadCoroutine;
	private float nextShotTime = 0;
	private float reloatTime = 0;
	private AmmoData currentAmmoData;
	private Coroutine fireCoroutine;

	private void Awake() {
		if (WeaponData == null) {
			Debug.LogError("The GunData for this gun has not been assigned!", this);
			enabled = false;
			return;
		}

		data = (GunData) WeaponData;

		if (startingClip)
			Reload(startingClip);
	}

	private void OnValidate() {
		if (WeaponData == null) return;
		if (WeaponData.GetType() != typeof(GunData)) {
			Debug.LogError("This item only accepts weapon data of the type GunData!", this);
			WeaponData = null;

			return;
		}

		data = (GunData) WeaponData;

		if (IsAmmoSupported(startingClip)) return;

		Debug.LogError("This ammo type is not supported by this weapon, please add it to the list of supported ammo types in the Data object", this);
		startingClip = null;
	}

	/// <summary>
	/// This function allows you to check if the provided AmmoData is supported by this gun. (Defined in GunData).
	/// </summary>
	/// <param name="ammoData">The AmmoData to check.</param>
	/// <returns>Will return if this AmmoData is supported by this gun.</returns>
	public bool IsAmmoSupported(AmmoData ammoData) {
		foreach (AmmoData ammoType in data.SupportedAmmoTypes) {
			if (ammoType != ammoData) continue;

			return true;
		}

		return false;
	}

	/// <summary>
	/// This function allows you to reload this gun with the provided AmmoData.
	/// Will only reload if we are not currently reloading AND if there is ammunition missing from the currentAmmoCount.
	/// </summary>
	/// <param name="ammoData">The AmmoData to use for reloading this gun.</param>
	/// <returns>Returns false whenever the reload failed to initiate. (For example, the gun is already reloading).</returns>
	public bool Reload(AmmoData ammoData) {
		//We're already reloading, so no reason to try again
		if (reloadCoroutine != null) return false;
		//The current clip is currently full, no need to reload it.
		if (currentAmmoCount == ammoData.ClipSize) return false;

		if (data.Reloadtime > 0) {
			reloadCoroutine = StartCoroutine(ReloadWithTime(ammoData));
		}
		else {
			ReloadFinished(ammoData);
		}

		return true;
	}

	private IEnumerator ReloadWithTime(AmmoData ammoData) {
		reloatTime = Time.time + data.Reloadtime;

		yield return new WaitForSeconds(data.Reloadtime);

		ReloadFinished(ammoData);
		reloadCoroutine = null;
	}

	private void ReloadFinished(AmmoData ammoData) {
		currentAmmoData = ammoData;
		currentAmmoCount = ammoData.ClipSize;
	}

	/// <summary>
	/// This function allows you to shoot this gun if it's conditions are satisfied.
	/// This gun needs to have ammunication in its current clip.
	/// Will spawn a bullet prefab, if assigned in the AmmoData. Otherwise it'll raycast for IDamageables.
	/// </summary>
	public override void UseItem() {
		if (data.SupportsFullAutomatic) {
			if (fireCoroutine != null) return;

			fireCoroutine = StartCoroutine(FireRoutine());
		}
		else {
			Fire();
		}
	}

	public override void StopUseItem() {
		if (fireCoroutine == null) return;

		StopCoroutine(fireCoroutine);
		fireCoroutine = null;
	}

	private IEnumerator FireRoutine() {
		while (true) {
			Fire();

			yield return null;
		}
	}

	private void Fire() {
		if (currentAmmoCount <= 0) return;
		if (Time.time < reloatTime) return;
		if (Time.time < nextShotTime) return;

		currentAmmoCount--;
		nextShotTime = Time.time + (1 / data.ShotsPerSecond);

		if (currentAmmoData == null) return;
		if (currentAmmoData.BulletPrefab && shotSpawnLocation) {
			Bullet bullet = Instantiate(currentAmmoData.BulletPrefab, shotSpawnLocation.position, Quaternion.LookRotation(shotSpawnLocation.forward), null);
			bullet.Initialize(owner.transform);
			return;
		}

		Ray ray = new Ray(owner.Body.Head.PlayerCamera.transform.position, owner.Body.Head.PlayerCamera.transform.forward);
		RaycastHit[] hits = Physics.RaycastAll(ray, data.ShotDistance);

		for (int i = 0; i < hits.Length; i++) {
			// In case we didn't directly hit an interactable, we try and see if the root is an interactable instead
			IDamageable damageable = hits[i].transform?.GetComponent<IDamageable>() ?? hits[i].transform?.root.GetComponent<IDamageable>();

			if (damageable == null) continue;
			if (hits[i].transform == transform || hits[i].transform.root == owner) continue;

			damageable.Damage(this, data.Damage);
			break;
		}
	}
}

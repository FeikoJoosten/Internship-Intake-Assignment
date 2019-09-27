using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Gun Data")]
public class GunData : WeaponData {
	[Header("Weapon Data")]
    [SerializeField]
	[Tooltip("This value allows you to define the rate of fire for your gun. Rate of fire is calculated using 1 / shotsPerSecond.")]
	private float shotsPerSecond = 5;
	public float ShotsPerSecond => shotsPerSecond;
	[SerializeField]
	[Tooltip("This value allows you to define if you're using a full automatic weapon or a single mode weapon.")]
	private bool supportsFullAutomatic = true;
	public bool SupportsFullAutomatic => supportsFullAutomatic;
	[SerializeField]
	[Tooltip("This value defines how far the gun can shoot whenever it is using the raycast mode for shooting.")]
	private float shotDistance = Mathf.Infinity;
	public float ShotDistance => shotDistance;

	[Header("Ammunition")]
	[SerializeField]
	[Tooltip("This value defines the AmmoData types that are supported by this gun whenever you want to reload it.")]
	private List<AmmoData> supportedAmmoTypes = null;
	public List<AmmoData> SupportedAmmoTypes => supportedAmmoTypes;

	[Header("Reloading")]
	[SerializeField]
	[Tooltip("Setting this to true will automatically reload your weapon whenever you try to fire it when its clip is empty.")]
	private bool supportAutoReload = true;
	public bool SupportAutoReload => supportAutoReload;
	[SerializeField]
	[Tooltip("This value defines the amount of time required to reload this weapon. While it is reloading, you cannot fire it.")]
	private float reloadTime = 3;
	public float Reloadtime => reloadTime;
}

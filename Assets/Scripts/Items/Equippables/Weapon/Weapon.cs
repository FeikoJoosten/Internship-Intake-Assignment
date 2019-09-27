using UnityEngine;

public class Weapon : Item {
	[SerializeField]
	[Tooltip("This is the weapon data for this object")]
	private WeaponData weaponData = null;
	public WeaponData WeaponData { get { return weaponData;  } protected set { weaponData = value; } }
}

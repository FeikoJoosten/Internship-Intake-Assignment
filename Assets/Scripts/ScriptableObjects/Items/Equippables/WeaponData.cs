using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Weapon Data")]
public class WeaponData : ScriptableObject {
	[SerializeField]
	[Tooltip("The amount of damage the weapon does.")]
	private float damage = 1;
	public float Damage => damage;
	[SerializeField]
	[Tooltip("This value defines if the weapon can hurt it's owner. (The object that used this weapon).")]
	private bool canInflictSelfDamage = false;
	public bool CanInflictSelfDamage => canInflictSelfDamage;
}

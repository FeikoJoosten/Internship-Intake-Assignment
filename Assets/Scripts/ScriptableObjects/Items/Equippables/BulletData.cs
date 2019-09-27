using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Bullet Data")]
public class BulletData : WeaponData {
	[SerializeField]
	[Tooltip("This value defines the speed given to the bullet whenever it is spawned.")]
	private float bulletSpeed = 100;
	public float BulletSpeed => bulletSpeed;
}

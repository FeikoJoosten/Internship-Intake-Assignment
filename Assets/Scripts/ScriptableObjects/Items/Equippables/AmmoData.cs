using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Ammo Data")]
public class AmmoData : ScriptableObject {
	[SerializeField]
	[Tooltip("The amount of bullets that can fit into this clip.")]
	private int clipSize = 30;
	public int ClipSize => clipSize;
	[SerializeField]
	[Tooltip("This value defines if the ammo clip is used up whenever you reload a gun with it.")]
	private bool canUseInfinite = false;
	public bool CanUseInfinite => canUseInfinite;
	[SerializeField]
	[Tooltip("This value is optional, and allows you to switch between projectiles or raycasts for shooting a gun.")]
	private Bullet bulletPrefab = null;
	public Bullet BulletPrefab => bulletPrefab;
}

using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Rock Data")]
public class RockData : WeaponData {
    [SerializeField]
	[Tooltip("This value defines if the rock is used up whenever you throw it.")]
	private bool canUseInfinite = false;
	public bool CanUseInfinite => canUseInfinite;
	[SerializeField]
	[Tooltip("The speed at which the rock is thrown.")]
	private float throwSpeed = 100;
	public float ThrowSpeed => throwSpeed;
}

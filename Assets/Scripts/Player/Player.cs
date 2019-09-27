using UnityEngine;

[RequireComponent(typeof(PlayerBody))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerInventory))]
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerUIController))]
public class Player : MonoBehaviour {
	[SerializeField]
	[Tooltip("This is the player data for this player. It's contains the core information for this player.")]
	private PlayerData data = null;
	public PlayerData Data => data;
	
	public PlayerBody Body { get; private set; }
	public PlayerHealth Health { get; private set; }
	public PlayerInventory Inventory { get; private set; }
	public PlayerController Controller { get; private set; }
	public PlayerUIController UiController { get; private set; }

	private void Awake() {
		Body = GetComponent<PlayerBody>();
		Health = GetComponent<PlayerHealth>();
		Inventory = GetComponent<PlayerInventory>();
		Controller = GetComponent<PlayerController>();
		UiController = GetComponent<PlayerUIController>();
	}
}

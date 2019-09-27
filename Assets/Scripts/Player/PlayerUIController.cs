using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerUIController : MonoBehaviour {
	[SerializeField]
	[Tooltip("This is the equipment screen used to (un)equip items.")]
	private EquipmentScreen equipmentScreen = null;

	private Player player; // Player has us listed as a require component
	private InputActions controls;

	private void Awake() {
		player = GetComponent<Player>();

		controls = new InputActions();
		
		controls.UIPlayer.CloseEquipmentScreen.performed += OnCloseEquipmentScreen;
	}

	private void OnCloseEquipmentScreen(InputAction.CallbackContext obj) {
		if (equipmentScreen == null || player == null) return;

		equipmentScreen.CloseEquipmentScreen();
		player.Controller.enabled = true;
		controls.UIPlayer.Disable();
	}

	public void OpenEquipmentScreen() {
		if (equipmentScreen == null || player == null) return;

		equipmentScreen.OpenEquipmentScreen();
		player.Controller.enabled = false;
		controls.UIPlayer.Enable();
	}
}

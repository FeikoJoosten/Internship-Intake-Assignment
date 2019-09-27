using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
	private Player player; // Player has us listed as a require component
	private InputActions controls;

	private void Awake() {
		player = GetComponent<Player>();

		controls = new InputActions();

		controls.Player.LeftHandUsage.performed += OnLeftHandUsagePerformed;
		controls.Player.LeftHandUsage.canceled += OnLeftHandUsageCanceled;
		controls.Player.RightHandUsage.performed += OnRightHandUsagePerformed;
		controls.Player.RightHandUsage.canceled += OnRightHandUsageCanceled;
		controls.Player.Movement.performed += OnMovement;
		controls.Player.Rotation.performed += OnRotation;
		controls.Player.OpenEquipmentScreen.performed += OnOpenEquipmentScreen;
	}

	private void OnDestroy() {
		controls.Player.LeftHandUsage.performed -= OnLeftHandUsagePerformed;
		controls.Player.LeftHandUsage.canceled -= OnLeftHandUsageCanceled;
		controls.Player.RightHandUsage.performed -= OnRightHandUsagePerformed;
		controls.Player.RightHandUsage.canceled -= OnRightHandUsageCanceled;
		controls.Player.Movement.performed -= OnMovement;
		controls.Player.Rotation.performed -= OnRotation;
		controls.Player.OpenEquipmentScreen.performed -= OnOpenEquipmentScreen;
	}

	private void OnEnable() {
		controls.Player.Enable();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void OnDisable() {
		controls.Player.Disable();

		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
	
	private void OnLeftHandUsagePerformed(InputAction.CallbackContext callbackContext) {
		if (player.Body.LeftHand.EquippedItem == null)
			OnInteraction();
		else
			player.Body.LeftHand.UseEquippedItem();
	}

	private void OnLeftHandUsageCanceled(InputAction.CallbackContext callbackContext) {
		player.Body.LeftHand.StopUseEquippedItem();
	}

	private void OnRightHandUsagePerformed(InputAction.CallbackContext callbackContext) {
		if (player.Body.RightHand.EquippedItem == null)
			OnInteraction();
		else
			player.Body.RightHand.UseEquippedItem();
	}

	private void OnRightHandUsageCanceled(InputAction.CallbackContext callbackContext) {
		player.Body.RightHand.StopUseEquippedItem();
	}

	private void OnMovement(InputAction.CallbackContext callbackContext) {
		player.Body.Move(callbackContext.ReadValue<Vector2>() * player.Data.MovementSpeed * Time.deltaTime);
	}

	private void OnRotation(InputAction.CallbackContext callbackContext) {
		Vector2 rotation = callbackContext.ReadValue<Vector2>();
		rotation.x = (player.Data.InvertXAxis ? -rotation.x : rotation.x) * player.Data.RotationSpeed.x * Time.deltaTime;
		rotation.y = (player.Data.InvertYAxis ? -rotation.y : rotation.y) * player.Data.RotationSpeed.y * Time.deltaTime;
		
		player.Body.Rotate(rotation.x);
		player.Body.Head.Rotate(rotation.y);
		player.Body.LeftHand.Rotate(rotation.y);
		player.Body.RightHand.Rotate(rotation.y);
	}

	private void OnOpenEquipmentScreen(InputAction.CallbackContext callbackContext) {
		player.UiController.OpenEquipmentScreen();
	}

	/// <summary>
	/// This function allows you to get the related InputAction based on the BodyPart type.
	/// </summary>
	/// <param name="bodyPart">The bodypart type you want to use for the search.</param>
	/// <returns>Return the requested InputAction if found. Returns null otherwise.</returns>
	public InputAction GetInputActionFromBodyPart(System.Type bodyPart) {
		if (bodyPart == typeof(LeftHand))
			return controls.Player.LeftHandUsage;
		if (bodyPart == typeof(RightHand))
			return controls.Player.RightHandUsage;

		return null;
	}

	private void OnInteraction() {
		Ray ray = new Ray(player.Body.Head.PlayerCamera.transform.position, player.Body.Head.PlayerCamera.transform.forward);
		RaycastHit[] hits = Physics.RaycastAll(ray, player.Data.InteractionRange);

		for (int i = 0; i < hits.Length; i++) {
			// In case we didn't directly hit an interactable, we try and see if the root is an interactable instead
			IInteractable interactable = hits[i].transform?.GetComponent<IInteractable>() ?? hits[i].transform?.root.GetComponent<IInteractable>();

			if (interactable == null) continue;

			interactable.OnInteract(gameObject);
			break;
		}
	}
}

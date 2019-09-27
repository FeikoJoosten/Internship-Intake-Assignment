using UnityEngine;

public class BodyPart : MonoBehaviour {
    protected Item equippedItem;
	public Item EquippedItem => equippedItem;

	protected PlayerBody playerBody = null;

	/// <summary>
	/// This function is used to inform this bodypart of its owner.
	/// </summary>
	/// <param name="bodyToUse">The owner of this bodypart.</param>
	public void RegisterBody(PlayerBody bodyToUse) {
		playerBody = bodyToUse;
	}

	/// <summary>
	/// This function is used to equip items onto this bodypart.
	/// Items will be placed onto the position of this bodypart.
	/// If this bodypart was already holding an item, the previous item will be unequipped.
	/// This function also works with prefabs. If the itemToEquip is a prefab, it'll automatically instantiate the item instead of teleporting it.
	/// </summary>
	/// <param name="itemToEquip">The item to equip.</param>
	/// <returns>Return the equipped item.</returns>
	public virtual Item EquipItem(Item itemToEquip) {
		BodyPart previousBodyPart = playerBody.GetBodyPartFromEquippedItem(itemToEquip, new[] { GetType() });
		if (previousBodyPart != null && previousBodyPart != this) {
			previousBodyPart.EquipItem(null);
		}

		if (equippedItem) {
			equippedItem.OnUnEquip();
		}

		equippedItem = itemToEquip;

		// Can be null in case we equip an empty item (could be used for unequipping for example)
		if (equippedItem == null) return null;

		if (equippedItem.gameObject?.scene.IsValid() == false) {
			equippedItem = Instantiate(itemToEquip, transform);
		}
		else {
			equippedItem.gameObject?.SetActive(true);
			equippedItem.transform.SetParent(transform, false);
			equippedItem.transform.position = transform.position;
		}

		equippedItem.OnEquip(playerBody.Player);
		return equippedItem;
	}

	/// <summary>
	/// This function is used to use the currently equipped item.
	/// </summary>
	public virtual void UseEquippedItem() {
		if (equippedItem == null) return;

		equippedItem.UseItem();
	}

	public virtual void StopUseEquippedItem() {
		if (equippedItem == null) return;

		equippedItem.StopUseItem();
	}

	/// <summary>
	/// This function is used to rotate this bodypart along the Y axis.
	/// This is used to let all bodyparts follow along the current camera angle.
	/// </summary>
	/// <param name="rotation">The amount of rotation to add.</param>
	public void Rotate(float rotation) {
		Vector3 currentRotation = transform.rotation.eulerAngles;

		if (currentRotation.x > 180) {
			currentRotation.x -= 360;
		}

		Vector2 cameraRotationClamp = playerBody.Player.Data.CameraXRotClamp;
		float newAngle = currentRotation.x + rotation;
		currentRotation.x = Mathf.Clamp(newAngle, cameraRotationClamp.x, cameraRotationClamp.y);

		if (currentRotation.x < 0) {
			currentRotation.x += 360;
		}

		transform.rotation = Quaternion.Euler(currentRotation);
	}

	private float ClampAngle(float angle, float min, float max) {
		angle = ClampBetweenRotation(angle);
		min = ClampBetweenRotation(min);
		max = ClampBetweenRotation(max);

		return Mathf.Clamp(angle, min, max);
	}

	private float ClampBetweenRotation(float valueToClamp) {
		if (valueToClamp < -360)
			valueToClamp += 360;
		if (valueToClamp > 360)
			valueToClamp -= 360;

		return valueToClamp;
	}
}

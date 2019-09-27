using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour {
	[SerializeField]
	[Tooltip("The left hand of the player.")]
	private LeftHand leftHand = null;
	public LeftHand LeftHand => leftHand;
	[SerializeField]
	[Tooltip("The right hand of the player.")]
	private RightHand rightHand = null;
	public RightHand RightHand => rightHand;
	[SerializeField]
	[Tooltip("The head of the player.")]
	private Head head = null;
	public Head Head => head;

	private Player player;
	public Player Player => player;
	private List<BodyPart> registeredBodyParts = new List<BodyPart>();

	private void Awake() {
		player = GetComponent<Player>();
		
		InitializeBodyParts();
	}

	private void InitializeBodyParts() {
		BodyPart[] childBodyParts = GetComponentsInChildren<BodyPart>();

		foreach (BodyPart bodyPart in childBodyParts) {
			if (bodyPart == null) continue;

			registeredBodyParts.Add(bodyPart);
			bodyPart.RegisterBody(this);
		}
	}

	/// <summary>
	/// This function allows you to rotate the player body along the X axis.
	/// </summary>
	/// <param name="rotation">The amount of rotation to rotate.</param>
	public void Rotate(float rotation) {
		player.transform.Rotate(Vector3.up, rotation);
	}

	/// <summary>
	/// This function allows you to move the player body along the horizontal plane.
	/// </summary>
	/// <param name="horizontalMovement">The amount of horizontal movement to move.</param>
	public void Move(Vector2 horizontalMovement) {
		transform.Translate(new Vector3(horizontalMovement.x, 0, horizontalMovement.y));
	}

	/// <summary>
	/// This function allows you to get a bodypart of this player based on the Type.
	/// </summary>
	/// <param name="bodyPartTypeToGet">The type of bodypart to find.</param>
	/// <returns>Return the type of bodypart you requested if found. Returns null otherwise.</returns>
	public BodyPart GetBodyPart(System.Type bodyPartTypeToGet) {
		if (bodyPartTypeToGet == leftHand.GetType())
			return leftHand;
		if (bodyPartTypeToGet == rightHand.GetType())
			return rightHand;
		if (bodyPartTypeToGet == head.GetType())
			return head;

		return null;
	}

	/// <summary>
	/// This function allows you to get a bodypart based on the equiped item.
	/// </summary>
	/// <param name="itemToUse">The item you use to find the current bodypart.</param>
	/// <param name="typesToExclude">Bodypart types you wish to exclude from this search.</param>
	/// <returns>Returns the requested bodypart if found. Returns null otherwise.</returns>
	public BodyPart GetBodyPartFromEquippedItem(Item itemToUse, System.Type[] typesToExclude = null) {
		if (itemToUse == null) return null;

		foreach (TypeReferences.ClassTypeReference bodyType in itemToUse.AvailableBodyTypes) {
			bool shouldContinue = true;

			if (typesToExclude != null) {
				foreach (System.Type type in typesToExclude) {
					if (type != bodyType.Type) continue;

					shouldContinue = false;
					break;
				}
			}

			if (shouldContinue == false) continue;

			BodyPart bodyPartToUse = GetBodyPart(bodyType);

			if (bodyPartToUse.EquippedItem == itemToUse) return bodyPartToUse;
		}

		return null;
	}

	/// <summary>
	/// This function allows you to get a bodypart based on the Type of item currently equipped.
	/// This function is useful of you do not care about a specific item, but rather focus on the type instead.
	/// </summary>
	/// <param name="itemTypeToFind">The item type you are currently looking for.</param>
	/// <returns>Returns the requested bodypart if found. Returns null otherwise.</returns>
	public BodyPart GetBodyPartFromEquippedItemType(System.Type itemTypeToFind) {
		if (itemTypeToFind == null) return null;

		foreach (BodyPart bodyPart in registeredBodyParts) {
			if (bodyPart == null) continue;
			if (bodyPart.EquippedItem?.GetType() != itemTypeToFind) continue;

			return bodyPart;
		}

		return null;
	}
}

using UnityEngine;

public class Head : BodyPart {
	[SerializeField]
	[Tooltip("This is the camera used for this player. It's used for raycasting when shooting a gun and when interaction with empty hands.")]
	private Camera playerCamera = null;
	public Camera PlayerCamera => playerCamera;
	
	/// <summary>
	/// The head cannot use items, so we have to override this method
	/// </summary>
	public override void UseEquippedItem() { }
}

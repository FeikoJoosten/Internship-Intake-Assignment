using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Player Data")]
public class PlayerData : ScriptableObject
{
	[Header("Interaction")]
    [SerializeField]
	[Tooltip("The interaction range of the player.")]
	private float interactionRange = 5;
	public float InteractionRange => interactionRange;

	[Header("Movement")]
	[SerializeField]
	[Tooltip("The speed at which the player moves along the horizontal plane.")]
	private float movementSpeed = 5;
	public float MovementSpeed => movementSpeed;
	[SerializeField]
	[Tooltip("The speed at which the player rotates along the vertical plane.")]
	private Vector2 rotationSpeed = new Vector2(5, 5);
	public Vector2 RotationSpeed => rotationSpeed;
	
	[Header("Camera")]
	[SerializeField]
	[Tooltip("The minimum and maximum range the rotation can rotate to along the vertical plane.")]
	private Vector2 cameraXRotClamp = new Vector2(-30, 30);
	public Vector2 CameraXRotClamp => cameraXRotClamp;
	[SerializeField]
	[Tooltip("This value allows you to flip the rotation direction of the X axis rotation.")]
	private bool invertXAxis = false;
	public bool InvertXAxis => invertXAxis;
	[SerializeField]
	[Tooltip("This value allows you to flip the rotation direction of the Y axis rotation.")]
	private bool invertYAxis = false;
	public bool InvertYAxis => invertYAxis;

	[Header("Health")]
	[SerializeField]
	[Tooltip("The amount of health this player starts off with.")]
	private float baseHealth = 10;
	public float BaseHealth => baseHealth;
}

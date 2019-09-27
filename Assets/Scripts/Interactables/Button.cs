using UnityEngine;

[RequireComponent(typeof(Animation))]
public class Button : MonoBehaviour, IInteractable {
	[SerializeField]
	[Tooltip("This is the animation clip that'll be played whenever this button is pressed. If this animation is not assigned, nothing will happen whenever you interact with this button.")]
	private AnimationClip buttonPressAnimation = null;

	private Animation animationComponent;

	private void Awake() {
		animationComponent = GetComponent<Animation>();
		animationComponent.clip = buttonPressAnimation;
	}

	/// <summary>
	/// Will play an animation whenever the OnInteract function is invoked
	/// </summary>
	/// <param name="initiator">The object that invoked this function.</param>
	public void OnInteract(GameObject initiator) {
		if (buttonPressAnimation == null) return;
		if (animationComponent.isPlaying) return;

		animationComponent.Play();
	}
}

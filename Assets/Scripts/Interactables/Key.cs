using UnityEngine;

[RequireComponent(typeof(Animation))]
public class Key : MonoBehaviour, IInteractable {
	[SerializeField]
	[Tooltip("This is the animation clip that'll be played whenever this key is interacted with. If this animation is not assigned, nothing will happen whenever you interact with this key.")]
	private AnimationClip keyTurnAnimation = null;

	private Animation animationComponent;

	private void Awake() {
		animationComponent = GetComponent<Animation>();
		animationComponent.clip = keyTurnAnimation;
	}

	/// <summary>
	/// Will play an animation whenever the OnInteract function is invoked
	/// </summary>
	/// <param name="initiator">The object that invoked this function.</param>
	public void OnInteract(GameObject initiator) {
		if (keyTurnAnimation == null) return;
		if (animationComponent.isPlaying) return;

		animationComponent.Play();
	}
}

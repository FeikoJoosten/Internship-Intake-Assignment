using UnityEngine;

[RequireComponent(typeof(Animation))]
public class Door : MonoBehaviour, IInteractable {
	[SerializeField]
	[Tooltip("This is the open animation that'll be played. If this or CloseAnimation is not assigned, nothing will happen whenever you interact with this door.")]
	private AnimationClip openAnimation = null;
	[SerializeField]
	[Tooltip("This is the close animation that'll be played. If this or OpenAnimation is not assigned, nothing will happen whenever you interact with this door.")]
	private AnimationClip closeAnimation = null;
	[SerializeField]
	[Tooltip("This value allows you to define if you want this door to start opened or closed.")]
	private bool startOpened = false;

	private Animation animationComponent;

	private void Awake() {
		animationComponent = GetComponent<Animation>();

		if (openAnimation == null || closeAnimation == null) return;

		AnimationClip startClip = startOpened ? openAnimation : closeAnimation;
		startClip.SampleAnimation(gameObject, startClip.length);
		animationComponent.clip = startClip;
	}

	/// <summary>
	/// Will play an animation whenever the OnInteract function is invoked
	/// The animation to play is based on the open or close status of this door.
	/// </summary>
	/// <param name="initiator">The object that invoked this function.</param>
	public void OnInteract(GameObject initiator) {
		if (openAnimation == null || closeAnimation == null) return;
		if (animationComponent.isPlaying) return;
		
		animationComponent.clip = animationComponent.clip == openAnimation ? closeAnimation : openAnimation;
		animationComponent.Play();
	}
}

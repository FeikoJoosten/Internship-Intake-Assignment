using UnityEngine;

[RequireComponent(typeof(Animation))]
public class Lever : MonoBehaviour, IInteractable {
	[SerializeField]
	[Tooltip("This is the up animation that'll be played. If this or DownAnimation is not assigned, nothing will happen whenever you interact with this lever.")]
	private AnimationClip upAnimation = null;
	[SerializeField]
	[Tooltip("This is the down animation that'll be played. If this or UpAnimation is not assigned, nothing will happen whenever you interact with this lever.")]
	private AnimationClip downAnimation = null;
	[SerializeField]
	[Tooltip("This value allows you to define if you want this lever to start upwards or downwards position.")]
	private bool startUp = false;

	private Animation animationComponent;

	private void Awake() {
		animationComponent = GetComponent<Animation>();

		if (upAnimation == null || downAnimation == null) return;

		AnimationClip startClip = startUp ? upAnimation : downAnimation;
		startClip.SampleAnimation(gameObject, startClip.length);
		animationComponent.clip = startClip;
	}

	/// <summary>
	/// Will play an animation whenever the OnInteract function is invoked
	/// The animation to play is based on the up or down status of this lever.
	/// </summary>
	/// <param name="initiator">The object that invoked this function.</param>
	public void OnInteract(GameObject initiator) {
		if (upAnimation == null || downAnimation == null) return;
		if (animationComponent.isPlaying) return;

		animationComponent.clip = animationComponent.clip == upAnimation ? downAnimation : upAnimation;
		animationComponent.Play();
	}
}

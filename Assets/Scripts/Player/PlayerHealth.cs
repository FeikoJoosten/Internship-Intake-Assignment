using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable {
	private float currentHealth;
	private Player player; // Player has us listed as a require component

	private void Awake() {
		player = GetComponent<Player>();

		currentHealth = player == null ? 1 : player.Data.BaseHealth;
	}

	/// <inheritdoc />
	/// <summary>
	/// This function is used to apply damage onto the player.
	/// If the players health reaches 0 or lower, the player will die.
	/// </summary>
	/// <param name="damageInflictor"></param>
	/// <param name="damage"></param>
	public void Damage(Weapon damageInflictor, float damage = 1) {
		currentHealth -= damage;

		Debug.LogFormat("Damage taken {0}, remaining health {1}", damage, currentHealth);

		if (currentHealth <= 0)
			Die();
	}

	private void Die() {
		Destroy(transform.root.gameObject);
	}
}

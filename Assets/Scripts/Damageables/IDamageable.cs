/// <summary>
/// This interface is used for all weapons, to apply damage onto
/// </summary>
public interface IDamageable {
	/// <summary>
	/// This function is used to apply damage onto the IDamageable.
	/// </summary>
	/// <param name="damageInflictor">The object that inflicted the damage.</param>
	/// <param name="damage">The amount of damage to deal against this object, defaults to 1.</param>
	void Damage(Weapon damageInflictor, float damage = 1);
}

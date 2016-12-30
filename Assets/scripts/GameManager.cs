using UnityEngine;

[AddComponentMenu ("Vistage/GameManager")]
static public class GameManager {

	public const float MAX_DAMAGE = 100;

	static private float damage;
	static public float Damage {
		get {
			return damage;
		}
		set {
			if (damage != value) {
				damage = value;
				Debug.Log(value);

				if (damage >= MAX_DAMAGE)
				{
					// TODO : Decrease number of lives
					damage = 0;
				}
			}
		}
	}
}

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

				if (damage >= MAX_DAMAGE)
				{
					damage = 0;
					Lives--;
				}
			}
		}
	}

	static private int lives = 5;
	static public int Lives {
		get {
			return lives;
		}
		set {
			if (lives != value) {
				lives = value;

				if (lives <= 0)
				{
					// TODO : Handle gameover
				}
			}
		}
	}
}

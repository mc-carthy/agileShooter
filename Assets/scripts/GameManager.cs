using UnityEngine;

[AddComponentMenu ("Vistage/GameManager")]
static public class GameManager {

	public const float MAX_DAMAGE = 100;

	static private float damage;
	static public float Damage 
	{
		get {
			return damage;
		}
		set {
			if (value != damage) {
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
	static public int Lives 
	{
		get {
			return lives;
		}
		set {
			if (value != lives) {
				lives = value;

				if (lives <= 0)
				{
					// TODO : Handle gameover
				}
			}
		}
	}

	static private int score;
	static public int Score
	{
		get { return score;}
		set 
		{
			if (value != score) 
			{
				score = value;
				if (score > HighScore)
				{
					HighScore = value;
				}
			}
		}
	}

	static private int highScore;
	static public int HighScore
	{
		get { return PlayerPrefs.GetInt ("HighScore"); }
		set { PlayerPrefs.SetInt ("HighScore", value); }
	}
	
}

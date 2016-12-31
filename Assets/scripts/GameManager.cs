using UnityEngine;

[AddComponentMenu ("Vistage/GameManager")]
static public class GameManager {

	public const float MAX_DAMAGE = 100;

	public delegate void ScoreChange (int score);
	public delegate void LivesChange (int lives);

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

	static public event LivesChange LivesChanged;
	static private int lives = 5;
	static public int Lives 
	{
		get {
			return lives;
		}
		set {
			if (value != lives) {
				lives = value;

				if (LivesChanged != null)
				{
					LivesChanged(lives);
				}
				if (lives <= 0)
				{
					// TODO : Handle gameover
				}
			}
		}
	}
	
	static public event ScoreChange ScoreChanged;
	static private int score;
	static public int Score
	{
		get { return score;}
		set 
		{
			if (value != score) 
			{
				score = value;
				
				if (ScoreChanged != null)
				{
				ScoreChanged(score);
				}
				if (score > HighScore)
				{
					HighScore = value;
				}
			}
		}
	}

	static public event ScoreChange HiScoreChanged;
	static private int highScore;
	static public int HighScore
	{
		get { return PlayerPrefs.GetInt ("HighScore"); }
		set 
		{
			PlayerPrefs.SetInt ("HighScore", value); 
			if (HiScoreChanged != null)
			{
				HiScoreChanged(value);
			}
		}
	}
	
}

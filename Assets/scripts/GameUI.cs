using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu ("Vistage/GameUI")]
public class GameUI : MonoBehaviour {

	[HeaderAttribute ("HUD")]
	public Text livesText;
	public Text scoreText;
	public Text hiScoreText;

	private void Start ()
	{
		livesText.text = string.Format ("{0} {1}", GameManager.Lives.ToString (), GameManager.Lives > 1 ? "Lives" : "Life");
		scoreText.text = string.Format ("SCORE: {0}", GameManager.Score.ToString ());
		hiScoreText.text = string.Format ("HI-SCORE: {0}", GameManager.HighScore.ToString ());

		GameManager.LivesChanged += delegate(int lives)
			{
				livesText.text = string.Format ("{0} {1}", lives.ToString (), GameManager.Lives > 1 ? "Lives" : "Life");
			};
		GameManager.ScoreChanged += delegate(int score)
			{
				scoreText.text = string.Format ("SCORE: {0}", score.ToString ());
			};
		GameManager.HiScoreChanged += delegate(int score)
			{
				hiScoreText.text = string.Format ("HI-SCORE: {0}", GameManager.HighScore.ToString ());
			};
	}

}

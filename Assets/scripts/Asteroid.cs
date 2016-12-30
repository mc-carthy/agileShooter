using UnityEngine;

[AddComponentMenu ("Vistage/Asteroid")]
public class Asteroid : MonoBehaviour {

	public int score = 5;

	private void OnCollisionEnter2D (Collision2D other)
	{
		if (!other.gameObject.CompareTag("Projectile"))
		{
			return;
		}

		GameManager.Score += score;


		// TODO : Use object pooling
		Destroy (gameObject);
	}
}

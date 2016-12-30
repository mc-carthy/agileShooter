using UnityEngine;

[AddComponentMenu ("Vistage/Projectile")]
public class Projectile : MonoBehaviour {

	public float speed = 5f;
	[System.NonSerializedAttribute]
	public float range = 3f;

	private AudioSource source;
	private float distance;

	private void Awake () {
		source = GetComponent<AudioSource> ();
	}

	private void Start () {
		source.Play ();
	}

	private void FixedUpdate () {
		transform.Translate (0, speed * Time.fixedDeltaTime, 0, Space.Self);
		distance += speed * Time.fixedDeltaTime;

		if (distance > range)
		{
			// TODO : Use object pooling
			Destroy(gameObject);
		}
	}
}

using UnityEngine;
using System.Collections;

[AddComponentMenu ("Vistage/Spawner")]
public class Spawner : MonoBehaviour {

	[HeaderAttribute ("Spawn")]
	public GameObject reference;

	[HeaderAttribute ("Spawning")]
	[RangeAttribute (0.001f, 10f)]
	public float minRate = 1.0f;
	[RangeAttribute (0.001f, 10f)]
	public float maxRate = 1.0f;
	public bool isInfinite;
	public int number = 5;

	[HeaderAttribute ("Locations")]
	public GameArea area;
	public float minDistanceFromPlayer;

	[HeaderAttribute ("Velocity")]
	[RangeAttribute (-180f, 180f)]
	[SerializeField]
	private float angle;
	[RangeAttribute (0f, 360f)]
	[SerializeField]
	private float spread;
	[RangeAttribute (0f, 10f)]
	[SerializeField]
	private float minSpeed = 1;
	[RangeAttribute (0f, 10f)]
	[SerializeField]
	private float maxSpeed = 10;

	private Transform player;
	private int _remaining;

	private IEnumerator Start () {
		_remaining = number;
		if (minDistanceFromPlayer > 0)
		{
			GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
			if (playerGO != null)
			{
				player = playerGO.transform;
			}
			else 
			{
				Debug.LogWarning ("No Player found, assign 'Player' tag to Player object");
			}
		}

		while (isInfinite || _remaining > 0) {
			Vector3 _position = (area != null) ? area.GetRandomPosition () : transform.position;
			
			if (player != null && Vector3.Distance (_position, player.transform.position) < minDistanceFromPlayer)
			{
				_position = (_position - player.position).normalized * minDistanceFromPlayer;
			}
			
			GameObject obj = Instantiate (reference, _position, Quaternion.identity) as GameObject;
			Rigidbody2D rb = obj.GetComponent<Rigidbody2D> ();

			if (rb != null) {
				float angleDelta = Random.Range(-spread * 0.5f, spread * 0.5f);
				float objAngle = angle + angleDelta;

				Vector2 direction = new Vector2 (Mathf.Sin (Mathf.Deg2Rad * objAngle), Mathf.Cos (Mathf.Deg2Rad * objAngle));

				direction *= Random.Range(minSpeed, maxSpeed);

				rb.velocity = direction;
			}

			_remaining--;
			
			yield return new WaitForSeconds (1 / Random.Range (minRate, maxRate));
		}
	}
}

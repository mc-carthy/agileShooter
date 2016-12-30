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

	[HeaderAttribute ("Animator")]
	public string animatorSpawningParameterName = "isSpawning";
	public float animatorDelayIn;
	public float animatorDelayOut;

	private Animator anim;
	private int spawningHashId;

	private Transform player;
	private int remaining;

	private void Awake () {
		anim = GetComponent<Animator> ();
		if (anim) {
			spawningHashId = Animator.StringToHash(animatorSpawningParameterName);
		}
	}

	private IEnumerator Start () {
		remaining = number;
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

		if (anim != null)
		{
			anim.SetBool (spawningHashId, true);
			yield return new WaitForSeconds (animatorDelayIn);
		}

		while (isInfinite || remaining > 0) {
			Vector3 _position = (area != null) ? area.GetRandomPosition () : transform.position;
			
			if (player != null && Vector3.Distance (_position, player.transform.position) < minDistanceFromPlayer)
			{
				_position = (_position - player.position).normalized * minDistanceFromPlayer;
			}
			
			// TODO : Use Object Pooling
			GameObject obj = Instantiate (reference, _position, Quaternion.identity) as GameObject;
			Rigidbody2D rb = obj.GetComponent<Rigidbody2D> ();

			if (rb != null) {
				float angleDelta = Random.Range(-spread * 0.5f, spread * 0.5f);
				float objAngle = angle + angleDelta;

				Vector2 direction = new Vector2 (Mathf.Sin (Mathf.Deg2Rad * objAngle), Mathf.Cos (Mathf.Deg2Rad * objAngle));

				direction *= Random.Range(minSpeed, maxSpeed);

				rb.velocity = direction;
			}

			remaining--;
			
			yield return new WaitForSeconds (1 / Random.Range (minRate, maxRate));
		}

		if (anim != null)
		{
			anim.SetBool (spawningHashId, false);
			yield return new WaitForSeconds (animatorDelayOut);
		}

		gameObject.SetActive(false);

	}
}

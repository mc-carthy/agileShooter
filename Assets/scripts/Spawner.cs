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

	private Transform player;
	private float _timeStamp;
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
			
			Instantiate (reference, _position, Quaternion.identity);
			_remaining--;
			
			yield return new WaitForSeconds (1 / Random.Range (minRate, maxRate));
		}
	}
}

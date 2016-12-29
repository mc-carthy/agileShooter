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

	private float _timeStamp;
	private int _remaining;


	private void Start () 
	{
		_timeStamp = Time.time;
		_remaining = number;

		StartCoroutine (Spawn ());
	}

	private IEnumerator Spawn () {
		while (isInfinite || _remaining > 0) {
			Vector3 _position = (area != null) ? area.GetRandomPosition () : transform.position;
			
			Instantiate (reference, _position, Quaternion.identity);
			_remaining--;
			
			yield return new WaitForSeconds(1 / Random.Range (minRate, maxRate));
		}
	}
}

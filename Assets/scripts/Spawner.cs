using UnityEngine;
using System.Collections;

[AddComponentMenu ("Vistage/Spawner")]
public class Spawner : MonoBehaviour {

	[HeaderAttribute ("Spawn")]
	public GameObject reference;

	[HeaderAttribute ("Spawning")]
	[RangeAttribute (0.001f, 10f)]
	public float rate = 1.0f;
	public bool isInfinite;
	public int number = 5;

	private float _timeStamp;
	private int _remaining;

	private void Awake () 
	{

	}

	private void Start () 
	{
		_timeStamp = Time.time;
		_remaining = number;

		StartCoroutine (Spawn ());
	}

	private void Update () 
	{

	}

	private IEnumerator Spawn () {
		while (isInfinite || _remaining > 0) {
			Instantiate (reference, transform.position, Quaternion.identity);
			_remaining--;
			yield return new WaitForSeconds(1 / rate);
		}
	}
}

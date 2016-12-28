using UnityEngine;

public class SimpleShipController : MonoBehaviour {

	private float tranSpeed = 5f;
	private float rotSpeed = 50f;

	private void Awake () {

	}

	private void Start () {

	}

	private void Update () {
		MoveShip();
	}

	private void MoveShip() {
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		transform.Translate(
			new Vector3(0, v, 0) * tranSpeed * Time.deltaTime
		);
		transform.Rotate(
			new Vector3(0, 0, -h) * rotSpeed * Time.deltaTime
		);
	}

}

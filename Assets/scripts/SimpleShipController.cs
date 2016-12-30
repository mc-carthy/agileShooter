using UnityEngine;

public class SimpleShipController : MonoBehaviour {

	private bool isFiring;
	public bool IsFiring
	{
		get { return isFiring; }
		set 
		{ 
			if (isFiring != value)
			{
				isFiring = value;
				if (isFiring)
				{
					weapon.InvokeRepeating ("Fire", 0.1f, 1f / weapon.firingRate);
				}
				else {
					weapon.CancelInvoke ();
				}
			}
		}
	}
	

	private Rigidbody2D rb;
	private Vector2 delta = Vector2.zero;
	private Vector2 force = Vector2.zero;
	private float torque;
	private float shipThrust = 10f;
	private float shipTorque = 1f;
	private Weapon weapon;
	

	private void Awake () {
		rb = GetComponent<Rigidbody2D> ();
		weapon = GetComponentInChildren<Weapon> ();
	}

	private void Start () {

	}

	private void FixedUpdate () {
		MoveShip ();
	}

	private void MoveShip() {

		#if (UNITY_IOS || UNITY_ANDROID) && !UNITY_EDITOR || REMOTE

		if (Input.touchCount > 0) 
		{
			Touch t = Input.touches[0];
			if (t.phase == TouchPhase.Moved) 
			{
				delta.x = t.deltaPosition.x;
				delta.y = t.deltaPosition.y;
			}
			if (t.tapCount > 1) {
				IsFiring = true;
			}
		}
		else 
		{
			IsFiring = false;
		}

		#else

		delta.x = Input.GetAxisRaw ("Horizontal");
		delta.y = Input.GetAxisRaw ("Vertical");

		IsFiring = Input.GetButton("Fire2");

		#endif

		force.y = delta.y * shipThrust;
		torque = -delta.x * shipTorque;

		rb.AddRelativeForce (force);
		rb.AddTorque (torque);
	}

}

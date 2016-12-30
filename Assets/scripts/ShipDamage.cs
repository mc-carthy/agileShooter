using UnityEngine;

[AddComponentMenu ("Vistage/ShipDamage")]
public class ShipDamage : MonoBehaviour {

	private float damage;
	private float Damage {
		get {
			return GameManager.Damage;
		}
		set {
			GameManager.Damage = value;
		}
	}

	public float vunerability = 1;
	
	private Rigidbody2D rb;
	private Collider2D col;

	private void Awake ()
	{
		rb = GetComponent<Rigidbody2D> ();
		col = GetComponent<Collider2D> ();
	}

	private void OnCollisionEnter2D (Collision2D other)
	{
		float damage = other.relativeVelocity.magnitude;
		if (other.collider.sharedMaterial != null)
		{
			damage *= 
				1 / other.collider.sharedMaterial.bounciness *
				1 / col.sharedMaterial.bounciness *
				col.sharedMaterial.friction *
				other.collider.sharedMaterial.friction;

		}
		if (other.rigidbody != null)
		{
			damage *= (other.rigidbody.mass / rb.mass);
		}
		Damage += damage;
	}
}

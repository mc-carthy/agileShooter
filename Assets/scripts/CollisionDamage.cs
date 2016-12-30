using UnityEngine;

[AddComponentMenu ("Vistage/CollisionDamage")]
public class CollisionDamage : MonoBehaviour {

	public float damageAmount = 1;

	private void OnCollisionEnter2D (Collision2D other) 
	{
		if (!other.gameObject.CompareTag ("Player"))
		{
			return;
		}
		other.gameObject.SendMessage("ApplyDamage", damageAmount, SendMessageOptions.DontRequireReceiver);
	}
}

using UnityEngine;

[AddComponentMenu ("Vistage/Weapon")]
public class Weapon : MonoBehaviour {

	public GameObject projectile;
	public Transform [] emitters;
	[RangeAttribute (0.1f, 10f)]
	public float firingRate = 1;
	public float firingRange = 5;

	private int emitterIndex;

	private Collider2D shipCol;

	private void Awake () 
	{
		shipCol = transform.parent.GetComponent<Collider2D> ();
	}

	private void Start () 
	{

	}

	private void Fire ()
	{
		emitterIndex = (emitterIndex >= emitters.Length - 1) ? 0 : emitterIndex + 1;
		Vector3 position = emitters[emitterIndex].TransformPoint (Vector3.up * 0.5f);
		GameObject projectileInstance = Instantiate(projectile, position, emitters[emitterIndex].rotation) as GameObject;
		projectileInstance.GetComponent<Projectile> ().range = firingRange;
		Physics2D.IgnoreCollision(projectileInstance.GetComponent<Collider2D> (), shipCol);
	}
}

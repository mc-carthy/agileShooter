using UnityEngine;
using System.Collections;

[AddComponentMenu ("Vistage/Item")]
public class Item : MonoBehaviour {

	public enum TYPE {
		RepairKit,
		ExtraLife
	}

	public TYPE type;

	private AudioSource source;
	private Renderer ren;
	private Collider2D col;

	private void Awake ()
	{
		source = GetComponent<AudioSource> ();
		ren = GetComponent<Renderer> ();
		col = GetComponent<Collider2D> ();
	}

	private void OnTriggerEnter2D (Collider2D other)
	{
		if (!other.gameObject.CompareTag("Player"))
		{
			return;
		}

		switch (type)
		{
			case TYPE.RepairKit:
				GameManager.Damage = 0;
				break;
			case TYPE.ExtraLife:
				GameManager.Lives++;
				break;
			default:
				Debug.LogWarning("Incorrect Type given");
				break;
		}

		StartCoroutine (PlaySoundAndRelease ());

	}

	private IEnumerator PlaySoundAndRelease ()
	{
		ren.enabled = false;
		col.enabled = false;

		source.Play ();

		yield return new WaitForSeconds (source.clip.length);

		// TODO : Use object pooling
		Destroy (gameObject);
	}
}

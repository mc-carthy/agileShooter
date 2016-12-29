using UnityEngine;

[AddComponentMenu ("Vistage/FitAreaToCamera")]
[RequireComponent (typeof (GameArea))]
public class FitAreaToCamera : MonoBehaviour {

	private GameArea Area {
		get { return GetComponent<GameArea> (); }
	}

	private void Awake () {
		FitToMainCamera ();
	}

	private void Reset () {
		FitToMainCamera ();
	}

	private void FitToCamera (Camera cam) {
		Area.Size = new Vector2 (cam.aspect * cam.orthographicSize * 2, cam.orthographicSize * 2);
		transform.position = (Vector2) cam.transform.position;
		transform.rotation = cam.transform.rotation;
	}

	private void FitToMainCamera () {
		FitToCamera (Camera.main);
	}
}

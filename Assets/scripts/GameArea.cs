using UnityEngine;

///	<summary>
///	Game Area.
/// Defines rectangular area.
/// </summary>

[AddComponentMenu("Vistage/Game Area")]
public class GameArea : MonoBehaviour {

	private Rect _area;
	public Rect Area {
		get { return _area; }
		set { _area = value; }
	}

	public Vector2 size;
	public Color gizmoColor = new Color(0, 0, 1, 0.2f);
	private Color gizmoWireColor;

	private void Awake () {
		SetArea(size);
	}

	private void OnDrawGizmos () {
		Gizmos.matrix = transform.localToWorldMatrix;
		Gizmos.color = gizmoColor;
		Gizmos.DrawCube (Vector3.zero, new Vector3 (Area.width, Area.height, 0));
		Gizmos.DrawWireCube (Vector3.zero, new Vector3 (Area.width, Area.height, 0));
	}

	private void OnValidate () {
		SetArea(size);
		gizmoWireColor = new Color (gizmoColor.r, gizmoColor.g, gizmoColor.b, 1);
	}

	public void SetArea (Vector2 size) {
		Area = new Rect (size.x * -0.5f, size.y * -0.5f, size.x, size.y);
	}
}

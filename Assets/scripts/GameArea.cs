using UnityEngine;

///	<summary>
///	Game Area.
/// Defines rectangular area.
/// </summary>

[AddComponentMenu ("Vistage/GameArea")]
public class GameArea : MonoBehaviour {

	[SerializeField]
	[HideInInspector]
	private Rect _area;
	public Rect Area {
		get { 
			return _area; 
		}
		set { 
			_area = value; 
		}
	}

	public Vector2 size;
	public Vector2 Size {
		get {
			return Area.size;
		}
		set {
			size = value;
			Area = new Rect (size.x * -0.5f, size.y * -0.5f, size.x, size.y);
		}
	}

	public Color gizmoColor = new Color(0, 0, 1, 0.2f);
	private Color gizmoWireColor;

	private void Awake () {
		Size = size;
	}

	private void OnDrawGizmos () {
		Gizmos.matrix = transform.localToWorldMatrix;
		Gizmos.color = gizmoColor;
		Gizmos.DrawCube (Vector3.zero, new Vector3 (Area.width, Area.height, 0));
		Gizmos.DrawWireCube (Vector3.zero, new Vector3 (Area.width, Area.height, 0));
	}

	private void OnValidate () {
		Size = size;
		gizmoWireColor = new Color (gizmoColor.r, gizmoColor.g, gizmoColor.b, 1);
	}

}

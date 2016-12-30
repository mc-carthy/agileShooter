using UnityEngine;

///	<summary>
///	Game Area.
/// Defines rectangular area.
/// </summary>

[AddComponentMenu ("Vistage/GameArea")]
public class GameArea : MonoBehaviour {

	static private GameArea main;
	static public GameArea Main {
		get {
			if (main == null) {
				main = FindObjectOfType<GameArea>();
				if (main == null) {
					GameObject go = new GameObject("Game Area : Main");
					main = go.AddComponent<GameArea>();
					go.AddComponent<FitAreaToCamera>();
				}
			}
			return main;
		}
		set {
			main = value;
		}
	}

	[SerializeField]
	[HideInInspector]
	private Rect _area;
	public Rect Area 
	{
		get { 
			return _area; 
		}
		set { 
			_area = value; 
		}
	}

	public Vector2 size;
	public Vector2 Size 
	{
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

	private void Awake () 
	{
		Size = size;
	}

	private void OnDrawGizmos () 
	{
		Gizmos.matrix = transform.localToWorldMatrix;
		Gizmos.color = gizmoColor;
		Gizmos.DrawCube (Vector3.zero, new Vector3 (Area.width, Area.height, 0));
		Gizmos.DrawWireCube (Vector3.zero, new Vector3 (Area.width, Area.height, 0));
	}

	private void OnValidate () 
	{
		Size = size;
		gizmoWireColor = new Color (gizmoColor.r, gizmoColor.g, gizmoColor.b, 1);
	}

	public Vector3 GetRandomPosition () 
	{
		Vector3 randomPos = Vector3.zero;

		randomPos.x = Random.Range(Area.xMin, Area.xMax);
		randomPos.y = Random.Range(Area.yMin, Area.yMax);
		randomPos = transform.TransformPoint(randomPos);

		return randomPos;
	}

}

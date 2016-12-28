using UnityEngine;

public class SimpleShipController : MonoBehaviour {

  private Vector2 delta = Vector2.zero;
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

    #if (UNITY_IOS || UNITY_ANDROID) && !UNITY_EDITOR || REMOTE

    if (Input.touchCount > 0) {
      Touch t = Input.touches[0];
      if (t.phase == TouchPhase.Moved) {
        delta.x = t.deltaPosition.x;
        delta.y = t.deltaPosition.y;
      }
    }

    #else

    delta.x = Input.GetAxisRaw("Horizontal");
    delta.y = Input.GetAxisRaw("Vertical");

    #endif

    transform.Translate(
      new Vector3(0, delta.y, 0) * tranSpeed * Time.deltaTime
    );
    transform.Rotate(
      new Vector3(0, 0, -delta.x) * rotSpeed * Time.deltaTime
    );
  }

}

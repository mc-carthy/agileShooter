﻿using UnityEngine;

// Purpose:
// Loop the object transforms across a rectangular area.
// When the object leaves the area on the right, it comes back on the left.

[AddComponentMenu ("Vistage/TransformLooper")]
public class TransformLooper : MonoBehaviour {

	public GameArea gameArea;

	private Vector3 areaSpacePosition;

	private void Awake () {
		if (gameArea == null) {
			gameArea = GameArea.Main;
		}
	}

	private void FixedUpdate () {
		areaSpacePosition = gameArea.transform.InverseTransformPoint(transform.position);

		if (gameArea.Area.Contains(areaSpacePosition)) {
			return;
		}

		if (areaSpacePosition.x < gameArea.Area.xMin) {
			areaSpacePosition.x = gameArea.Area.xMax;
		} else if (areaSpacePosition.x > gameArea.Area.xMax) {
			areaSpacePosition.x = gameArea.Area.xMin;
		}

		if (areaSpacePosition.y < gameArea.Area.yMin) {
			areaSpacePosition.y = gameArea.Area.yMax;
		} else if (areaSpacePosition.y > gameArea.Area.yMax) {
			areaSpacePosition.y = gameArea.Area.yMin;
		}

		transform.position = gameArea.transform.TransformPoint(areaSpacePosition);
	}
}

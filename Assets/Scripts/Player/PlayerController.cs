using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float stickTol = 0.9f;
	private float AV;
	private float AH;

	[SerializeField]
	private int player = 1;

	[SerializeField]
	private Camera _camera;
	// Use this for initialization
	void Start () {
		
	}
		
	// Update is called once per frame
	void Update () {
		if (_camera.isActiveAndEnabled) {
			if (player == 1) {
				AV = Input.GetAxis ("Vertical");
				AH = Input.GetAxis ("Horizontal");
			}
			if (player == 2) {
				AV = Input.GetAxis ("VerticalR");
				AH = Input.GetAxis ("HorizontalR");
			}
			//first make sure stick vals are higher than the tolerance
			if ((Mathf.Abs (AH) > stickTol || Mathf.Abs (AV) > stickTol)) {
				if ((Mathf.Abs (AH) + Mathf.Abs (AV)) > 1) {
					float angle = Mathf.Atan2 (AH, AV) * Mathf.Rad2Deg;
					transform.rotation = Quaternion.Euler (new Vector3 (0, 180f, angle));
				}
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	void Update(){
		/*
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		if (x != 0.0f || y != 0.0f) {
			float _angle = Mathf.Atan2 (y, x) * Mathf.Rad2Deg;
			if(Mathf.Abs(_angle-transform.eulerAngles.z)<20)
				transform.eulerAngles = new Vector3 (0,0,_angle);
		}*/

		transform.Rotate (0.0f,0.0f,Input.GetAxis("Horizontal"));
	}
}

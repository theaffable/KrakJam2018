using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	[SerializeField]
	int id;
	[SerializeField]
	Camera _camera;

	void Update(){
		if (_camera.gameObject.active)
		{
			if(id==0)
				transform.Rotate (0.0f,0.0f,Input.GetAxis("Horizontal"));
			if(id==1)
				transform.Rotate (0.0f,0.0f,Input.GetAxis("Vertical"));
		}		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLight : MonoBehaviour
{

	private float _offset;
	
	void Start()
	{
		_offset = Random.Range(-Mathf.PI, Mathf.PI);
	}
	
	void Update () {
			transform.Rotate(0f, Mathf.Cos(Time.time + _offset), 0f, Space.Self);
	}
}

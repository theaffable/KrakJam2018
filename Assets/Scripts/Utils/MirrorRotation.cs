using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorRotation : MonoBehaviour
{

	public GameObject target;
	
	void Update ()
	{
		transform.rotation = Quaternion.EulerAngles(0f, 0f, target.transform.localEulerAngles.z);
	}
}

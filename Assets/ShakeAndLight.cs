using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeAndLight : MonoBehaviour {

	Vector3 originPosition;
	Quaternion originRotation;
 	
	[SerializeField]
	float shake_decay_start;
	[SerializeField]
	float shake_intensity_start;

	[SerializeField] private GameObject light;

	private float shake_intensity=0;
	private float shake_decay=0;
	private bool shaked = false;
 
	void Update(){
		if(shake_intensity > 0){
			transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
			transform.rotation =  new Quaternion(
				originRotation.x + Random.Range(-shake_intensity,shake_intensity)*.2f,
				originRotation.y + Random.Range(-shake_intensity,shake_intensity)*.2f,
				originRotation.z + Random.Range(-shake_intensity,shake_intensity)*.2f,
				originRotation.w + Random.Range(-shake_intensity,shake_intensity)*.2f);
			shake_intensity -= shake_decay;
		}
		else if(shaked)
		{
			transform.position = originPosition;
			transform.rotation = originRotation;
		}
		
		
	}
 
	public void DoShake(){
		light.SetActive(true);
		originPosition = transform.position;
		originRotation = transform.rotation;
		shake_intensity = shake_intensity_start;
		shake_decay = shake_decay_start;
		shaked = true;
	}
}

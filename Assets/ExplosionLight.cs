using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionLight : MonoBehaviour
{
	private Light light;

	private float intensity;
	// Use this for initialization
	void Start ()
	{
		light = GetComponent<Light>();
		intensity = light.intensity;
	}
	
	// Update is called once per frame
	void Update ()
	{
		light.intensity-=70;
		if (light.intensity <= 0)
		{
			light.intensity = intensity;
			gameObject.SetActive(false);
		}
	}
}

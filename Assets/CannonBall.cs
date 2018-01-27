﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {
	private void OnTriggerEnter(Collider other)
	{
		Destroy(other.gameObject);
		Destroy(this.gameObject);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerCollider : MonoBehaviour {

	protected PipeController _pipeController;
	// Use this for initialization
	void Start () {
		_pipeController = FindObjectOfType<PipeController> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public abstract void Hit();
}
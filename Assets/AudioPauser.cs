using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPauser : MonoBehaviour {

	[SerializeField] private float _countdown = 12.0f;

	private float _count;

	// Use this for initialization
	void Start () {
		_count = _countdown;
	}
	
	// Update is called once per frame
	void Update () {
		_count -= Time.deltaTime;
		if (_count < 0) {
			_count = _countdown;
			gameObject.GetComponent<AudioSource> ().Play ();
		}
	}
}

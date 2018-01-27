using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementController : MonoBehaviour {

	[SerializeField]
	int _forceForward;
	[SerializeField]
	int _forceUp;
	[SerializeField]
	int _forceDown;
	[SerializeField]
	int _constantSpeed;

	Vector3 _oldSpeed=Vector3.zero,_newSpeed=Vector3.zero;

	Rigidbody _rigidbody;
	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody> ();
		_rigidbody.velocity = new Vector3(_constantSpeed,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		_rigidbody.velocity = Vector3.Lerp (_oldSpeed, _newSpeed, 0.5f); //0.5 wyznaczone doswiadczalnie xd
	}

	public void Move(int forceLvlUp, int forceLvlDown, int forceLvlForward){
		_oldSpeed= _rigidbody.velocity;
		_newSpeed = new Vector3 (forceLvlForward * _forceForward, forceLvlDown * _forceDown * -1 + forceLvlUp * _forceUp, 0);

	}
}

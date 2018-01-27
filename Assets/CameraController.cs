using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	[SerializeField]
	Camera player0Engine;
	[SerializeField]
	Camera player1Engine;
	[SerializeField]
	Camera player0Ship;
	[SerializeField]
	Camera player1Ship;
	[SerializeField]
	KeyCode player0Switch;
	[SerializeField]
	KeyCode player1Switch;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(player0Switch)){
			player0Engine.gameObject.SetActive (!player0Engine.gameObject.activeSelf);
			player0Ship.gameObject.SetActive (!player0Ship.gameObject.activeSelf);
		}
		if(Input.GetKeyDown(player1Switch)){
			player1Engine.gameObject.SetActive (!player1Engine.gameObject.activeSelf);
			player1Ship.gameObject.SetActive (!player1Ship.gameObject.activeSelf);
		}
	}
}

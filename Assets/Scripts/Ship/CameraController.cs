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
	Camera player0Shoot;
	[SerializeField]
	Camera player1Shoot;
	[SerializeField]
	KeyCode player0Switch;
	[SerializeField]
	KeyCode player1Switch;

	private int _player0index = 0;
	private int _player1index = 0;

	private List<Camera> player0List = new List<Camera>();
	private List<Camera> player1List = new List<Camera>();
	// Use this for initialization
	void Start () {
		player0List.Add(player0Engine);
		player0List.Add(player0Ship);
		player0List.Add(player0Shoot);
		player1List.Add(player1Engine);
		player1List.Add(player1Ship);
		player1List.Add(player1Shoot);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(player0Switch))
		{
			player0List[_player0index].gameObject.SetActive(false);
			_player0index++;
			if (_player0index > player0List.Count - 1)
				_player0index = 0;
			player0List[_player0index].gameObject.SetActive(true);
		}
		if(Input.GetKeyDown(player1Switch)){
			player1List[_player1index].gameObject.SetActive(false);
			_player1index++;
			if (_player1index > player1List.Count - 1)
				_player1index = 0;
			player1List[_player1index].gameObject.SetActive(true);
		}
	}
}

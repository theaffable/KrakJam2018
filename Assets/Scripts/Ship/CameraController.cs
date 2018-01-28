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
	Camera player2Engine;
	[SerializeField]
	Camera player3Engine;
	[SerializeField]
	Camera player2Ship;
	[SerializeField]
	Camera player3Ship;
	[SerializeField]
	Camera player2Shoot;
	[SerializeField]
	Camera player3Shoot;

	private KeyCode player0Switch = KeyCode.Joystick1Button4;
	private KeyCode player1Switch = KeyCode.Joystick1Button5;
	private KeyCode player2Switch = KeyCode.Joystick2Button4;
	private KeyCode player3Switch = KeyCode.Joystick2Button5;

	private int _player0index = 0;
	private int _player1index = 0;
	private int _player2index = 0;
	private int _player3index = 0;

	private List<Camera> player0List = new List<Camera>();
	private List<Camera> player1List = new List<Camera>();
	private List<Camera> player2List = new List<Camera>();
	private List<Camera> player3List = new List<Camera>();
	// Use this for initialization
	void Start () {
		player0List.Add(player0Engine);
		player0List.Add(player0Ship);
		player0List.Add(player0Shoot);
		player1List.Add(player1Engine);
		player1List.Add(player1Ship);
		player1List.Add(player1Shoot);
		player2List.Add(player2Engine);
		player2List.Add(player2Ship);
		player2List.Add(player2Shoot);
		player3List.Add(player3Engine);
		player3List.Add(player3Ship);
		player3List.Add(player3Shoot);

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
		if(Input.GetKeyDown(player2Switch)){
			player2List[_player2index].gameObject.SetActive(false);
			_player2index++;
			if (_player2index > player2List.Count - 1)
				_player2index = 0;
			player2List[_player2index].gameObject.SetActive(true);
		}
		if(Input.GetKeyDown(player3Switch)){
			player3List[_player3index].gameObject.SetActive(false);
			_player3index++;
			if (_player3index > player3List.Count - 1)
				_player3index = 0;
			player3List[_player3index].gameObject.SetActive(true);
		}
	}
}

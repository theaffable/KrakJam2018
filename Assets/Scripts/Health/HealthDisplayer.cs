using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplayer : MonoBehaviour {

	[SerializeField]
	GameObject _hearthPrefab;

	List<GameObject> _hearths = new List<GameObject>();

	int _healthIndex;

	void Start () {
	}
	
	// For testing
	void Update () {
		
	}

	public void Init(int maxHealth){
		for (int x = 0; x < maxHealth; x++) {
			_hearths.Add (Instantiate(_hearthPrefab, new Vector3 (50 * x, 0, 0)+this.transform.position, Quaternion.identity));
			_hearths [x].transform.parent = this.transform;
		}
		_healthIndex = maxHealth;
	}

	public void HideHeart(){
		if (_healthIndex <= 0)
			return;
		_healthIndex--;
		_hearths [_healthIndex].SetActive (false);
	}		

	public void Reset(int maxHealth){
		for (int x = 0; x < maxHealth; x++) {
			_hearths [x].SetActive(true);
		}
		_healthIndex = maxHealth;
	}
}

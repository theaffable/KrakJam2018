using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {

	[SerializeField]
	GameObject _hearthPrefab;
	[SerializeField]
	int _maxHealth = 5;
	List<GameObject> _hearths = new List<GameObject>();
	int _health = 0;

	void Start () {
		Init ();
	}
	
	// For testing
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q))
			Damage();
		if (Input.GetKeyDown(KeyCode.R))
			Reset();
	}

	void Init(){
		for (int x = 0; x < _maxHealth; x++) {
			_hearths.Add (Instantiate(_hearthPrefab, new Vector3 (20 * x, 0, 0)+this.transform.position, Quaternion.identity));
			_hearths [x].transform.parent = this.transform;
		}
		_health = _maxHealth;
	}

	public void Damage(){
		if (_health <= 0)
			return;
		_health--;
		_hearths [_health].SetActive (false);
	}

	public int Health(){
		return _health;
	}

	public void Reset(){
		for (int x = 0; x < _maxHealth; x++) {
			_hearths [x].SetActive(true);
		}
		_health = _maxHealth;
	}
}

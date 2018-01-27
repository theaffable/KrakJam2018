using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	[SerializeField] private float _countdown = 5.0f;
	[SerializeField] private Text _scoreText;

    private float _count;
    private int _score;
    
    // Use this for initialization
    void Start ()
    {
        _score = 0;
        _count = _countdown;
    }
    
    // Update is called once per frame
    void Update () {
		_count -= Time.deltaTime;
		if (_count < 0) {
			_count = _countdown;
			_score += 100;
			UpdateScore ();
		}
	}

	public void EnemyHit() {
		_score += 500;
		UpdateScore ();
	}

	private void UpdateScore() {
		_scoreText.text = "Score: " + _score;
	}
}

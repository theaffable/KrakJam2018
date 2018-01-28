using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	[SerializeField] private float _countdown = 5.0f;
	[SerializeField] private Text _scoreText;

    private float _count;
    private int _score;
	private bool _gameOver = false;

    // Use this for initialization
    void Start ()
    {
        _score = 0;
        _count = _countdown;
    }
    
    // Update is called once per frame
    void Update () {
		if (!_gameOver) {
			_count -= Time.deltaTime;
			if (_count < 0) {
				_count = _countdown;
				_score += 100;
				UpdateScore ();
			}
		}
	}

	public void EnemyHit() {
		if (!_gameOver) {
			_score += 500;
			UpdateScore ();
	    }
	}

	public void Stop() {
		_gameOver = true;
	}

	private void UpdateScore() {
		_scoreText.text = "Score: " + _score;
	}

	public void AddScore(int score) {
		_score += score;
		UpdateScore ();
	}
}

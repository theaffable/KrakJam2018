using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {

	[SerializeField]
	private ScoreController _scoreController;

	private void OnTriggerEnter(Collider other)
	{
		Destroy(gameObject);

		if (other.CompareTag ("Obstacle")) {
			_scoreController.EnemyHit ();
			Destroy(other.gameObject);
		}
	}
}

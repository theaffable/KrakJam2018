using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipCollisionHandler : MonoBehaviour
{
    public AudioClip GameOverSound;
    
    [SerializeField] ShipHealthController _shipHealthController;
    [SerializeField] public Text _gameOverText;
    [SerializeField] public ScoreController _scoreController;

    void Start()
    {
        _gameOverText.gameObject.SetActive(false);
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Obstacle") || col.CompareTag("EnemyCannonBall") )
        {
            _shipHealthController.Damage();
            Destroy(col.gameObject);
        }

        if (col.CompareTag("Death"))
        {
            _gameOverText.gameObject.SetActive(true);
            gameObject.GetComponent<AudioSource>().clip = GameOverSound;
            gameObject.GetComponent<AudioSource>().Play();
            _scoreController.Stop();
        }

		if (col.CompareTag("Treasure"))
		{
			_scoreController.AddScore(1500);
			Destroy (col.gameObject);
		}
    }
}
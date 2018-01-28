using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipCollisionHandler : MonoBehaviour
{
    public AudioClip GameOverSound;
    
    [SerializeField] ShipHealthController _shipHealthController;
    [SerializeField] Text _gameOverText;
    [SerializeField] ScoreController _scoreController;

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
    }
}
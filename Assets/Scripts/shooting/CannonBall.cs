using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public AudioClip ShotAudio;
    public AudioClip ObstacleExplosionAudio;  // obstacles dont have scripts so why bother
    
    [SerializeField] private ScoreController _scoreController;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Obstacle"))
        {
            ObstacleExplode(other);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void ObstacleExplode(Collider other)
    {
        AudioSource.PlayClipAtPoint(ObstacleExplosionAudio, gameObject.transform.position);
        var explosion = other.gameObject.GetComponent<ParticleSystem>();
        
        
        explosion.Play();
        
        Destroy(gameObject);
        Destroy(other.gameObject);
        
        _scoreController.EnemyHit();
    }
}
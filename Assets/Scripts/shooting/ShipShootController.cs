using System.ComponentModel;
using UnityEngine;

public class ShipShootController : MonoBehaviour
{

	[SerializeField] private GameObject _cannonBall;
	[SerializeField] private int shootCd = 4;
	[SerializeField] private int _speed = 4;
	[SerializeField] public float _shotLifetime = 2.0f;

	private bool leftShoot = false;
	private bool rightShoot = false;
	private bool topShoot = false;
	private bool downShoot = false;
	private int leftCounter = 0;
	private int rightCounter = 0;
	private int topCounter = 0;
	private int downCounter = 0;

	private AudioSource _audio;
	
	void Start()
	{
		_audio = GetComponent<AudioSource>();
	}
	
	public void Shoot(Vector3 force)
	{
		if (force == Vector3.up)
		{
			if (topShoot)
			{
				return;
			}
			topCounter = shootCd * 60;
			topShoot = true;
		}else if (force == Vector3.down)
		{
			if (downShoot)
			{
				return;
			}
			downCounter = shootCd * 60;
			downShoot = true;
		}else if (force == Vector3.left)
		{
			if (leftShoot)
			{
				return;
			}
			leftCounter = shootCd * 60;
			leftShoot = true;
		}else if (force == Vector3.right)
		{
			if (rightShoot)
			{
				return;
			}	
			rightCounter = shootCd * 60;
			rightShoot = true;
		}

		DoShoot(force);
	}

	private void DoShoot(Vector3 force)
	{
		GameObject instance = Instantiate(_cannonBall, transform.position + new Vector3(10f, 0, 0), Quaternion.identity);
		_audio.clip = instance.GetComponent<CannonBall>().ShotAudio;
		_audio.Play();
		Destroy(instance, _shotLifetime);
		instance.GetComponent<Rigidbody>().velocity = force * _speed;
	}

	void Update()
	{
		if (topCounter > 0)
		{
			topCounter--;
		}
		else
		{
			topShoot = false;
		}
		if (downCounter > 0)
		{
			downCounter--;
		}
		else
		{
			downShoot = false;
		}
		if (leftCounter > 0)
		{
			leftCounter--;
		}
		else
		{
			leftShoot = false;
		}
		if (rightCounter > 0)
		{
			rightCounter--;
		}
		else
		{
			rightShoot = false;
		}
	}
}

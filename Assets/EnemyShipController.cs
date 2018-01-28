using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
	[SerializeField]
	private int shootingRate = 5;

	[SerializeField] private GameObject cannonBall;

	private int counter=0;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().velocity = new Vector3(-10,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		if (counter <= 0)
		{
			counter = shootingRate * 60;
			Shoot();
		}else
		{
			counter--;
		}
	}

	void Shoot()
	{
		GameObject cannonBallInstance = Instantiate(cannonBall, this.transform.position-new Vector3(10,0,0), Quaternion.identity);
		cannonBallInstance.GetComponent<Rigidbody>().velocity = new Vector3(-80, 0, 0);
		Destroy(cannonBallInstance, 1.5f);
	}
}

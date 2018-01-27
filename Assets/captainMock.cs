using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class captainMock : MonoBehaviour {

	private class CaptainMessages
	{
		public static string LeftMsg = "Hard-a-port!";
		public static string RightMsg = "Hard-a-starboard!";
		public static string CenterMsg = "Full steam ahead!";

		public static string[] Messages = { LeftMsg, RightMsg, CenterMsg };

		public static string getRandomMsg()
		{
			return Messages[Random.Range(0, Messages.Length)];
		}
		
	}

	private Text captainMessage;
	
	[SerializeField] private float countdown = 0.5f;

	private float count;
	
	
	// Use this for initialization
	void Start ()
	{
		count = countdown;
		captainMessage = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		count -= Time.deltaTime;
             if ( count < 0 )
             {
	             count = countdown;
	             captainMessage.text = CaptainMessages.getRandomMsg();
             }
	}
	
}

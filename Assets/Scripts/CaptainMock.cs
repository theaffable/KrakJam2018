using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class CaptainMock : MonoBehaviour {

	public enum PipeLocation
	{
		Left, Center, Right
	}

	public struct Pipe
	{
		public readonly int Room;  
		public readonly PipeLocation Location;

		public Pipe(int room, PipeLocation location)
		{
			Room = room;
			Location = location;
		}
	}
	
	private struct Order  
	{
		public readonly string Message;
		public readonly Pipe Pipe;

		public Order(string message, Pipe pipe)
		{
			Message = message;
			Pipe = pipe;
		}
	} 
	
	private class CaptainOrder
	{
		private static readonly Order LeftMsg = new Order("Hard-a-port!(<)", new Pipe(1, PipeLocation.Left));
		private static readonly Order RightMsg = new Order("Hard-a-starboard!(>)", new Pipe(1, PipeLocation.Right));
		private static readonly Order CenterMsg = new Order("Full steam ahead!(^)", new Pipe(1, PipeLocation.Center));

		private static readonly Order[] Messages = { LeftMsg, RightMsg, CenterMsg };

		public static Order RandomOrder()
		{
			return Messages[Random.Range(0, Messages.Length)];
		}
		
	}
	[SerializeField]
	private Text _scoreText;
	[SerializeField]
	private Text _captainMessage;
	
	[SerializeField] private float _countdown = 0.5f;

	private float _count;

	private Order _order;

	private int _score;
	
	// Use this for initialization
	void Start ()
	{
		_score = 0;
		_count = _countdown;
		ChangeOrder ();
	}
	
	// Update is called once per frame
	void Update () {
		_count -= Time.deltaTime;
             if ( _count < 0 )
             {
	             _count = _countdown;
				ChangeOrder ();           
             }
	}

	private void ChangeOrder(){
		_order = CaptainOrder.RandomOrder();
		_captainMessage.text = _order.Message;
	}


	public void CheckForPoints(Pipe pipe)
	{
		if (pipe.Room == _order.Pipe.Room && pipe.Location == _order.Pipe.Location)
		{
			_score += 100;
			_scoreText.text = "Score: " + _score;
		}
	}
	
}

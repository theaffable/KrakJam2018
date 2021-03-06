﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamStatusController : MonoBehaviour
{

	
	
	int _upLvl = 0;
	int _downLvl = 0;
	int _forwardLvl = 0;

	List<int> _idsWorkingOnUp = new List<int>();
	List<int> _idsWorkingOnDown = new List<int>();
	List<int> _idsWorkingOnForward = new List<int>();

	[SerializeField]
	ShipMovementController _shipMovementController;
	[SerializeField]
	ShipShootController _shipShootController;

	private void Update()
	{
		if (Application.isEditor && Input.GetKey(KeyCode.Space)) // test purposes
		{
			ShootRightActive();
		}
	}

	public void ShootLeftActive()
	{
		_shipShootController.Shoot(Vector3.left);		
	}
	
	public void ShootTopActive()
	{
		_shipShootController.Shoot(Vector3.up);	
	}
	
	public void ShootRightActive()
	{
		_shipShootController.Shoot(Vector3.right);
	}
	
	public void ShootDownActive()
	{
		_shipShootController.Shoot(Vector3.down);
	}

	

	public void UpActive(int id){
		if (!_idsWorkingOnUp.Contains (id)) {
			_upLvl++;
			RemoveFromWorkingLists (id);
			_idsWorkingOnUp.Add (id);
			_shipMovementController.Move(_upLvl,_downLvl,_forwardLvl);
		}
		Debug.Log ("UP");
	}

	public void DownActive(int id){
		if (!_idsWorkingOnDown.Contains (id)) {
			_downLvl++;
			RemoveFromWorkingLists (id);
			_idsWorkingOnDown.Add (id);
			_shipMovementController.Move(_upLvl,_downLvl,_forwardLvl);
		}
		Debug.Log ("Down");
	}

	public void ForwardActive(int id){
		if (!_idsWorkingOnForward.Contains (id)) {
			_forwardLvl++;
			RemoveFromWorkingLists (id);
			_idsWorkingOnForward.Add (id);
			_shipMovementController.Move(_upLvl,_downLvl,_forwardLvl);
		}
		Debug.Log ("Forward");
	}

	private void RemoveFromWorkingLists(int id){
		if (_idsWorkingOnUp.Contains (id))
			_upLvl--;
		if (_idsWorkingOnDown.Contains (id))
			_downLvl--;
		if (_idsWorkingOnForward.Contains (id))
			_forwardLvl--;
		_idsWorkingOnUp.Remove (id);
		_idsWorkingOnDown.Remove (id);
		_idsWorkingOnForward.Remove (id);
	}
}

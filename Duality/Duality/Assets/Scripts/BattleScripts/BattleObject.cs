using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleObject : MonoBehaviour {

	private string mBattleID; //The name of the unit initiating the attack
	private GameObject mPlayerObject; //The player object
	private GameObject mEnemyObject; //The enemy object
	private bool mPLayerInitiating; //Is the player unit initiating?

	public void setBattleID(string nID)
	{
		mBattleID = nID;
	}

	public string getBattleID()
	{
		return mBattleID;
	}

	public void setPlayerObject(GameObject nPlayerObject)
	{
		mPlayerObject = nPlayerObject;
	}

	public GameObject getPlayerObject ()
	{
		return mPlayerObject;
	}

	public void setEnemyObject (GameObject nEnemyObject)
	{
		mEnemyObject = nEnemyObject;
	}

	public GameObject getEnemyObject ()
	{
		return mEnemyObject;
	}

	public void setPlayerInitiation (bool playerInitiation)
	{
		mPLayerInitiating = playerInitiation;
	}

	public bool getPlayerInitiation()
	{
		return mPLayerInitiating;
	}
}

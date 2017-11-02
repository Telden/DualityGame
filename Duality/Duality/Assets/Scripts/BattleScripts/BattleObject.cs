using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleObject : MonoBehaviour {

	private string mBattleID; //The name of the unit initiating the attack
	private GameObject mPlayerObject; //The player object
	private GameObject mEnemyObject; //The enemy object
	private bool mPLayerInitiating; //Is the player unit initiating?
	private bool mPlayerRanged; //Is the player attacking at range?
	private bool mEnemyRanged; //Is the enemy attacking at range?

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

	public void setPlayerRanged(bool nRanged)
	{
		mPlayerRanged = nRanged;
	}

	public bool getPlayerRanged()
	{
		return mPlayerRanged;
	}

	public void setEnemyRanged(bool nRanged)
	{
		mEnemyRanged = nRanged;
	}

	public bool getEnemyRanged()
	{
		return mEnemyRanged;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMachine : MonoBehaviour {

	public int maxPlayers = 10;
	public int maxEnemies = 10;
    //bool mPlayerTurn = true;
    
	//Player Army Values
	GameObject[] mPlayerArmy;
	int mPlayerArmyIndex = 0;

	//Enemy army values
	GameObject[] mEnemyArmy;
	int mEnemyArmyIndex = 0;

    //EnemyObject[] enemyArmy;
    GameObject [,] mBattleArray;
    int mBattlePlayerIndex = 0;
    int mBattleEnemyIndex = 0;
    int mPlayerMoves = 1;
    int tmpsize1 = 10;
    int tmpsize2 = 10;

	bool mPlayerFlag = false;
	bool mEnemyFlag = false;
    

	void Start () {
        mBattleArray = new GameObject[tmpsize1, tmpsize2];
		mEnemyArmy = new GameObject[maxEnemies];
		mPlayerArmy = new GameObject[maxPlayers];

	}
	
	
	void Update () {
		if (mPlayerMoves == 0) {
			//Switch to enemy phase
			print ("Enemy's turn");
		} 
		else if (mPlayerFlag && mEnemyFlag) 
		{
			mPlayerFlag = false;
			mEnemyFlag = false;
			mBattleEnemyIndex++;
			mBattlePlayerIndex++;
		}
	}

    public void init()
    {

    }

    public void recievePlayerMessage(int message)
    {
        switch(message)
        {
            //Movement Event
            case 0:
                mPlayerMoves--;
                break;
            
            //Attack Event
            case 1:
                mPlayerMoves--;
                break;
        }
    }

    public void recievEnemyMessage()
    {

    }


	public void RecieveEvent()
	{
		
	}

    public void recievePlayer(GameObject playerObj)
    {
        mBattleArray[mBattlePlayerIndex, mBattleEnemyIndex] = playerObj;
		mPlayerFlag = true;
        
    }
    public void recieveEnemy(GameObject enemyObj)
    {
        mBattleArray[mBattlePlayerIndex, mBattleEnemyIndex] = enemyObj;
		mEnemyFlag = true;
    }
	/*public void RegesterPlayer (GameObject playerObj)
	{
		mPlayerArmy[mPlayerArmyIndex] = 
	}

	public void RegisterEnemy (GameObject enemyObj)
	{
		
	}*/
}

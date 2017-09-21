using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMachine : MonoBehaviour {


    //bool mPlayerTurn = true;
    //PlayerObject[] playerArmy;
    //EnemyObject[] enemyArmy;
    GameObject [,] mBattleArray;
    int mBattlePlayerIndex = 0;
    int mBattleEnemyIndex = 0;
    int mPlayerMoves = 1;
    int tmpsize1 = 10;
    int tmpsize2 = 10;
    
	void Start () {
        mBattleArray = new GameObject[tmpsize1, tmpsize2];
	}
	
	
	void Update () {
		if (mPlayerMoves == 0)
        {
            //Switch to enemy phase
            print("Enemy's turn");
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

    public void recievePlayer(GameObject playerObj)
    {
        mBattleArray[mBattlePlayerIndex, mBattleEnemyIndex] = playerObj;
        //mBattlePlayerIndex++;
    }
    public void recieveEnemy(GameObject enemyObj)
    {
        mBattleArray[mBattlePlayerIndex, mBattleEnemyIndex] = enemyObj;
        
    }
}

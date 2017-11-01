using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMachine : MonoBehaviour {

    //Enemy army values
	List<GameObject> mpEnemyList = new List<GameObject>();

    //List<GameObject[]> mpBattleList;
	[SerializeField]
	List<BattleObject>mpBattleList;
   
	GameObject mPlayerUnit;
	GameObject mEnemyObject;
	bool mPLayerInitiating = false;
	bool mEnemyInitiating = false;
	int mBattleIndex;
	string battleID;

    const int BATTLE_ARRAY_SIZE = 2;

    public bool playerBattleFlag = false;
	public bool enemyBattleFlag = false;
    
    //The moves left
	int mPlayerMoves = 0;
	int mEnemyMoves = 0;
    

    // Script to the list manager
    ListManager mpListManager;

    
	void Start () {
		mpListManager = GameObject.Find("GameSystem").GetComponent<ListManager>();
       
		mpBattleList = new List<BattleObject>();
        mPlayerMoves = mpListManager.getBattleListCount();
    }
	
	
	void Update () {
		if (mPlayerMoves == 0) {
			//Switch to enemy phase
			EnemyTurn();
			resetPlayers();
		} 
		if(playerBattleFlag && enemyBattleFlag)
		{
            playerBattleFlag = false;
			enemyBattleFlag = false;
			loadBattle();
			conductBattle();

		}
	}

    public void recievePlayerMessage(int message)
    {
        switch(message)
        {
            //Attack Event
            case 1:
                mPlayerMoves--;
                break;
		case 4: 
			mPlayerMoves--;
			break;
        }
    }

    public void registerEnemy(GameObject enemyObject)
    {
        print (enemyObject.GetComponent<BaseCharacter>().getName());
        mpEnemyList.Add(enemyObject);
        mEnemyMoves++;
    }

	public void recieveBattlingPlayer(GameObject playerObj, bool isInitiating)
	{
		print (playerObj.GetComponent<BaseCharacter>().getName());
		mPlayerUnit = playerObj;
		mPLayerInitiating = isInitiating;
		playerBattleFlag = true;
        
	
    }
	public void recieveBattlingEnemy(GameObject enemyObj, bool isInitiating)
    {
		print (enemyObj.GetComponent<BaseCharacter>().getName());
		mEnemyObject = enemyObj;
		mEnemyInitiating = isInitiating;
		enemyBattleFlag = true;


    }


	void loadBattle ()
	{
		
		BattleObject newBattle;

		if(mPLayerInitiating)
			battleID = mPlayerUnit.GetComponent<BaseCharacter>().getName();
		else 
			battleID = mEnemyObject.GetComponent<BaseCharacter>().getName();

		newBattle = new BattleObject ();
		newBattle.setBattleID(battleID);
		newBattle.setPlayerObject(mPlayerUnit);
		newBattle.setEnemyObject(mEnemyObject);
		newBattle.setPlayerInitiation(mPLayerInitiating);
		mpBattleList.Add(newBattle);
	}



	public void conductBattle()
	{
		print("Conducting battle");
		int i;
		//Search for the attacking object
		for ( i = 0; i < mpBattleList.Count; i++)
		{
			if(battleID == mpBattleList[i].getBattleID()) //Find the index that the battle is contained in
				break;
		}

		BaseCharacter tmpPlayer = mpBattleList[i].getPlayerObject().GetComponent<BaseCharacter>(); //Cache player base stats
		BaseCharacter tmpEnemy = mpBattleList[i].getEnemyObject().GetComponent<BaseCharacter>(); //Cache the enemy base stats

		if(mpBattleList[i].getPlayerInitiation()) //If the player is initiating, have the player deal damage first
		{
			if( tmpPlayer.getAttack() - tmpEnemy.getDefense()> 0)
			{
				tmpEnemy.setHealth(tmpEnemy.getHealth() - ( tmpPlayer.getAttack() - tmpEnemy.getDefense()));
			}
				
			if(!tmpEnemy.isDead)
				if( tmpEnemy.getAttack() - tmpPlayer.getDefense()> 0)
				tmpPlayer.setHealth(tmpPlayer.getHealth() - (tmpEnemy.getAttack() - tmpPlayer.getDefense()));
		}
		else //The enemy attacks first
		{
			if( tmpEnemy.getAttack() - tmpPlayer.getDefense()> 0)
				tmpPlayer.setHealth(tmpPlayer.getHealth() - (tmpEnemy.getAttack() - tmpPlayer.getDefense()));
			if(!tmpPlayer.isDead)
				if( tmpPlayer.getAttack() - tmpEnemy.getDefense() > 0)
				tmpEnemy.setHealth(tmpEnemy.getHealth() - (tmpPlayer.getAttack() - tmpEnemy.getDefense()));
		}
	}


	public void battleFlee(string name)
	{

	}


	void EnemyTurn()
	{
		EnemyController iter;

		for (int i = 0; i < mpEnemyList.Count; i++)
		{
			iter = mpEnemyList[i].GetComponent<EnemyController>();
			iter.initAI();
		}

	}

	void resetPlayers()
	{
		UiController iter;

		for(int i = 0; i < mpListManager.getBattleListCount(); i++)
		{
			iter = mpListManager.getBattleUnit(i).GetComponent<UiController>();
			iter.resetTurn();
		}
		mPlayerMoves = mpListManager.getBattleListCount();
	}




}

    

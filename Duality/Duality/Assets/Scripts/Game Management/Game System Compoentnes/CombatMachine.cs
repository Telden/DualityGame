using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMachine : MonoBehaviour {

    //Enemy army values
    List<GameObject> mpEnemyList;

    //EnemyObject[] enemyArmy;
    List<GameObject[]> mpBattleList;

    GameObject[] mBattleArray;
    const int BATTLE_ARRAY_SIZE = 2;

    public bool playerBattleFlag = false;
	public bool enemyBattleFlag = false;
    
    //The moves left
	int mPlayerMoves = 0;
	int mEnemyMoves = 0;
    

    // Script to the list manager
    public ListManager mpListManager;

   
    
	void Start () {
        mpEnemyList = new List<GameObject>();
        mpBattleList = new List<GameObject[]>();
        mPlayerMoves = mpListManager.getBattleListCount();
        mBattleArray = new GameObject[BATTLE_ARRAY_SIZE];
        for(int i = 0; i < BATTLE_ARRAY_SIZE; i++)
        {
            mBattleArray[i] = null;
        }
    }
	
	
	void Update () {
		if (mPlayerMoves == 0) {
			//Switch to enemy phase
			EnemyTurn();
			resetPlayers();
		} 
		if(playerBattleFlag && enemyBattleFlag)
		{
            mpBattleList.Add(mBattleArray);
            mBattleArray = new GameObject[BATTLE_ARRAY_SIZE];
            for (int i = 0; i < BATTLE_ARRAY_SIZE; i++)
            {
                mBattleArray[i] = null;
            }
            playerBattleFlag = false;
			enemyBattleFlag = false;
		}
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

    public void recieveBattlingPlayer(GameObject playerObj)
	{
		print("recieved " + playerObj.GetComponent<BaseCharacter>().getName());

        if (mBattleArray[0] == null)
            mBattleArray[0] = playerObj;
        else
            mBattleArray[1] = playerObj;

		playerBattleFlag = true;
        
    }
    public void recieveBattlingEnemy(GameObject enemyObj)
    {
		print("recieved " + enemyObj.name);

        if (mBattleArray[0] == null)
            mBattleArray[0] = enemyObj;
        else
            mBattleArray[1] = enemyObj;

        enemyBattleFlag = true;
    }

	public void conductBattle(string name)
	{
		print("Recieved Battle");
		int row = 0;
		int character = 0;
		BaseCharacter search;

		//Search for the attacking object
		do{
			search = mpBattleList[row][character].GetComponent<BaseCharacter>();
			print(search.getName());
			if(search.getName() != name)
			{
				if(character == 0)
					character = 1;

				else if (character == 1)
				{
					character = 0;
					row++;
				}
			}
		}while(row < mpBattleList.Count || search.getName() != name);

		print("Done with while");
		if(character == 0)
		{
			//Search for the enemy object
			BaseCharacter enemy = mpBattleList[row][1].GetComponent<BaseCharacter>();

			//Deal Damage to the enemy
			float damage = search.getAttack() - enemy.getDefense();
			if(damage < 1)
			{
				print(enemy.getName() + " takes to damage");
			}
			else 
			{
				print ("Dealing " + damage + " damage to " + enemy.getName());
				enemy.setHealth(enemy.getHealth()-damage);
			}
				


			//Deal damage to the attacker
			if(!enemy.isDead)
			{
				damage = enemy.getAttack() - search.getDefense();
				if(damage < 1)
				{
					print(search.getName() + " takes to damage");
				}
				else 
				{
					print("Dealing " + damage + " damage to " + search.getName());
					search.setHealth(search.getHealth()-damage);
				}
					

			}
		}

		else if(character == 1)
		{
            //Search for the enemy object
            BaseCharacter enemy = mpBattleList[row][0].GetComponent<BaseCharacter>();

            //Deal Damage to the enemy
            float damage = search.getAttack() - enemy.getDefense();
			if(damage < 1)
			{
				print(enemy.getName() + " takes to damage");
			}
			else 
			{
				print ("Dealing " + damage + " damage to " + enemy.getName());
				enemy.setHealth(enemy.getHealth()-damage);
			}


			//Deal damage to the attacker
			if(!enemy.isDead)
			{
				damage = enemy.getAttack() - search.getDefense();
				if(damage < 1)
				{
					print(search.getName() + " takes to damage");
				}
				else 
				{
					print("Dealing " + damage + " damage to " + search.getName());
					search.setHealth(search.getHealth()-damage);
				}
		}
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

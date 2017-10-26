using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMachine : MonoBehaviour {

    //Enemy army values
    List<GameObject> mpEnemyList;

    //EnemyObject[] enemyArmy;
    List<GameObject[,]> mpBattleList;
	int mBattleRow;
	int mBattleMember;
    

	public bool playerBattleFlag = false;
	public bool enemyBattleFlag = false;
    
    //The moves left
	int mPlayerMoves = 0;
	int mEnemyMoves = 0;

    // Script to the list manager
    public ListManager mpListManager;

   
    
	void Start () {
        mpEnemyList = new List<GameObject>();
        mpBattleList = new List<GameObject[,]>();
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
			mBattleRow++;
			playerBattleFlag = false;
			enemyBattleFlag = false;
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
		case 4: 
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
		print("recieved " + playerObj.GetComponent<BaseCharacter>().getName());
		mBattleArray[mBattleRow,mBattleMember] = playerObj;
		if(mBattleMember == 1)
			mBattleMember = 0;
		else 
			mBattleMember = 1;
		playerBattleFlag = true;
        
    }
    public void recieveEnemy(GameObject enemyObj)
    {
		print("recieved " + enemyObj.name);
		mBattleArray[mBattleRow, mBattleMember] = enemyObj;
		if(mBattleMember == 1)
			mBattleMember = 0;
		else 
			mBattleMember = 1;

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
			search = mBattleArray[row, character].GetComponent<BaseCharacter>();
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
		}while(row < mBattleRow || search.getName() != name);

		print("Done with while");
		if(character == 0)
		{
			//Search for the enemy object
			BaseCharacter enemy = mBattleArray[row, character +1].GetComponent<BaseCharacter>();

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
			BaseCharacter enemy = mBattleArray[row, character - 1].GetComponent<BaseCharacter>();

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
   

	public void registerEnemy(GameObject enemyObject)
	{
		/*print (enemyObject.GetComponent<BaseCharacter>().getName());*/
		//mEnemyArmy[mEnemyArmyIndex] = enemyObject;
		//mEnemyArmyIndex++;
		mEnemyMoves++;
	}

	void EnemyTurn()
	{
       // EnemyController iter;

        //for (int i = 0; i < mEnemyArmyIndex; i++)
        //{
          //  iter = mEnemyArmy[i].GetComponent<EnemyController>();
           // iter.initAI(mPlayerArmy, mPlayerArmyIndex);
        //}

    }

	void resetPlayers()
	{
		UiController iter;

		for(int i = 0; i < mPlayerArmyIndex; i++)
		{
			iter = mPlayerArmy[i].GetComponent<UiController>();
			iter.resetTurn();
		}
		mPlayerMoves = 5;
	}


}

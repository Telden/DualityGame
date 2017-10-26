using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

//
public class Character_Randomization : MonoBehaviour {

    public TextAsset firstNames; //Text asset that contains all the possible first names
    public TextAsset lastNames; //Text asset that contains all the possible last names
	public GameObject PlayerObject;

    public ListManager mpListManager; //Script to the list manager 
    string firstname; //The randomly selected firstname
    string lastname; //The randomly selected lastname
    int seed; //The random seed generated for selecting a random stat
    float previousSeed; //variable used for 
    float stat; //The amount that a stat will be increased/decreased by
    float randomStat; //Variable to set the new stat with
    string newName = ""; //Variable to set the randomized name


   
    // Use this for initialization
    void Start () {

        

    }
	
	// Update is called once per frame
	void Update () {
        
	}

	//Num is the number of desired characters that the game wants to be made
	public void generateCharacter(int num)
    {

        //Load text files
        string[] fn = firstNames.text.Split("\n"[0]);
        string[] ln = lastNames.text.Split("\n"[0]);


		GameObject newPlayer;
        BaseCharacter newCharacter;

        //Randomly generate possible units
        for (int i = 0; i < num; i++)
        {
            mpListManager.addRandomizedUnit(Instantiate(PlayerObject));
            newPlayer = mpListManager.getRandomizedUnit(i);
			newCharacter = newPlayer.GetComponent<BaseCharacter>();

            //Generate first name
            seed = Random.Range(0, fn.Length);
            firstname = fn[seed];

            //Generate last name;
            seed = Random.Range(0, ln.Length);
            lastname = ln[seed];

            newName = firstname + " " + lastname;
            newCharacter.setName(newName);
            

            // randomly select a random stat
            seed = Random.Range(1, 6);
            // Save the previous seed
            previousSeed = seed;
            // randomly select how much that stat will be increased by
			for (int j = 0; j < 10; j++)
			{
				stat = Random.Range (0, 9);

				do {
					seed = Random.Range (1, 7);
				} while (seed == previousSeed);

				previousSeed = seed;

				switch (seed) {
				case 6:
                    //Debug.Log("Health is being increased by " + stat);
					randomStat = newCharacter.getHealth () + stat;
					newCharacter.setHealth (randomStat);
					break;
				case 5:
                    //Debug.Log("Attack is being increased by " + stat);
					randomStat = newCharacter.getAttack () + stat;
					newCharacter.setAttack (randomStat);
					break;
				case 4:
                    //Debug.Log("Magic is being increased by " + stat);
					randomStat = newCharacter.getMagic () + stat;
					newCharacter.setMagic (randomStat);
					break;
				case 3:
                    //Debug.Log("Defense is being increased by " + stat);
					randomStat = newCharacter.getDefense () + stat;
					newCharacter.setDefense (randomStat);
					break;
				case 2:
                    //Debug.Log("Magic defense is being increased by " + stat);
					randomStat = newCharacter.getMagicDefense () + stat;
					newCharacter.setMagicDefense (randomStat);
					break;
				case 1:
                    //Debug.Log("Speed is being increased by " + stat);
					randomStat = newCharacter.getSpeed () + stat;
					newCharacter.setSpeed (randomStat);
					break;
				default:
					print ("Something didn't work in the random stat increase switch");
					break;
				}
            
				//make sure that the program does not select the same stat to change twice and slect a stat to decrease
				do {
					seed = Random.Range (1, 7);
				} while (seed == previousSeed);
				previousSeed = seed;
				switch (seed) {
				case 6:
                   // Debug.Log("Health is being decreased by " + stat);
					randomStat = newCharacter.getHealth () - stat;
					if(randomStat < 1)
					newCharacter.setHealth (1);
					else
					newCharacter.setHealth (randomStat);
					break;
				case 5:
                    //Debug.Log("Attack is being decreased by " + stat);
					randomStat = newCharacter.getAttack () - stat;
					if(randomStat < 1)
						newCharacter.setAttack (1);
					else
						newCharacter.setAttack (randomStat);
					break;
				case 4:
                   // Debug.Log("Magic is being decreased by " + stat);
					randomStat = newCharacter.getMagic () - stat;
					if (randomStat < 1)
						newCharacter.setMagic (1);
					else
						newCharacter.setMagic (randomStat);
					break;
				case 3:
                   // Debug.Log("Defense is being decreased by " + stat);
					randomStat = newCharacter.getDefense () - stat;
					if (randomStat < 1)
						newCharacter.setDefense (1);
					else
						newCharacter.setDefense (randomStat);
					break;
				case 2:
                    //Debug.Log("Magic defense is being increased by " + stat)
					randomStat = newCharacter.getMagicDefense () - stat;
					if (randomStat < 1)
						newCharacter.setMagicDefense (1);
					else 
						newCharacter.setMagicDefense (randomStat);					
					break;
				case 1:
                    //Debug.Log("Speed is being increased by " + stat);
					randomStat = newCharacter.getSpeed () - stat;
					if (randomStat < 1)
						newCharacter.setSpeed (1);
					else
						newCharacter.setSpeed (randomStat);
					break;

				default:
					print ("Something didn't work in the random stat decrease switch");
					break;

				}
			}
           
         
		}
        
    }

	
}
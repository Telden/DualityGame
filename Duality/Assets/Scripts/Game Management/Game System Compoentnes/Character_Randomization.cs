using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

//
public class Character_Randomization : MonoBehaviour {
    public TextAsset firstNames;
    public TextAsset lastNames;
    public Button generateButton;
    string text;
    string firstname;
    string lastname;
    int seed;
    float previousSeed;
    float stat;
    float randomStat;
    string newName = "";
   
    // Use this for initialization
    void Start () {
        Button btn = generateButton.GetComponent<Button>();
        btn.onClick.AddListener(generateCharacter);
  
    }
	
	// Update is called once per frame
	void Update () {
        //generateCharacter();
	}
    public void generateCharacter()
    {
        //Load text files
        string[] fn = firstNames.text.Split("\n"[0]);
        string[] ln = lastNames.text.Split("\n"[0]);
        BaseCharacter tester = new BaseCharacter();
        

        for(int i = 0; i < 19; i++)
        {
            BaseCharacter newCharacter = new BaseCharacter();

            //Generate first name
            seed = Random.Range(0, fn.Length);
            firstname = fn[seed];

            //Generate last name;
            seed = Random.Range(0, ln.Length);
            lastname = ln[seed];

            newName = firstname + " " + lastname;
            newCharacter.setName(newName);
            //Debug.Log(newName);

            // randomly select a random stat
            seed = Random.Range(1, 6);
            // Save the previous seed
            previousSeed = seed;
            // randomly select how much that stat will be increased by
            stat = Random.Range(0, 9);
            //Debug.Log("Increase seed is " + stat);
            //Debug.Log("Random stat seed is " + seed);
            switch (seed)
            {
                case 6:
                    //Debug.Log("Health is being increased by " + stat);
                    randomStat = newCharacter.getHealth() + stat;
                    newCharacter.setHealth(randomStat);
                    break;
                case 5:
                    //Debug.Log("Attack is being increased by " + stat);
                    randomStat = newCharacter.getAttack() + stat;
                    newCharacter.setAttack(randomStat);
                    break;
                case 4:
                    //Debug.Log("Magic is being increased by " + stat);
                    randomStat = newCharacter.getMagic() + stat;
                    newCharacter.setMagic(randomStat);
                    break;
                case 3:
                    //Debug.Log("Defense is being increased by " + stat);
                    randomStat = newCharacter.getDefense() + stat;
                    newCharacter.setDefense(randomStat);
                    break;
                case 2:
                    //Debug.Log("Magic defense is being increased by " + stat);
                    randomStat = newCharacter.getMagicDefense() + stat;
                    newCharacter.setMagicDefense(randomStat);
                    break;
                case 1:
                    //Debug.Log("Speed is being increased by " + stat);
                    randomStat = newCharacter.getSpeed() + stat;
                    newCharacter.setSpeed(randomStat);
                    break;
                default:
                    print("Something didn't work in the random stat increase switch");
                    break;
            }
            //make sure that the program does not select the same stat to change twice and slect a stat to decrease
            do
            {
                seed = Random.Range(1, 6);
            } while (seed == previousSeed);

            //Debug.Log("Decrease seed is " + stat);
           // Debug.Log("Random stat seed is " + seed);
            switch (seed)
            {
                case 6:
                   // Debug.Log("Health is being decreased by " + stat);
                    randomStat = newCharacter.getHealth() - stat;
                    newCharacter.setHealth(randomStat);
                    break;
                case 5:
                    //Debug.Log("Attack is being decreased by " + stat);
                    randomStat = newCharacter.getAttack() - stat;
                    newCharacter.setAttack(randomStat);
                    break;
                case 4:
                   // Debug.Log("Magic is being decreased by " + stat);
                    randomStat = newCharacter.getMagic() - stat;
                    newCharacter.setMagic(randomStat);
                    break;
                case 3:
                   // Debug.Log("Defense is being decreased by " + stat);
                    randomStat = newCharacter.getDefense() - stat;
                    newCharacter.setDefense(randomStat);
                    break;
                case 2:
                    //Debug.Log("Magic defense is being increased by " + stat);
                    randomStat = newCharacter.getMagicDefense() - stat;
                    newCharacter.setMagicDefense(randomStat);
                    break;
                case 1:
                    //Debug.Log("Speed is being increased by " + stat);
                    randomStat = newCharacter.getSpeed() - stat;
                    newCharacter.setSpeed(randomStat);
                    break;

                default:
                    print("Something didn't work in the random stat decrease switch");
                    break;

            }

            GameObject.Find("GameSystem").GetComponent<Game>().insertCharacter(newCharacter);

            
            tester = GameObject.Find("GameSystem").GetComponent<Game>().getCharacter(i);

            //Output the character variables to the console
            print("Name: " + tester.getName());
            print("Health: " + tester.getHealth());
            print("Attack: " + tester.getAttack());
            print("Magic: " + tester.getMagic());
            print("Defense: " + tester.getDefense());
            print("Magic Defense: " + tester.getMagicDefense());
            print("Speed: " + tester.getSpeed());

        }
    }
}
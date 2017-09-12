using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;

//http://answers.unity3d.com/questions/279750/loading-data-from-a-txt-file-c.html
public class Character_Randomization : MonoBehaviour {
    BaseCharacter newCharacter;
    int seed;
    float previousSeed;
    float stat;
    float randomStat;
    string fileOne = "firstnames.txt";
    string fileTwo = "lastnames.txt";
    string firstname = "";
    string lastname = "";
    string newName = "";
    public TextAsset firstNames;
    public TextAsset lastNames;
    // Use this for initialization
    void Start () {
        
  
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void generateCharacter()
    {
        StreamReader istream = new StreamReader(fileOne, Encoding.Default);
        seed = Random.Range(0, 9);

        for (int i = 0; i < seed; i++)
        {
            using (istream)
            {
                firstname = istream.ReadLine();
            }
        }
        istream.Close();

        StreamReader ifstream = new StreamReader(fileTwo, Encoding.Default);
        seed = Random.Range(0, 9);
        for (int i = 0; i < seed; i++)
        {
            using (istream)
            {
                lastname = ifstream.ReadLine();
            }
        }
        ifstream.Close();

        newName = firstname + lastname;
        newCharacter.setName(newName);

        // randomly select a random stat
        seed = Random.Range(0, 4);
        // Save the previous seed
        previousSeed = seed;
        // randomly select how much that stat will be increased by
        stat = Random.Range(0, 9);
        switch (seed)
        {
            case 4:
                randomStat = newCharacter.getHealth() + stat;
                newCharacter.setHealth(randomStat);
                break;
            case 3:
                randomStat = newCharacter.getAttack() + stat;
                newCharacter.setAttack(randomStat);
                break;
            case 2:
                randomStat = newCharacter.getMagic() + stat;
                newCharacter.setMagic(randomStat);
                break;
            case 1:
                randomStat = newCharacter.getDefense() + stat;
                newCharacter.setDefense(randomStat);
                break;

            default:
                print("Something didn't work in the random stat increase switch");
                break;
        }
        //make sure that the program does not select the same stat to change twice and slect a stat to decrease
        do
        {
            seed = Random.Range(0, 4);
        } while (seed == previousSeed);

        switch (seed)
        {
            case 4:
                randomStat = newCharacter.getHealth() - stat;
                newCharacter.setHealth(randomStat);
                break;
            case 3:
                randomStat = newCharacter.getAttack() - stat;
                newCharacter.setAttack(randomStat);
                break;
            case 2:
                randomStat = newCharacter.getMagic() - stat;
                newCharacter.setMagic(randomStat);
                break;
            case 1:
                randomStat = newCharacter.getDefense() - stat;
                newCharacter.setDefense(randomStat);
                break;

            default:
                print("Something didn't work in the random stat decrease switch");
                break;

        }

        //Output the character variables to the console
        print("Name: " + newCharacter.getName());
        print ("Health: " + newCharacter.getHealth());
        print("Attack: " + newCharacter.getAttack());
        print("Magic: " + newCharacter.getMagic());
        print("Defense: " + newCharacter.getDefense());
    }
}
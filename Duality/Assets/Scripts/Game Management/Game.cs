using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    GameObject[] mGenCharacterArray;
    public int mMaxCharacters = 10;
    public CombatMachine combatScript;
    //public BaseCharacter[] mArmyCharacterArray;
    int mTotalCharacters = 0;


	// Use this for initialization
	void Start () {
        //combatScript.enabled = false;
		gameObject.GetComponent<Character_Randomization>().generateCharacter(mMaxCharacters);
	}
	
	// Update is called once per frame
	void Update () {
		mGenCharacterArray = new GameObject[mMaxCharacters];

    }

    //Insert a randomly generated character into the generated characters array
    public void insertCharacter(GameObject nCharacter)
    {
       
        mGenCharacterArray[mTotalCharacters] = nCharacter;
        increaseTotalSize();
    }

	public GameObject getCharacter(int index)
    {
        return mGenCharacterArray[index];
    }

    //Increase the total characters integer for the created characters array
    void increaseTotalSize()
    {
        mTotalCharacters++; 
    }

    //Decrase the total characters integer for the created character array
    void decreaseTotalSize()
    {
        mTotalCharacters--;
    }

    void startBattleMachine()
    {
        //combatScript.enabled = false;
        //combatScript.init();
    }
}

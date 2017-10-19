﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    
    public int mMaxCharacters;
    int mCharacterIndex;

	// Use this for initialization
	void Start () {

        mCharacterIndex = 0;
        DontDestroyOnLoad(gameObject.transform);
        //combatScript.enabled = false;
        //gameObject.GetComponent<Character_Randomization>().generateCharacter(mMaxCharacters);

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.L))
        {
            gameObject.GetComponent<Character_Randomization>().generateCharacter(mMaxCharacters);
        }

    }

  public void addCharacter(GameObject newCharacter)
    {
       // mSelectedCharacters[mCharacterIndex] = newCharacter;
        //mCharacterIndex++;
        //for(int i = 0; i < mMaxCharacters; i++)
        //{
        //    if (mSelectedCharacters[i] == null)
        //    {
        //        mSelectedCharacters[i] = newCharacter;
        //        break;
        //    }
        //}
    }


}

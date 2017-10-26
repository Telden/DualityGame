using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    
    public int mMaxCharacters;

	// Use this for initialization
	void Start () {
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

}

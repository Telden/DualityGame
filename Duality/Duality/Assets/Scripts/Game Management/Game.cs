using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    
    public int mMaxCharacters = 10;
    


	// Use this for initialization
	void Start () {
        //combatScript.enabled = false;
		gameObject.GetComponent<Character_Randomization>().generateCharacter(mMaxCharacters);

	}
	
	// Update is called once per frame
	void Update () {
		

    }


}

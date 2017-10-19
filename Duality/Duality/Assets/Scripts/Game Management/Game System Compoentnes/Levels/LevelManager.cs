using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    List<Level> mpLevelList; //List of all the game's levels
    public Canvas mLevelSelectCanvas;
    public Button mTutorial;
	// Use this for initialization
	void Start () {
        mpLevelList = new List<Level>();
        Button tmp = mTutorial.GetComponent<Button>();
        tmp.onClick.AddListener(loadTutorial);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void loadTutorial()
    {
        mpLevelList[0].init();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	//Mission Select Canvas
	public Canvas mMissionSelectCanvas;

    public List<Level> mpLevelList; //List of all the game's levels
	public List<Button> mpLevelButtonList;
	public MainMenu mpMainMenu;
    public Button mBackButton;

    //bool mActive = false;
	// Use this for initialization
	void Start () {
		mMissionSelectCanvas.enabled = false;
        Button tmp = mBackButton.GetComponent<Button>();
        tmp.onClick.AddListener(exitMenu);

	}
	
	// Update is called once per frame
	void Update () {
        //if(mActive)
		    //if (Input.GetKeyDown(KeyCode.Escape))
      //      {
      //          mActive = false;
      //          exitMenu();
      //      }

    }

	public void init()
	{
        //mActive = true;
		mMissionSelectCanvas.enabled = true;
		linkButtons();
	}

	void linkButtons()
	{
		for(int i = 0; i < mpLevelButtonList.Count; i++)
		{
			Button tmp = mpLevelButtonList[i].GetComponent<Button>();
			tmp.onClick.AddListener(mpLevelList[i].init);
		}

	}

    public void exitMenu()
    {
        mMissionSelectCanvas.enabled = false;
        mpMainMenu.reset();
    }
}

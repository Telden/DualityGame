using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    //Main menu canvas
    public Canvas mMainMenuCanvas;
    public Button mMissionSelect;
    public Button mArmyViewer;
    public Button mArmyRecruit;
    public Button mExitButton;

    // Army Recruitment Canvas
    public Canvas mArmyRecruitmentCanvas;

    // View Army canvas
    public Canvas mViewArmyCanvas;


    //Main Menu Functions
    public Recruitment mpRecruitment;
    public ViewArmy mpViewArmy;
	public LevelManager mpLevelManager;

    // Use this for initialization
    void Start () {

       mArmyRecruitmentCanvas.enabled = false;
        mViewArmyCanvas.enabled = false;
       
        Button tmp = mArmyRecruit.GetComponent<Button>();
        tmp.onClick.AddListener(Recruitment);
        tmp = mArmyViewer.GetComponent<Button>();
        tmp.onClick.AddListener(viewArmy);
        tmp = mMissionSelect.GetComponent<Button>();
        tmp.onClick.AddListener(missionSelect);
		tmp = mExitButton.GetComponent<Button>();
		tmp.onClick.AddListener(quit);
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    reset();
        //}
    }

    public void reset()
    {
        mMainMenuCanvas.enabled = true;
        mArmyRecruitmentCanvas.enabled = false;
        mViewArmyCanvas.enabled = false;
        
    }
    void Recruitment()
    {
        print("Button Pressed");
        mMainMenuCanvas.enabled = false;
        mArmyRecruitmentCanvas.enabled = true;
        mpRecruitment.init();
        
    }

    void viewArmy()
    {
        mMainMenuCanvas.enabled = false;
        mViewArmyCanvas.enabled = true;
        //mpViewArmy.init();
    }

    void missionSelect()
    {
        mMainMenuCanvas.enabled = false;
		mpLevelManager.init();
    }

    void quit()
    {
		print("Quit");
        Application.Quit();
    }
}

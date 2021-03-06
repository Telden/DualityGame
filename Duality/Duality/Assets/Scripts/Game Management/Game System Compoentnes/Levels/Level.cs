﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Level : MonoBehaviour {

	[SerializeField]
	private int mLevelIndex; //Which level?
    public Canvas mLevelPreviewCanvas; //The overall ui canvas
    public Canvas mMissionSelectCanvas;
	public Image mImagePreview; //Show the layout of the level
	[SerializeField]
	private int mTotalAllowed; //The total number of allowed characters on this level
	[SerializeField]
                                         //Brief Discription of the level
    public ListManager mpListManager;
    public LevelManager mpLevelManager;
    public GameObject mCharacterButton;
    public RectTransform mParentPanel;
    public Button mStartLevelButton;
    int mTotalCharacters;
    int mSlotsLeft;
	bool mActive =  false;
    public Text mTotalSelectedUI;

    // Use this for initialization
    void Start () {
        mLevelPreviewCanvas.enabled = false;
        mImagePreview.enabled = false;
        mSlotsLeft = mTotalAllowed;
        mTotalSelectedUI.text = "Slots left: " + mSlotsLeft.ToString();
        Button tmp = mStartLevelButton.GetComponent<Button>();
        tmp.onClick.AddListener(loadLevel);
    }
	
	// Update is called once per frame
	void Update () {
            checkInput();
    }

    public void init()
    {
		print("Level called");
        mActive = true;
        mLevelPreviewCanvas.enabled = true;
        mTotalCharacters = mpListManager.getArmyListSize();
		showArmy();
        mImagePreview.transform.SetParent(mLevelPreviewCanvas.transform);
        mImagePreview.enabled = true;
        mMissionSelectCanvas.enabled = false;
        mTotalSelectedUI.text = "Slots left: " + mSlotsLeft.ToString();

    }

    void checkInput()
    {
        if(mActive)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("Level escape call");
            mActive = false;
            mLevelPreviewCanvas.enabled = false;
            mImagePreview.enabled = false;
            mMissionSelectCanvas.enabled = true;
            mSlotsLeft = mTotalAllowed;
                mpListManager.clearBattleList();
           cleanPanel();
        }
    }


    public void loadLevel()
    {
        SceneManager.LoadScene(mLevelIndex);
    }

    void showArmy()
    {

        for (int i = 0; i < mTotalCharacters; i++)
        {
            GameObject character = (GameObject)Instantiate(mCharacterButton);
            character.transform.SetParent(mParentPanel.transform);
            character.transform.localScale = new Vector3(1, 1, 1);

            Button tempButton = character.GetComponent<Button>();
            character.transform.GetChild(0).GetComponent<Text>().text = "Name: " + mpListManager.getArmyUnit(i).GetComponent<BaseCharacter>().getName();
            character.transform.GetChild(1).GetComponent<Text>().text = "Health: " + mpListManager.getArmyUnit(i).GetComponent<BaseCharacter>().getHealth();
            character.transform.GetChild(2).GetComponent<Text>().text = "Attack: " + mpListManager.getArmyUnit(i).GetComponent<BaseCharacter>().getAttack();
            character.transform.GetChild(3).GetComponent<Text>().text = "Defense: " + mpListManager.getArmyUnit(i).GetComponent<BaseCharacter>().getDefense();
            character.transform.GetChild(4).GetComponent<Text>().text = "Magic: " + mpListManager.getArmyUnit(i).GetComponent<BaseCharacter>().getMagic();
            character.transform.GetChild(5).GetComponent<Text>().text = "Magic Defense: " + mpListManager.getArmyUnit(i).GetComponent<BaseCharacter>().getMagicDefense();
            character.transform.GetChild(6).GetComponent<Text>().text = "Speed: " + mpListManager.getArmyUnit(i).GetComponent<BaseCharacter>().getSpeed();
            character.transform.GetChild(7).GetComponent<Text>().text = "Movement: " + mpListManager.getArmyUnit(i).GetComponent<BaseCharacter>().getMovement();
            int tempInt = i;

            tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
        }


    }
    void ButtonClicked(int buttonNo)
    {
        if(mSlotsLeft > 0)
        {
            mpListManager.addBattleUnit(mpListManager.getArmyUnit(buttonNo));
            mParentPanel.GetChild(buttonNo).GetComponent<Button>().interactable = false;
            mSlotsLeft--;
            mTotalSelectedUI.text = "Slots left: " + mSlotsLeft.ToString();
        }
       

    }

    void cleanPanel ()
    {
        for (int i = 0; i < mTotalCharacters; i++)
            Destroy(mParentPanel.GetChild(i).gameObject);
    }
}

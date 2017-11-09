﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UiController : MonoBehaviour {

    //Attack menu buttons and canvas
    public Canvas attackMenu;
    public Button Movement;
    public Button Attack;
	public Button Magic;
    public Button Stay;

	//Battle Menu
	public Canvas battleMenuCanvas;
	public Button battleFlee;
	public Button battleAttack;
	public Button BattleMagic;

	// Stats Background
	public Canvas mStatsCanvas;
    public Text uiName;
    public Text uiHealth;
    public Text uiAttack;
    public Text uiDefense;
    public Text uiMagic;
    public Text uiMagicDefense;
    public Text uiSpeed;
	public Text uiClass;
    public Image mHealthBar;
    
	public Slider uiHealthBar;

    //Scripts for the buttons
    private Attack mAttackScript;
    private move mMoveScript;
	CombatMachine mMachinePtr;
	BaseCharacter mBaseScript;

    //
    bool active = false;
    bool OperationFinished = true;
    bool turnFinished = false;
	public bool mBattleStarted = false;


	//Current user of the ui 
	GameObject mCurrentPlayerUnit;
	GameObject mCurrentEnemy;
   

    // Use this for initialization
    void Start()
    {
        Button tmp = Movement.GetComponent<Button>();
        tmp.onClick.AddListener(moveCharacter);
        tmp = Attack.GetComponent<Button>();
        tmp.onClick.AddListener(playerAttack);
        tmp = Stay.GetComponent<Button>();
        tmp.onClick.AddListener(playerStay);
		tmp = Magic.GetComponent<Button> ();
		tmp.onClick.AddListener (playerMagic);


		tmp = battleFlee.GetComponent<Button> ();
		tmp.onClick.AddListener(playerFlee);
		tmp = battleAttack.GetComponent<Button> ();
		tmp.onClick.AddListener(playerAttack);
		tmp = BattleMagic.GetComponent<Button> ();
		tmp.onClick.AddListener(playerMagic);




        //Make sure the ui does not appear yet
        attackMenu.enabled = false;
		battleMenuCanvas.enabled = false;
		mStatsCanvas.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
		
            if (active)
                {
                  checkInput();
				  mHealthBar.fillAmount = updateHealthBar();
                }


    }

	void checkInput()
	{

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			disableUi();
			active = false;
		}
		if(Input.GetKeyDown(KeyCode.R))
		{
			mBaseScript.setHealth(mBaseScript.getHealth() - 2);
		}
	}

	public void battleInit()
	{
		mMachinePtr = GameObject.Find("BattleSystem").GetComponent<CombatMachine>();
	}


	public void init(GameObject unitObj, bool isBattling)
	{
		if(!active)
		{
			mCurrentPlayerUnit = unitObj;
			mAttackScript = mCurrentPlayerUnit.GetComponent<Attack>();
			mMoveScript = mCurrentPlayerUnit.GetComponent<move>();
			mBaseScript = mCurrentPlayerUnit.GetComponent<BaseCharacter>();

			uiName.text = "Name: " + mBaseScript.getName();
			uiHealth.text = "Health: " + mBaseScript.getHealth().ToString();
			uiAttack.text = "Attack: " + mBaseScript.getAttack().ToString();
			uiDefense.text = "Defense: " + mBaseScript.getDefense().ToString();
			uiMagic.text = "Magic: " + mBaseScript.getMagic().ToString();
			uiMagicDefense.text = "Magic Defense: " + mBaseScript.getMagicDefense().ToString();
			uiSpeed.text = "Speed: " + mBaseScript.getSpeed().ToString();
			uiClass.text = "Class: " + mBaseScript.getClass();

			if(!isBattling)
			{
				attackMenu.enabled = true;
				mStatsCanvas.enabled = true;
			}

			else
			{
				battleMenuCanvas.enabled = true;
				mStatsCanvas.enabled = true;
			}
			mCurrentPlayerUnit.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 0f, 1f);
			active = true;
		}


	}

	void disableUi()
	{
		attackMenu.enabled = false;
		battleMenuCanvas.enabled = false;
		mStatsCanvas.enabled = false;
		mCurrentPlayerUnit.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 1f);
	}
		
	/*************************************** PLAYER BUTTON FUNCTIONS *******************************/


    void moveCharacter()
    {
        disableUi();
        active = false;
        OperationFinished = false;
        mMoveScript.init();
	    
    }

    void playerAttack()
    {
		disableUi();
		active = false;
		OperationFinished = false;
        mAttackScript.init();
    }

	void playerMagic()
	{
		disableUi();
		active = false;
		OperationFinished = false;
		mAttackScript.magicInit ();
	}

	void playerStay()
	{
		disableUi();
		active = false;
		mMachinePtr.recievePlayerMessage(4);
		mBaseScript.finishedTurn();
	}

	void playerFlee()
	{
		disableUi();
		active = false;
		OperationFinished = false;
		mAttackScript.flee();
	}
     		


	/************************************************************************************/


	public void finishedFunction()
	{
		OperationFinished = true;
	}




    private float updateHealthBar()
    {
		uiHealth.text = "Health: " + mBaseScript.getHealth().ToString();
        return (mBaseScript.getHealth() - 0) * (1 - 0) / (mBaseScript.getMaxHealth() - 0) + 0;
    }

   
}

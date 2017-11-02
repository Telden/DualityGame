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
    public Button Item;
    public Button Stay;


	//Battle Menu
	public Canvas battleMenuCanvas;
	public Button battleFlee;
	public Button battleAttack;
	public Button BattleMagic;

    public Text uiName;
    public Text uiHealth;
    public Text uiAttack;
    public Text uiDefense;
    public Text uiMagic;
    public Text uiMagicDefense;
    public Text uiSpeed;
    public Image statsBackground;
    public Image mHealthBar;
    
	public Slider uiHealthBar;

    //Scripts for the buttons
    private Attack mAttackScript;
    private move mMoveScript;

	//Particle System
	public ParticleSystem parts;

    //
    bool active = false;
    bool OperationFinished = true;
    bool turnFinished = false;
	bool mBattleStarted = false;
    CombatMachine mMachinePtr;

	BaseCharacter mBaseScript;

    // Use this for initialization
    void Start()
    {
        //Setting all the buttons off so that they do not show until the player moves over the character
        Button tmp = Movement.GetComponent<Button>();
        tmp.onClick.AddListener(moveCharacter);
        tmp = Attack.GetComponent<Button>();
        tmp.onClick.AddListener(playerAttack);
        tmp = Item.GetComponent<Button>();
        tmp.onClick.AddListener(useItem);
        tmp = Stay.GetComponent<Button>();
        tmp.onClick.AddListener(playerStay);
		tmp = Magic.GetComponent<Button> ();
		tmp.onClick.AddListener (playerMagic);

		tmp = battleFlee.GetComponent<Button> ();
		tmp.onClick.AddListener(battleMenuFlee);
		tmp = battleAttack.GetComponent<Button> ();
		tmp.onClick.AddListener(battleMenuAttack);
		tmp = BattleMagic.GetComponent<Button> ();
		tmp.onClick.AddListener(battleMenuMagic);

        //Set up all the scripts
        mAttackScript = transform.Find("AttackHitbox").GetComponent<Attack>();
        mMoveScript = gameObject.GetComponent<move>();
		mBaseScript = gameObject.GetComponent<BaseCharacter>();


        //Make sure the buttons are not interactible yet
        attackMenu.enabled = false;
		battleMenuCanvas.enabled = false;
        Movement.interactable = false;
        Attack.interactable = false;
        Item.interactable = false;
        Stay.interactable = false;
		Magic.interactable = false;
	

        //Disable the battleUI
        statsBackground.enabled = false;
        uiName.enabled = false;
        uiHealth.enabled = false;
        uiAttack.enabled = false;
        uiDefense.enabled = false;
        uiMagic.enabled = false;
        uiMagicDefense.enabled = false;
        uiSpeed.enabled = false;
        mHealthBar.enabled = false;

		parts.Stop();
    }

    // Update is called once per frame
    void Update()
    {
		//uiHealthBar.transform.position = gameObject.transform.position;
       // if(!finished)
            if (active)
                {
                  checkInput();
			      updateUI();
                }
		if(Input.GetKeyDown(KeyCode.S))
        	init();

    }

	public void init()
	{
		mMachinePtr = GameObject.Find("BattleSystem").GetComponent<CombatMachine>();
		mBattleStarted = true;
	}

    void checkInput()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            attackMenu.enabled = false;
            Movement.interactable = false;
            Attack.interactable = false;
            Item.interactable = false;
            Stay.interactable = false;

            active = false;


            //Disable BattleUI
            statsBackground.enabled = false;
            uiName.enabled = false;
            uiHealth.enabled = false;
            uiAttack.enabled = false;
            uiDefense.enabled = false;
            uiMagic.enabled = false;
            uiMagicDefense.enabled = false;
            uiSpeed.enabled = false;
            mHealthBar.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            mBaseScript.setHealth(mBaseScript.getHealth() - 2);
        }
    }

    void OnMouseEnter()
    {
        Debug.Log("Mouse Over");
		if(mBattleStarted) //If the battle scene has started
	        if (!turnFinished) //If the unit has not finished  its turn
	        {
	            if(!mAttackScript.mIsBattling) //Is the  unit fighting?
	            {
	                if (OperationFinished) //if another ui operation is not active
	                {
	                    if (!active) //if the ui is already not active
	                    {
	                        // Debug.Log("Mouse clicked");
	                        attackMenu.enabled = true;
	                        Movement.interactable = true;
	                        Attack.interactable = true;
	                        Item.interactable = true;
	                        Stay.interactable = true;
						   // Magic.interactable = false;
						if (mBaseScript.getClass () == "Wizard")
							Magic.interactable = true;
						else
							Magic.interactable = false;


	                        active = true;

	                        //Enable battleUI
	                        statsBackground.enabled = true;
	                        uiName.enabled = true;
	                        uiHealth.enabled = true;
	                        uiAttack.enabled = true;
	                        uiDefense.enabled = true;
	                        uiMagic.enabled = true;
	                        uiMagicDefense.enabled = true;
	                        uiSpeed.enabled = true;
	                        mHealthBar.enabled = true;


						
	                    }
	                }

				}
			else if(!active)
			{
				battleMenuCanvas.enabled = true;					
				attackMenu.enabled = false;
				if (mBaseScript.getClass () != "Wizard")
					BattleMagic.interactable = false;

				active = true;

				//Enable battleUI
				statsBackground.enabled = true;
				uiName.enabled = true;
				uiHealth.enabled = true;
				uiAttack.enabled = true;
				uiDefense.enabled = true;
				uiMagic.enabled = true;
				uiMagicDefense.enabled = true;
				uiSpeed.enabled = true;
				mHealthBar.enabled = true;
	        }

            
        }        
    }

   void OnMouseExit()
    {
        //if (turnFinished)
        //    statsBackground.enabled = false;
		//battleMenuCanvas.enabled = false;
		//active = false;

    }

    void moveCharacter()
    {
        //print("Moving character");
        attackMenu.enabled = false;
        Movement.interactable = false;
        Attack.interactable = false;
		Magic.interactable = false;
        Item.interactable = false;
        Stay.interactable = false;

        //Disable BattleUI
        statsBackground.enabled = false;
        uiName.enabled = false;
        uiHealth.enabled = false;
        uiAttack.enabled = false;
        uiDefense.enabled = false;
        uiMagic.enabled = false;
        uiMagicDefense.enabled = false;
        uiSpeed.enabled = false;
        mHealthBar.enabled = false;

        active = false;
        OperationFinished = false;
        mMoveScript.init();

        
    }

    void playerAttack()
    {
        //print("Button works");
        attackMenu.enabled = false;
        Movement.interactable = false;
        Attack.interactable = false;
		Magic.interactable = false;
        Item.interactable = false;
        Stay.interactable = false;


        //Disable BattleUI
        statsBackground.enabled = false;
        uiName.enabled = false;
        uiHealth.enabled = false;
        uiAttack.enabled = false;
        uiDefense.enabled = false;
        uiMagic.enabled = false;
        uiMagicDefense.enabled = false;
        uiSpeed.enabled = false;
        mHealthBar.enabled = false;


        OperationFinished = false;
        mAttackScript.init();
    }

	void playerMagic()
	{
		//print("Button works");
		attackMenu.enabled = false;
		Movement.interactable = false;
		Attack.interactable = false;
		Magic.interactable = false;
		Item.interactable = false;
		Stay.interactable = false;

		//Disable BattleUI
		statsBackground.enabled = false;
		uiName.enabled = false;
		uiHealth.enabled = false;
		uiAttack.enabled = false;
		uiDefense.enabled = false;
		uiMagic.enabled = false;
		uiMagicDefense.enabled = false;
		uiSpeed.enabled = false;
		mHealthBar.enabled = false;

		OperationFinished = false;

		mAttackScript.magicInit ();
	}

	void playerFlee()
	{
		//print("Button works");
		attackMenu.enabled = false;
		Movement.interactable = false;
		Attack.interactable = false;
		Magic.interactable = false;
		Item.interactable = false;
		Stay.interactable = false;


		//Disable BattleUI
		statsBackground.enabled = false;
		uiName.enabled = false;
		uiHealth.enabled = false;
		uiAttack.enabled = false;
		uiDefense.enabled = false;
		uiMagic.enabled = false;
		uiMagicDefense.enabled = false;
		uiSpeed.enabled = false;
		mHealthBar.enabled = false;

		OperationFinished = false;

		mAttackScript.flee();
	}
   
    void useItem()
    {
        //print("Button works");
        attackMenu.enabled = false;
        Movement.interactable = false;
        Attack.interactable = false;
		Magic.interactable = false;
        Item.interactable = false;
        Stay.interactable = false;

        //Disable BattleUI
        statsBackground.enabled = false;
        uiName.enabled = false;
        uiHealth.enabled = false;
        uiAttack.enabled = false;
        uiDefense.enabled = false;
        uiMagic.enabled = false;
        uiMagicDefense.enabled = false;
        uiSpeed.enabled = false;
        mHealthBar.enabled = false;

        //use an item 
        finishedTurn();
    }

    void playerStay()
    {
        //print("Button works");
        attackMenu.enabled = false;
        Movement.interactable = false;
        Attack.interactable = false;
		Magic.interactable = false;
        Item.interactable = false;
        Stay.interactable = false;

        //Disable BattleUI
        statsBackground.enabled = false;
        uiName.enabled = false;
        uiHealth.enabled = false;
        uiAttack.enabled = false;
        uiDefense.enabled = false;
        uiMagic.enabled = false;
        uiMagicDefense.enabled = false;
        uiSpeed.enabled = false;
        mHealthBar.enabled = false;

        mMachinePtr.recievePlayerMessage(4);
        finishedTurn();
    }


	void battleMenuAttack()
	{
		battleMenuCanvas.enabled = false;
		active = false;
		mAttackScript.init();
	}

	void battleMenuMagic()
	{
		battleMenuCanvas.enabled = false;
		active = false;
		mAttackScript.magicInit ();
	}

	void battleMenuFlee()
	{
		battleMenuCanvas.enabled = false;
		active = false;
		mAttackScript.flee();
	}







    public void finishedTurn()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f, 0.5f);
        turnFinished = true;
    }

    public void finishedFunction()
    {
        OperationFinished = true;
    }

    public void resetTurn()
    {
		gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 1f);
		if(!mAttackScript.mIsBattling)
			parts.Stop();
        turnFinished = false;
		active = false;

    }

	public void RecieveEvent(EventMessage Message)
	{
		if(Message.myType == EventType.ATTACK_EVENT)
		{
			parts.Play();
			finishedTurn();
		}

		else if(Message.myType == EventType.MOEVMENT_EVENT)
		{
			//do something
		}
		
	}
	void updateUI()
	{
		uiName.text = "Name: " + mBaseScript.getName();
		uiHealth.text = "Health: " + mBaseScript.getHealth().ToString();
		uiAttack.text = "Attack: " + mBaseScript.getAttack().ToString();
		uiDefense.text = "Defense: " + mBaseScript.getDefense().ToString();
		uiMagic.text = "Magic: " + mBaseScript.getMagic().ToString();
		uiMagicDefense.text = "Magic Defense: " + mBaseScript.getMagicDefense().ToString();
		uiSpeed.text = "Speed: " + mBaseScript.getSpeed().ToString();
       //+ mBaseScript.getMovement().ToString();
        mHealthBar.fillAmount = updateHealthBar();
       



    }

    private float updateHealthBar()
    {
        return (mBaseScript.getHealth() - 0) * (1 - 0) / (mBaseScript.getMaxHealth() - 0) + 0;
    }

   
}

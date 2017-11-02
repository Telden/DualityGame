﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Attack : MonoBehaviour {
    public Canvas mAttackCanvas;
    public Button mFightButton;
    public Button mFleeButton;
	public CircleCollider2D mRangedHitbox;
    private BoxCollider2D mAttackHitbox;
    private SpriteRenderer fill;
    Collider2D[] results;
    string [] mTmpName;
    bool active = false;
    public bool mIsBattling = false;
    const  int BATTLE_MESSAGE = 1;
    //Pointer to the UI controller
    UiController mUIptr;
    //Combat  Machine pointer
    CombatMachine mMachinePtr;
	EventMessage mAttackMessage;
	bool mInitialized = false;
	BaseCharacter mpBaseCharacterScript;
	const float ARCHER_RANGE = 10;
	bool mIsRanged= false;



    void Start () {
        mAttackHitbox = gameObject.GetComponent<BoxCollider2D>();
        mAttackHitbox.enabled = false;
        fill = gameObject.GetComponent<SpriteRenderer>();
        fill.enabled = false;
		mRangedHitbox.enabled = false;
        //set pointer to combat machine
//        mMachinePtr = GameObject.Find("BattleSystem").GetComponent<CombatMachine>();
		//mMachinePtr.registerplayer(this.transform.parent.gameObject); //Register the character with the combat machine

        mUIptr = transform.parent.gameObject.GetComponent<UiController>(); //Get the unit's ui controller
		mAttackMessage = new EventMessage(EventType.ATTACK_EVENT);

        // Attack UI elements
        Button tmp = mFightButton.GetComponent<Button>();
        tmp.onClick.AddListener(continueBattle);
        tmp = mFleeButton.GetComponent<Button>();
        tmp.onClick.AddListener(flee);

        mAttackCanvas.enabled = false;
    }
	

	void Update () {
        if(active)
        {
          checkInput();    
        }

			
		
	}

    //turn on the battle state
    public void init()
    {
		if(!mInitialized)
		{
			mMachinePtr = GameObject.Find("BattleSystem").GetComponent<CombatMachine>();
			mpBaseCharacterScript = this.transform.parent.gameObject.GetComponent<BaseCharacter> ();
			if (mpBaseCharacterScript.getClass() == "Archer")
				mRangedHitbox.radius = ARCHER_RANGE;
			mInitialized = true;
		}
		/*if (mIsBattling) {
			mAttackCanvas.enabled = true;*/
		if (mpBaseCharacterScript.getClass () == "Warrior") {
			print ("Attack  Warrior");
			mAttackHitbox.enabled = true;
			fill.enabled = true;
			active = true;

			detectEnemies ();
		} else if (mpBaseCharacterScript.getClass () == "Archer") {
			print ("Archer");
			mRangedHitbox.enabled = true;
			active = true;
			rangedAttack ();
		} else
			print ("Wizard");
		{
			mAttackHitbox.enabled = true;
			fill.enabled = true;
			active = true;
			detectEnemies ();
		}
    }

    void checkInput()
    {
        

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            print("escape key pressed");
            if(mIsBattling)
            {
                mAttackCanvas.enabled = false;
            }
            else
            {
                mAttackHitbox.enabled = false;
                fill.enabled = false;
                active = false;
                for (int i = 0; i < mTmpName.Length; i++)
                {
                    if (mTmpName[i] != null)
                    {
                        GameObject.Find(mTmpName[i]).GetComponent<EnemyController>().resetColor();
                    }
                }
            }
            
        }
        else if (Input.GetMouseButtonDown(0) && !mIsBattling)
        {
            mAttackHitbox.enabled = false;
            fill.enabled = false;
            active = false;
			mUIptr.RecieveEvent(mAttackMessage);
            mMachinePtr.recievePlayerMessage(BATTLE_MESSAGE);
			mMachinePtr.recieveBattlingPlayer(this.transform.parent.gameObject, true, mIsRanged);				
            mIsBattling = true;
            mUIptr.finishedFunction();
			mUIptr.finishedTurn();
        }
    }
    void detectEnemies()
    {
        int i = 0;
        results =  Physics2D.OverlapBoxAll(mAttackHitbox.bounds.center, mAttackHitbox.bounds.extents, LayerMask.GetMask("Enemy"));
        mTmpName = new string[results.Length];
        foreach(Collider2D c in results)
        {
       //     print(c.name);
            if(c.tag == "Enemy")
            {
                mTmpName[i] = c.name;
                i++;
                GameObject.Find(c.name).GetComponent<EnemyController>().Highlight();
            }
            
        }
		mAttackHitbox.enabled = false;
		mIsRanged = false;
    }
	void rangedAttack()
	{
		int i = 0;
		results = Physics2D.OverlapCircleAll (mRangedHitbox.transform.position, mRangedHitbox.radius);
		mTmpName = new string[results.Length];
		foreach(Collider2D c in results)
		{
			//     print(c.name);
			if(c.tag == "Enemy")
			{
				mTmpName[i] = c.name;
				i++;
				GameObject.Find(c.name).GetComponent<EnemyController>().Highlight();
			}

		}
		mRangedHitbox.enabled = false;
		mIsRanged = true;

	}
   void continueBattle()
    {
       // mMachinePtr.conductBattle(this.transform.parent.gameObject.GetComponent<BaseCharacter>().getName());
    }

    void flee()
    {
        mIsBattling = false;
        mMachinePtr.battleFlee(this.transform.parent.gameObject.GetComponent<BaseCharacter>().getName());
    }
}

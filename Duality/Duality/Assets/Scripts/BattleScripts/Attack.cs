using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Attack : MonoBehaviour {
	public CircleCollider2D mRangedHitbox;
    public BoxCollider2D mAttackHitbox;
    public SpriteRenderer fill;

    Collider2D[] results;
    string [] mTmpName;

    bool active = false;
    public bool mIsBattling = false;
	bool mInitialized = false;
	bool mIsRanged = false;


	const float ARCHER_RANGE = 10;
	const float MAGE_RANGE = 5;

	EventMessage mAttackMessage;
    const  int BATTLE_MESSAGE = 1;

    //Pointer to the UI controller
    UiController mUIptr;

    //Combat  Machine pointer
    CombatMachine mMachinePtr;
	BaseCharacter mpBaseCharacterScript;


    void Start () {
        mAttackHitbox.enabled = false;
        fill.enabled = false;
		mRangedHitbox.enabled = false;
               
		mAttackMessage = new EventMessage(EventType.ATTACK_EVENT);
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
			mUIptr = GameObject.Find("BattleSystem").GetComponent<UiController>(); 
			mpBaseCharacterScript = gameObject.GetComponent<BaseCharacter> ();
			if (mpBaseCharacterScript.getClass() == "Archer")
				mRangedHitbox.radius = ARCHER_RANGE;
			mInitialized = true;
		}

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
		} 
		else						
		{
			print ("Wizard");
			mAttackHitbox.enabled = true;
			fill.enabled = true;
			active = true;
			detectEnemies ();
		}
    }

	public void magicInit()
	{
		if(!mInitialized)
		{
			mMachinePtr = GameObject.Find("BattleSystem").GetComponent<CombatMachine>();
			mUIptr = GameObject.Find("BattleSystem").GetComponent<UiController>(); 
			mpBaseCharacterScript = this.gameObject.GetComponent<BaseCharacter> ();
			if (mpBaseCharacterScript.getClass() == "Wizard")
				mRangedHitbox.radius = MAGE_RANGE;
			mInitialized = true;
		}
		mRangedHitbox.enabled = true;
		active = true;
		rangedAttack ();
	}




    void checkInput()
    {
        

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            print("escape key pressed");
            
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
			mIsBattling = false;
			mUIptr.finishedFunction();
            
        }
        else if (Input.GetMouseButtonDown(0) && !mIsBattling)
        {
            mAttackHitbox.enabled = false;
            fill.enabled = false;
            active = false;
            mMachinePtr.recievePlayerMessage(BATTLE_MESSAGE);
			mMachinePtr.recieveBattlingPlayer(this.gameObject, true, mIsRanged, mTmpName);				
            mIsBattling = true;
			mpBaseCharacterScript.finishedTurn();

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
	public void beingAttacked()
	{
		mMachinePtr = GameObject.Find("BattleSystem").GetComponent<CombatMachine>();
		mMachinePtr.recieveBattlingPlayer(this.gameObject, false, mIsRanged, mTmpName);				
		mIsBattling = true;
	}

    public void flee()
    {
        mIsBattling = false;
		mMachinePtr.battleFlee(this.transform.parent.gameObject.GetComponent<BaseCharacter>());
		mUIptr.finishedFunction();
    }
}

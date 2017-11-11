using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HoverOver : MonoBehaviour
{
	bool mClickable = false;
	bool mIsInitialized = false;
	private UiController mpUI;
	private Attack mpAttackScript;
	private BaseCharacter mpBaseCharacter;
	public bool mActive;
	public bool mBattleStarted;
    // Use this for initialization
    void Start()
    {
		mpAttackScript = gameObject.GetComponent<Attack>();
		mpBaseCharacter = gameObject.GetComponent<BaseCharacter>();

    }

    // Update is called once per frame
    void Update()
    {
        
		checkInput();


    }

    void OnMouseEnter()
    {
		print("mouse over");
		if(!mIsInitialized)
		{
			mpUI = GameObject.Find("BattleSystem").GetComponent<UiController>(); 
			mIsInitialized = true;
		}
		if(mBattleStarted && !mpBaseCharacter.mTurnFinished)
		{
			gameObject.GetComponent<SpriteRenderer> ().color = new Color(255f, 255f, 0f, 1f);
			mClickable = true;
		}
		if(mpBaseCharacter.mTurnFinished)
		{
			mpUI.init(this.gameObject, mpAttackScript.mIsBattling);
		}
			


    }
		
	void OnMouseExit()
	{
		if(!mActive && !mpBaseCharacter.mTurnFinished)
		{
			mClickable = false;
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (255f, 255f, 255f, 1f);
		}
		else if(mpBaseCharacter.mTurnFinished)
		{
			mpUI.disableUi();
		}

	}
    void checkInput()
    {
		if (Input.GetMouseButtonDown(0) && mClickable)
        {
			mpUI.init(this.gameObject, mpAttackScript.mIsBattling);
			mActive = true;

        }
    }


	public void reset()
	{
		mClickable = false;
		mIsInitialized = false;
		mpUI = null;
		mpAttackScript = null;
	}
}
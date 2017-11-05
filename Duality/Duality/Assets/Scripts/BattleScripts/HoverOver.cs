﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HoverOver : MonoBehaviour
{
	bool mClickable = false;
	bool mIsInitialized = false;
	private UiController mpUI;
	private Attack mpAttackScript;

    // Use this for initialization
    void Start()
    {
		mpAttackScript = gameObject.GetComponent<Attack>();

    }

    // Update is called once per frame
    void Update()
    {
        
		checkInput();


    }

    void OnMouseEnter()
    {
		if(!mIsInitialized)
		{
			mpUI = GameObject.Find("BattleSystem").GetComponent<UiController>(); 
			mIsInitialized = true;
		}

		mClickable = true;

    }
		
	void OnMouseExit()
	{
		mClickable = false;
	}
    void checkInput()
    {
		if (Input.GetMouseButtonDown(0) && mClickable)
        {
			mpUI.init(this.gameObject, mpAttackScript.mIsBattling);
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
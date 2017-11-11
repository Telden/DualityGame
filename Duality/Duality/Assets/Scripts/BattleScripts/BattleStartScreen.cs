using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BattleStartScreen : MonoBehaviour {
	UiController mpUI;
	ListManager mpListManager;
	public Canvas mStartBattleCanvas;
	public Canvas mScrollableListCanvas;
	public Button mStartLevelButton;
	public CombatMachine mpCombatMachine;
	public LoadCharacters mpLoadCharacters;

	// Use this for initialization
	void Start () {
		Button tmp = mStartLevelButton.GetComponent<Button>();
		mpUI = GameObject.Find("BattleSystem").GetComponent<UiController>(); 
		mpListManager = GameObject.Find("GameSystem").GetComponent<ListManager>();
		tmp.onClick.AddListener(startBattle);


	}
		

	void startBattle()
	{
		if(mpLoadCharacters.mSlotsleft ==0)
		{
			mpCombatMachine.init();
			mpUI.battleInit();
			mScrollableListCanvas.enabled = false;
			mStartBattleCanvas.enabled = false;
			mpUI.mBattleStarted =  true;

			for(int i = 0; i < mpListManager.getBattleListCount(); i++)
			{
				mpListManager.getBattleUnit(i).GetComponent<HoverOver>().mBattleStarted = true;
			}
		}

	}
}

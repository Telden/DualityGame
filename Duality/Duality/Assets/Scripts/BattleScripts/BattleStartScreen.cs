using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BattleStartScreen : MonoBehaviour {

    public Canvas mStartBattleCanvas;
	public Canvas mScrollableListCanvas;
	UiController mpUI;
	public Button mStartLevelButton;
	public CombatMachine mpCombatMachine;
	public LoadCharacters mpLoadCharacters;

	// Use this for initialization
	void Start () {
		Button tmp = mStartLevelButton.GetComponent<Button>();
		mpUI = GameObject.Find("BattleSystem").GetComponent<UiController>(); 
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
		}

	}
}

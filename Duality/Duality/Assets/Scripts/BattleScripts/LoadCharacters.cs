using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoadCharacters : MonoBehaviour {

	public BattleStartScreen mpStartScreen;
	ListManager mpListManager;
	public GameObject mScrollableList;
	public int mSlotsleft = 5;
	public GameObject mSelectedUnit;
	public GameObject mSpawnPoints;

	// Use this for initialization
	void Start () {
		mpListManager = GameObject.Find("GameSystem").GetComponent<ListManager>();
		init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void init()
	{
		for (int i = 0; i < mpListManager.getRandomizedUnitListSize();  i++)
		{
			GameObject character = mScrollableList.transform.GetChild(i).gameObject;
			Button tempButton = character.GetComponent<Button>();

			character.transform.GetChild(0).GetComponent<Text>().text = "Name: " + mpListManager.getRandomizedUnit(i).GetComponent<BaseCharacter>().getName();
			character.transform.GetChild(1).GetComponent<Text>().text = "Health: " + mpListManager.getRandomizedUnit(i).GetComponent<BaseCharacter>().getHealth();
			character.transform.GetChild(2).GetComponent<Text>().text = "Attack: " + mpListManager.getRandomizedUnit(i).GetComponent<BaseCharacter>().getAttack();
			character.transform.GetChild(3).GetComponent<Text>().text = "Defense: " + mpListManager.getRandomizedUnit(i).GetComponent<BaseCharacter>().getDefense();
			character.transform.GetChild(4).GetComponent<Text>().text = "Magic: " + mpListManager.getRandomizedUnit(i).GetComponent<BaseCharacter>().getMagic();
			character.transform.GetChild(5).GetComponent<Text>().text = "Magic Defense: " + mpListManager.getRandomizedUnit(i).GetComponent<BaseCharacter>().getMagicDefense();
			character.transform.GetChild(6).GetComponent<Text>().text = "Speed: " + mpListManager.getRandomizedUnit(i).GetComponent<BaseCharacter>().getSpeed();
			character.transform.GetChild(7).GetComponent<Text>().text = "Movement: " + mpListManager.getRandomizedUnit(i).GetComponent<BaseCharacter>().getMovement();
			character.transform.GetChild(8).GetComponent<Text>().text = "Class: " + mpListManager.getRandomizedUnit(i).GetComponent<BaseCharacter>().getClass();
			int tempInt = i;

			tempButton.onClick.AddListener(() => ButtonClicked(tempInt));



		}

	}

	void ButtonClicked(int buttonNo)
	{
		if(mSlotsleft > 0)
		{
			Debug.Log("Button clicked = " + buttonNo);
			mSelectedUnit = mpListManager.getRandomizedUnit(buttonNo);
			mpListManager.addBattleUnit(mpListManager.getRandomizedUnit(buttonNo));
			mScrollableList.transform.GetChild(buttonNo).GetComponent<Button>().interactable = false;
			mSpawnPoints.SetActive(true);
			mSlotsleft--;
		}


	}

	public GameObject getSelectedUnit()
	{
		return mSelectedUnit;
	}
}

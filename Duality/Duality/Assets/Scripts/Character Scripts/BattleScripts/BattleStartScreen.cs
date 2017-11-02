using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BattleStartScreen : MonoBehaviour {

    public Canvas mStartBattleCanvas;
    public List<GameObject> mpSpawnLocations;
	[SerializeField]
	GameObject mSelectedUnit;

	ListManager mpListManager;
	public GameObject mCharacterButton;
	public RectTransform mParentPanel;
	public Button mStartLevelButton;

	int mUnitsPosisionedleft;
	// Use this for initialization
	void Start () {
		Button tmp = mStartLevelButton.GetComponent<Button>();
		tmp.onClick.AddListener(startBattle);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.S))
			{
			mpListManager = GameObject.Find("GameSystem").GetComponent<ListManager>();
			mUnitsPosisionedleft = mpListManager.getBattleListCount();

				init();
			}
	}

	public void init()
	{
		showArmy();
	}

	void showArmy()
	{
		print ("Showing Army");
		print (mpListManager.getBattleListCount());
		for (int i = 0; i < mpListManager.getBattleListCount(); i++)
		{
			print("Started for loop");
			GameObject character = (GameObject)Instantiate(mCharacterButton);
			character.transform.SetParent(mParentPanel.transform);
			character.transform.localScale = new Vector3(1, 1, 1);
			print("finished creating");
			Button tempButton = character.GetComponent<Button>();
			character.transform.GetChild(0).GetComponent<Text>().text = "Name: " + mpListManager.getBattleUnit(i).GetComponent<BaseCharacter>().getName();
			character.transform.GetChild(1).GetComponent<Text>().text = "Health: " + mpListManager.getBattleUnit(i).GetComponent<BaseCharacter>().getHealth();
			character.transform.GetChild(2).GetComponent<Text>().text = "Attack: " + mpListManager.getBattleUnit(i).GetComponent<BaseCharacter>().getAttack();
			character.transform.GetChild(3).GetComponent<Text>().text = "Defense: " + mpListManager.getBattleUnit(i).GetComponent<BaseCharacter>().getDefense();
			character.transform.GetChild(4).GetComponent<Text>().text = "Magic: " + mpListManager.getBattleUnit(i).GetComponent<BaseCharacter>().getMagic();
			character.transform.GetChild(5).GetComponent<Text>().text = "Magic Defense: " + mpListManager.getBattleUnit(i).GetComponent<BaseCharacter>().getMagicDefense();
			character.transform.GetChild(6).GetComponent<Text>().text = "Speed: " + mpListManager.getBattleUnit(i).GetComponent<BaseCharacter>().getSpeed();
			character.transform.GetChild(7).GetComponent<Text>().text = "Movement: " + mpListManager.getBattleUnit(i).GetComponent<BaseCharacter>().getMovement();
			int tempInt = i;

			tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
		}


	}
	void ButtonClicked(int buttonNo)
	{
		mSelectedUnit =  mpListManager.getBattleUnit(buttonNo);
		mParentPanel.GetChild(buttonNo).GetComponent<Button>().interactable = false;
		mUnitsPosisionedleft--;


	}

	void cleanPanel ()
	{
		for (int i = 0; i < mpListManager.getBattleListCount(); i++)
			Destroy(mParentPanel.GetChild(i).gameObject);
	}

	public GameObject getSelectedUnit()
	{
		return mSelectedUnit;
	}

	void startBattle()
	{
		if(mUnitsPosisionedleft == 0)
		mStartBattleCanvas.enabled = false;

	}
}

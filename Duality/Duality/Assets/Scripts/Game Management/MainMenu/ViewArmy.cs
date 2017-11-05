using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ViewArmy : MonoBehaviour {
    
    public MainMenu mpMainmenu;//Script to Main Menu
   ListManager mpListManager; //Script to the list manager 


    // Ui Elements
    public Canvas mViewArmyCanvas;
    public GameObject mCharacterButton;
    public RectTransform mParentPanel;
    int mTotalCharacters;
    GameObject character;
	public Button mExitButton;

    bool mActive = false;
	bool mInitialized = false;
    // Use this for initialization
    void Start () {
		mExitButton.onClick.AddListener(exitMenu);
	}
	
	// Update is called once per frame
	void Update () {
        if(mActive)
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                mActive = false;
                mpListManager.clearViewArmyButtonList();
                mpMainmenu.reset();
            }
    }

    //Function to be called from the main menu script
    public void init()
    {
		if(!mInitialized)
		{
			mpListManager = GameObject.Find("GameSystem").GetComponent<ListManager>();
		}

        mActive = true;
        mTotalCharacters = mpListManager.getArmyListSize();
        showArmy();

    }

    //Load and create all of the character buttons
    void showArmy()
    {
        
        for (int i = 0; i < mTotalCharacters; i++)
        {
            mpListManager.addViewArmyButton((GameObject)Instantiate(mCharacterButton));
            character = mpListManager.getViewArmyButton(i);
            character.transform.SetParent(mParentPanel.transform);
            character.transform.localScale = new Vector3(1, 1, 1);

            Button tempButton = character.GetComponent<Button>();
            character.transform.GetChild(0).GetComponent<Text>().text = "Name: " + mpListManager.getArmyUnit(i).GetComponent<BaseCharacter>().getName();
            character.transform.GetChild(1).GetComponent<Text>().text = "Health: " + mpListManager.getArmyUnit(i).GetComponent<BaseCharacter>().getHealth();
            character.transform.GetChild(2).GetComponent<Text>().text = "Attack: " + mpListManager.getArmyUnit(i).GetComponent<BaseCharacter>().getAttack();
            character.transform.GetChild(3).GetComponent<Text>().text = "Defense: " + mpListManager.getArmyUnit(i).GetComponent<BaseCharacter>().getDefense();
            character.transform.GetChild(4).GetComponent<Text>().text = "Magic: " + mpListManager.getArmyUnit(i).GetComponent<BaseCharacter>().getMagic();
            character.transform.GetChild(5).GetComponent<Text>().text = "Magic Defense: " + mpListManager.getArmyUnit(i).GetComponent<BaseCharacter>().getMagicDefense();
            character.transform.GetChild(6).GetComponent<Text>().text = "Speed: " + mpListManager.getArmyUnit(i).GetComponent<BaseCharacter>().getSpeed();
            character.transform.GetChild(7).GetComponent<Text>().text = "Movement: " + mpListManager.getArmyUnit(i).GetComponent<BaseCharacter>().getMovement();
            character.transform.GetChild(8).GetComponent<Text>().text = "Class: " + mpListManager.getRandomizedUnit(i).GetComponent<BaseCharacter>().getClass();
            int tempInt = i;

            tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
        }
    }

    void ButtonClicked(int buttonNo)
    {
        Debug.Log("Button clicked = " + buttonNo);
        
    }

	public void exitMenu()
	{
		mActive = false;
		mpListManager.clearViewArmyButtonList();
		mpMainmenu.reset();
	}

}

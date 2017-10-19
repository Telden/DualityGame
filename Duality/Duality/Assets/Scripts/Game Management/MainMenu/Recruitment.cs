using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Recruitment : MonoBehaviour {
    //REFERENCE http://answers.unity3d.com/questions/875588/unity-ui-dynamic-buttons.html

    //Script to the randomized units
    public ListManager mpListManager; //Script to the list manager 
    //Script to Main Menu
    public MainMenu mpMainmenu; //Script to the main 
    // UI elements
    public GameObject mCharacterButton; //The prefab of the character button
    public RectTransform mParentPanel; //Ui element to organise the instantiated buttons
    public Text mSlotsLeft; //Ui text of the amount of army slots left
    public int mSlots; //number representation of the number of slots left
    int mTotalUnits; //variable to store the total amount of randomized units from their list
    GameObject character;


    // Use this for initialization
    void Start () {
        mSlots = 10;
		//mSelectedUnits = new GameObject[mSlots];
        //mCharacterIndex = 0;
        mSlotsLeft.text = "Slots Left: " + mSlots.ToString();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mpListManager.clearRecruitmentButtonList();
            mpMainmenu.reset();
        }

    }

    //Function to be called from the main menu script
    public void init()
    {
        mTotalUnits = mpListManager.getRandomizedUnitListSize();
        loadList();
    }

    //Load and create all of the character buttons
    void loadList()
    {
        for (int i = 0; i < mTotalUnits; i++)
            {
            mpListManager.addRecruitmentButton((GameObject)Instantiate(mCharacterButton)); //Create a copy of the character button prefab
            character = mpListManager.getRecruitmentButton(i); //Add the button to the list manager
            character.transform.SetParent(mParentPanel.transform); //Set the parent from the canvas to the panel
            character.transform.localScale = new Vector3(1, 1, 1); //Mathy Ui things

            //Set up the text on the bytton to the stats and name of the character
            Button tempButton = character.GetComponent<Button>();
            character.transform.GetChild(0).GetComponent<Text>().text = "Name: " + mpListManager.getRandomizedUnit(i).GetComponent<BaseCharacter>().getName();
            character.transform.GetChild(1).GetComponent<Text>().text = "Health: " + mpListManager.getRandomizedUnit(i).GetComponent<BaseCharacter>().getHealth();
            character.transform.GetChild(2).GetComponent<Text>().text = "Attack: " + mpListManager.getRandomizedUnit(i).GetComponent<BaseCharacter>().getAttack();
            character.transform.GetChild(3).GetComponent<Text>().text = "Defense: " + mpListManager.getRandomizedUnit(i).GetComponent<BaseCharacter>().getDefense();
            character.transform.GetChild(4).GetComponent<Text>().text = "Magic: " + mpListManager.getRandomizedUnit(i).GetComponent<BaseCharacter>().getMagic();
            character.transform.GetChild(5).GetComponent<Text>().text = "Magic Defense: " + mpListManager.getRandomizedUnit(i).GetComponent<BaseCharacter>().getMagicDefense();
            character.transform.GetChild(6).GetComponent<Text>().text = "Speed: " + mpListManager.getRandomizedUnit(i).GetComponent<BaseCharacter>().getSpeed();
            character.transform.GetChild(7).GetComponent<Text>().text = "Movement: " + mpListManager.getRandomizedUnit(i).GetComponent<BaseCharacter>().getMovement();
            int tempInt = i;
            tempButton.onClick.AddListener(() => ButtonClicked(tempInt)); //Add a button listener if clicked on
        }
    }

    //Actions taken on the button press
    void ButtonClicked(int buttonNo)
    {
        if(mSlots > 0)
        {
            Debug.Log("Button clicked = " + buttonNo);
            mpListManager.addArmyUnit(mpListManager.getRandomizedUnit(buttonNo)); //Add a reference to the unit to the army list
            mpListManager.removeRandomizedUnit(buttonNo); //Remove the reference of the unit from the randomized unit list
            mpListManager.getRecruitmentButton(buttonNo).GetComponent<Button>().interactable = false; //Turn off the button
            mSlots--; //reduce the number of slots availible to the player
            mSlotsLeft.text = "Slots Left: " + mSlots.ToString(); //Update slot text ui
        }
       
    }

}

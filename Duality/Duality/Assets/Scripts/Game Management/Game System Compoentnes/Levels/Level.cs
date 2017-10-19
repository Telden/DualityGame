using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Level : MonoBehaviour {

	[SerializeField]
	private int mLevelIndex; //Which level?
    public Canvas mLevelPreviewCanvas;
	public Image mImagePreview; //Show the layout of the level
	[SerializeField]
	private float[] mStartingLocations; //The different locations that the player can place units on
	[SerializeField]
	private int mTotalAllowed; //The total number of allowed characters on this level
	[SerializeField]
	private GameObject[] mSelectedUnits; //The Units that are selected for the level
                                         //Brief Discription of the level
    public ListManager mpListManager;

    public GameObject mCharacterButton;
    public RectTransform mParentPanel;

    int mTotalCharacters;

    // Use this for initialization
    void Start () {
        mLevelPreviewCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    public void init()
    {
        mLevelPreviewCanvas.enabled = true;
        mTotalCharacters = mpListManager.getArmyListSize();
        showArmy();
    }

    


    public void loadLevel()
    {

    }

    void showArmy()
    {
        for (int i = 0; i < mTotalCharacters; i++)
        {
            GameObject character = (GameObject)Instantiate(mCharacterButton);
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
            int tempInt = i;

            tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
        }
    }
    void ButtonClicked(int buttonNo)
    {

        mpListManager.addBattleUnit(mpListManager.getArmyUnit(buttonNo));

    }
}

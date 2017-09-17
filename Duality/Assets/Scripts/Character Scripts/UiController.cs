using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UiController : MonoBehaviour {

    //Attack menu buttons and canvas
    public Canvas attackMenu;
    public Button Movement;
    public Button Attack;
    public Button Item;
    public Button Stay;

    //Scripts for the buttons
    private Attack mAttackScript;
    private move mMoveScript;

    bool active = false;

    // Use this for initialization
    void Start()
    {
        //Setting all the buttons off so that they do not show until the player moves over the character
        Button tmp = Movement.GetComponent<Button>();
        tmp.onClick.AddListener(moveCharacter);
        tmp = Attack.GetComponent<Button>();
        tmp.onClick.AddListener(playerAttack);
        tmp = Item.GetComponent<Button>();
        tmp.onClick.AddListener(useItem);
        tmp = Stay.GetComponent<Button>();
        tmp.onClick.AddListener(playerStay);

        //Set up all the scripts
        mAttackScript = transform.Find("AttackHitbox").GetComponent<Attack>();
        mMoveScript = gameObject.GetComponent<move>();
        
        attackMenu.enabled = false;
        Movement.interactable = false;
        Attack.interactable = false;
        Item.interactable = false;
        Stay.interactable = false;




    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            checkInput();
        }
        


    }
    void checkInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            attackMenu.enabled = false;
            Movement.interactable = false;
            Attack.interactable = false;
            Item.interactable = false;
            Stay.interactable = false;
            active = false;
        }
    }

    void OnMouseEnter()
    {
        Debug.Log("Mouse Over");
        //if(Input.GetMouseButtonDown(0))
        {
            // Debug.Log("Mouse clicked");
            attackMenu.enabled = true;
            Movement.interactable = true;
            Attack.interactable = true;
            Item.interactable = true;
            Stay.interactable = true;
            active = true;
        }
    }

    void moveCharacter()
    {
        //print("Moving character");
        attackMenu.enabled = false;
        Movement.interactable = false;
        Attack.interactable = false;
        Item.interactable = false;
        Stay.interactable = false;
        mMoveScript.init();

        
    }

    void playerAttack()
    {
        print("Button works");
        attackMenu.enabled = false;
        Movement.interactable = false;
        Attack.interactable = false;
        Item.interactable = false;
        Stay.interactable = false;
        mAttackScript.init();
    }
   
    void useItem()
    {
        print("Button works");
        attackMenu.enabled = false;
        Movement.interactable = false;
        Attack.interactable = false;
        Item.interactable = false;
        Stay.interactable = false;
    }

    void playerStay()
    {
        print("Button works");
        attackMenu.enabled = false;
        Movement.interactable = false;
        Attack.interactable = false;
        Item.interactable = false;
        Stay.interactable = false;
    }

    
}

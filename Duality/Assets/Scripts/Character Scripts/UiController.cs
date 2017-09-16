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

    //Line drawing variables
    private LineRenderer line;
    Vector3 characterPos;
    Vector2 CursorPosition;
    bool moving = false;


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



        attackMenu.enabled = false;
        Movement.interactable = false;
        Attack.interactable = false;
        Item.interactable = false;
        Stay.interactable = false;


        characterPos.z = 0;


    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            characterPos.x = gameObject.transform.position.x;
            characterPos.y = gameObject.transform.position.y;
            CursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moveCharacter();
            checkInput();
        }


    }
    void checkInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.transform.position = CursorPosition;
            moving = false;
            line.SetPosition(0, Vector3.zero);
            line.SetPosition(1, Vector3.zero);
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
        moving = true;

        line = GetComponent<LineRenderer>();
        line.SetPosition(0, characterPos);
        line.SetPosition(1, CursorPosition);
    }

    void playerAttack()
    {
        print("Button works");
        attackMenu.enabled = false;
        Movement.interactable = false;
        Attack.interactable = false;
        Item.interactable = false;
        Stay.interactable = false;
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

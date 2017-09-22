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

	//Particle System
	public ParticleSystem parts;

    //
    bool active = false;
    bool finished = false;

    CombatMachine mMachinePtr;

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
        

        //Make sure the buttons are not interactible yet
        attackMenu.enabled = false;
        Movement.interactable = false;
        Attack.interactable = false;
        Item.interactable = false;
        Stay.interactable = false;

        //create pointer  to combat manager
        mMachinePtr = GameObject.Find("GameSystem").GetComponent<CombatMachine>();

		parts.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(!finished)
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
        if(!finished)
        {
            if(!active)
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
        //use an item 
        finishedTurn();
    }

    void playerStay()
    {
        print("Button works");
        attackMenu.enabled = false;
        Movement.interactable = false;
        Attack.interactable = false;
        Item.interactable = false;
        Stay.interactable = false;
        finishedTurn();
    }

    public void finishedTurn()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f, 0.5f);
        finished = true;
    }

    public void resetTurn()
    {
        finished = false;
    }

	public void RecieveEvent(EventMessage Message)
	{
		if(Message.myType == EventType.ATTACK_EVENT)
		{
			parts.Play();
			finishedTurn();
		}

		else if(Message.myType == EventType.MOEVMENT_EVENT)
		{
			//do something
		}
		
	}
}

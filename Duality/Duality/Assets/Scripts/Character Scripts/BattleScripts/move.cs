using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class move : MonoBehaviour
{
    float tmpMovement;
    float tmpMaxMovement;
    float prevDistance;
    public Text tmpDistance;
    public Text movementText;
    float distance;
    //Movement Bar Variables
    public Canvas movementGroup;
    public Image mMovementBar;
    public Text uiMovement;

    //Line drawing variables
    private LineRenderer line;
    Vector2 characterPos;
    Vector2 CursorPosition;
    bool active = false;
    bool mClampDistance = false;
    int message = 0;
    //Pointer to the UI controller
    UiController mUIptr;
    //Pointer to the CombatMachine
    CombatMachine mMachinePtr;

    //Pointer to basecharacter script
    BaseCharacter mBasecharacter;


    Vector2 C;
     Vector2 D;
     Vector2 E;


    // Use this for initialization
    void Start()
    {
        movementGroup.enabled = false;
        //mMovementBar.enabled = false;
        //uiMovement.enabled = false;

       // message = EventType.MOEVMENT_EVENT;
        mUIptr = gameObject.GetComponent<UiController>();

        mMachinePtr = GameObject.Find("GameSystem").GetComponent<CombatMachine>();
        mBasecharacter = gameObject.GetComponent<BaseCharacter>();

        tmpMovement = 10;
        tmpMaxMovement = 10;
        prevDistance = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            drawLine();
            updateUI();
            checkInput();
        }

    }

    void checkInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (mClampDistance)
                gameObject.transform.position = E;
            else
            {
                gameObject.transform.position = CursorPosition;
            }
              
            //gameObject.transform.position = E;

            line.SetPosition(0, Vector3.zero);
            line.SetPosition(1, Vector3.zero);
            movementGroup.enabled = false;
            active = false;
            sendMessage();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            line.SetPosition(0, Vector3.zero);
            line.SetPosition(1, Vector3.zero);
            movementGroup.enabled = false;
            active = false;
        }
        else if (Input.GetKeyDown(KeyCode.Minus))
        {
            updateDistance();
        }
    }

    public void init()
    {
        movementGroup.enabled = true;
        //mMovementBar.enabled = true;
        //uiMovement.enabled = true;
        active = true;

    }

    void sendMessage()
    {
        //send message that the player moved to the UI manager
        //mUIptr.finishedTurn();
        //send that the player moved to the combat manager
        //smMachinePtr.recievePlayerMessage(message);

    }
    //Update the line drawer UI
    void drawLine()
    {
        
        CursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(gameObject.transform.position, CursorPosition);
        if(distance > tmpMaxMovement)
        {
            characterPos.x = gameObject.transform.position.x;
            characterPos.y = gameObject.transform.position.y;
            C = CursorPosition - characterPos;
            D = C.normalized;
            E = characterPos + D * tmpMaxMovement;

            line = GetComponent<LineRenderer>();
            line.SetPosition(0, characterPos);
            line.SetPosition(1, E);
            distance = tmpMaxMovement;
            mClampDistance = true;

        }
        else
        {
            characterPos.x = gameObject.transform.position.x;
            characterPos.y = gameObject.transform.position.y;

            line = GetComponent<LineRenderer>();
            line.SetPosition(0, characterPos);
            line.SetPosition(1, CursorPosition);
            mClampDistance = false;
        }
        
    }


    void updateUI()
    {
        mMovementBar.fillAmount = updateMovementbar();
        uiMovement.text = "Movement: " + tmpMovement.ToString();
        updateDistance();
        mMovementBar.fillAmount = updateMovementbar();
    }

    //Reduce the amount of movement 
    void updateDistance()
    {       
        if (distance > prevDistance || distance < prevDistance)
        {
            tmpMovement = tmpMaxMovement;
            tmpMovement -= distance;
            prevDistance = distance;
            if (tmpMovement < 0)
                tmpMovement = 0;
            else if (tmpMovement > tmpMaxMovement)
                tmpMovement = tmpMaxMovement;
        }
        movementText.text = "Movement " + tmpMovement.ToString();
        tmpDistance.text = "Distance: " + distance.ToString();
       
    }

    private float updateMovementbar()
    {
        return (tmpMovement - 0) * (1 - 0) / (tmpMaxMovement - 0) + 0;
    }
}

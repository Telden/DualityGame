using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class move : MonoBehaviour
{
    //Mathematic Variables
    float mMovement; //The amount of movement that the player has left
    float mMaxMovement; //The maximum amount of movement that the player has left
    float mMaxMovementReset; //Resets the maximum amount back to its highest value
    float mPrevDistance; //Makes sure that the UI only updates when the mouse moves
    float mDistance; //The distance between the unit and the mouse
    Vector2 mVectorGap; //The vector between the unit and mouse posision
    Vector2 mVectorGapNormalized; //mVectorGap Normalized
    Vector2 mRadiusPosition; // The unit posision + mVectorGapNormalized * movement

    //Movement Bar Variables
    public Canvas movementGroup; //The movement UI canvas group
    public Image mMovementBar; //The the bar showing the amount of movement left 
    public Text uiMovement; //The text over the movement bar showing the amount of movement left

    //Line drawing variables
    private LineRenderer mLine; //The line drawn between the unit and the mouse
    Vector2 mCharacterPos; //The unit's 2D position
    Vector2 mCursorPosition; //The mouse's 2D position


    bool mActive = false; //determine if the movement script should be funcitoning
    bool mClampDistance = false; //Used if the mouse is farther apart than the movement allowed by the player
    bool mInitialized; //Determine if this has been the first activation  of the button
    
    //Scripts
    UiController mUIptr; //Pointer to the UI controller

    //TEMPORARY Variables
    public Text tmpDistance; //TEMPORARY: Shows the distance between the unit and the mouse
    public Text movementText; //Temporary: Shows the amount of movement left 
    


    // Use this for initialization
    void Start()
    {
        movementGroup.enabled = false;
        mInitialized = false;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (mActive)
        {
            drawLine();
            updateUI();
            checkInput();
        }

    }

    void checkInput()
    {
        //When the player left clicks
        if (Input.GetMouseButtonDown(0))
        {
            if (mClampDistance)
                gameObject.transform.position = mRadiusPosition; //If the mouse is farther than the movement left, moves to the position with the maximum movment
            else
            {
                gameObject.transform.position = mCursorPosition; //If the mouse is less than the movememnt left move to the mouse position
            }
             

            mLine.SetPosition(0, Vector3.zero); //Reset the line renderer
            mLine.SetPosition(1, Vector3.zero);
            mMaxMovement = mMovement;  //Update the max amount of movement left 
            movementGroup.enabled = false; //Disable the UI
            mActive = false;
            mUIptr.finishedFunction();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            mLine.SetPosition(0, Vector3.zero);
            mLine.SetPosition(1, Vector3.zero);
            movementGroup.enabled = false;
            mActive = false;
        }
        else if (Input.GetKeyDown(KeyCode.Minus))
        {
            updateDistance();
        }
    }

    public void init()
    { 
        //If it's the first time being used, load movement variables from the base character
        if(!mInitialized)
        {
            mMovement = gameObject.GetComponent<BaseCharacter>().getMovement();
            mMaxMovement = gameObject.GetComponent<BaseCharacter>().getMaxMovement();
            mMaxMovementReset = mMaxMovement;
            mPrevDistance = 0;
            mUIptr = gameObject.GetComponent<UiController>();
            mInitialized = true;
        }
        //Turn on the  movement UI elements and activate its  functions   
        movementGroup.enabled = true;
        mActive = true;

    }

    //Update the line drawer UI
    void drawLine()
    {
        mCursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mDistance = Vector2.Distance(gameObject.transform.position, mCursorPosition); //Get the distance between the unit and mouse positions
        //If the distance is bigger than the maximum movement allowed for the character find the furthest point within the radius of the maximum movement
        if (mDistance > mMaxMovement) 
        {
            mCharacterPos.x = gameObject.transform.position.x;
            mCharacterPos.y = gameObject.transform.position.y;
            mVectorGap = mCursorPosition - mCharacterPos;
            mVectorGapNormalized = mVectorGap.normalized;
            mRadiusPosition = mCharacterPos + mVectorGapNormalized * mMaxMovement;

            mLine = GetComponent<LineRenderer>();
            mLine.SetPosition(0, mCharacterPos);
            mLine.SetPosition(1, mRadiusPosition);
            mDistance = mMaxMovement;
            mClampDistance = true;

        }
        else //Draw the line between the unit and the mouse posision
        {
            mCharacterPos.x = gameObject.transform.position.x;
            mCharacterPos.y = gameObject.transform.position.y;

            mLine = GetComponent<LineRenderer>();
            mLine.SetPosition(0, mCharacterPos);
            mLine.SetPosition(1, mCursorPosition);
            mClampDistance = false;
        }
        
    }

    //Update all the movement UI elements
    void updateUI()
    {
        mMovementBar.fillAmount = updateMovementbar();
        uiMovement.text = "Movement: " + mMovement.ToString();
        updateDistance();
        mMovementBar.fillAmount = updateMovementbar();
    }

    //Reduce the amount of movement 
    void updateDistance()
    {       
        if (mDistance > mPrevDistance || mDistance < mPrevDistance)
        {
            mMovement = mMaxMovement;
            mMovement -= mDistance;
            mPrevDistance = mDistance;
            if (mMovement < 0)
                mMovement = 0;
            else if (mMovement > mMaxMovement)
                mMovement = mMaxMovement;
        }
        movementText.text = "Movement " + mMovement.ToString();
        tmpDistance.text = "Distance: " + mDistance.ToString();
       
    }
    //Update the movement bar with the amount of movement left
    private float updateMovementbar()
    {
        return (mMovement - 0) * (1 - 0) / (mMaxMovementReset - 0) + 0;
    }
    //Reset the total maximum movement allowed after the enemy's turn has compleated
    public void reset()
    {
        mMaxMovement = mMaxMovementReset;
    }
}

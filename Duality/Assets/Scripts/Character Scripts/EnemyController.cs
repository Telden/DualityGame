using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    

    bool targetable = false;
	public ParticleSystem parts;

	//Combat  Machine pointer
	CombatMachine mMachinePtr;


	// Use this for initialization
	void Start () {
		parts.Stop();
		//set pointer to combat machine
		mMachinePtr = GameObject.Find("GameSystem").GetComponent<CombatMachine>();
    }
	
	// Update is called once per frame
	void Update () {
		if (targetable) 
		{
			checkInput ();
		}

		
	}

	void checkInput()
	{
		if (Input.GetMouseButtonDown (0))
		{
			Debug.Log ("You're now attacking this character");
			parts.Play();
            resetColor();
			mMachinePtr.recieveEnemy(this.gameObject);
		}
	}
    public void Highlight()
    {

        gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
		targetable = true;


    }
    public void resetColor()
    {
		Debug.Log ("Reseting color");
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 255f, 1f);
		targetable = false;
       
    }
	public void recieveMessage()
	{
		resetColor ();
	}

	void OnMouseEnter()
	{
		
		if (targetable) 
		{
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (0f, 255f, 0f, 1f);
				
		}
	}

	void OnMouseExit()
	{
		if(targetable)
			gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
	}
		
}

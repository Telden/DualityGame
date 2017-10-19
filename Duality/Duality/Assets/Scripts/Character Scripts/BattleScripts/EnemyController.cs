﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    

    bool targetable = false;
	bool mHover = false;
	public ParticleSystem parts;

	//Combat  Machine pointer
	CombatMachine mMachinePtr;


	// Use this for initialization
	void Start () {
		parts.Stop();
		//set pointer to combat machine
		mMachinePtr = GameObject.Find("GameSystem").GetComponent<CombatMachine>();
		mMachinePtr.registerEnemy(this.transform.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		if (targetable && mHover) 
		{
			checkInput ();
		}

		
	}

	void checkInput()
	{
		if (Input.GetMouseButtonDown (0))
		{
	//		Debug.Log ("You're now attacking this character");
			parts.Play();
            resetColor();
			mMachinePtr.recieveEnemy(this.gameObject);
			if(mMachinePtr.playerBattleFlag)
				mMachinePtr.conductBattle(gameObject.GetComponent<BaseCharacter>().getName());
		}
	}
    public void Highlight()
    {

        gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
		targetable = true;


    }
    public void resetColor()
    {
//		Debug.Log ("Reseting color");
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
			mHover = true;
				
		}
	}

	void OnMouseExit()
	{
		if(targetable)
			gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
		mHover = false;
	}

	public void initAI(GameObject [] playerArmy, int max)
	{
	//	GameObject target;
	//	float closest = float.MaxValue;
	//	float distance;
	//	Vector2 targetpos = new Vector2 (0,0);
	//	print ("ELIMINATE!!!");
	//	for(int i = 0; i < max; i++)
	//	{
	//		distance = Vector2.SqrMagnitude (gameObject.transform.position - playerArmy[i].transform.position);

	//		if (distance < closest)
	//		{
	//			closest = distance;
	//			target = playerArmy[i];
	//			targetpos = target.transform.position;

	//		}
	//	}
	//	gameObject.transform.position = targetpos;

	}
}

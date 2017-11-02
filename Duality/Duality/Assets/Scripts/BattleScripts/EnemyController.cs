using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    

    bool targetable = false;
	bool mHover = false;
	bool mIsBattling = false;
	public ParticleSystem parts;
	public BoxCollider2D mAttackHitbox;
	//Combat  Machine pointer
	CombatMachine mMachinePtr;

    ListManager mpListManager;

	// Use this for initialization
	void Start () {
		parts.Stop();
		//set pointer to combat machine
		mMachinePtr = GameObject.Find("BattleSystem").GetComponent<CombatMachine>();
		mpListManager = GameObject.Find("GameSystem").GetComponent<ListManager>();
		mMachinePtr.registerEnemy(this.gameObject);
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
			mMachinePtr.recieveBattlingEnemy(this.gameObject, false, false);
			targetable = false;
			mIsBattling = true;
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
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (255f, 255f, 255f, 1f);
		//targetable = false;
       
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

	public void initAI()
	{
		GameObject target = this.gameObject;
		float closest = float.MaxValue;
		float distance;
		Vector2 targetpos = new Vector2 (0,0);
		Vector2 vectorGap = new Vector2 (0,0);
		Vector2 characterPos = new Vector2 (0,0);
		bool test = false;
		//print ("ELIMINATE!!!");
		if(!mIsBattling)
		{
			
			for(int i = 0; i < mpListManager.getBattleListCount(); i++)
			{
				if(!mMachinePtr.battleExist(mpListManager.getBattleUnit(i).GetComponent<BaseCharacter>().getName()))
				{
					target = mpListManager.getBattleUnit(i);
					distance = Vector2.SqrMagnitude (gameObject.transform.position - mpListManager.getBattleUnit(i).transform.position);
					if (distance > 10)
					{
						targetpos.x = target.transform.position.x;
						targetpos.y = target.transform.position.y;
						characterPos.x = gameObject.transform.position.x;
						characterPos.y = gameObject.transform.position.y;
						vectorGap = targetpos - characterPos;
						vectorGap = vectorGap.normalized;
						gameObject.transform.position = characterPos + vectorGap * 10;
						test = true;
						break;
					}
					else
					{
						gameObject.transform.position = target.transform.position;
						test = true;
						break;
					}
						

				
						
						
				}
					
			}
			if(test)
			{
				mMachinePtr.recieveBattlingEnemy(this.gameObject, true, false);
				target.GetComponentInChildren<Attack>().beingAttacked();
				mMachinePtr.initiateBattle();
			}



			/*gameObject.transform.position = target;





			if (distance < closest)
			{
				closest = distance;
				target = mpListManager.getBattleUnit(i);
				targetpos = target.transform.position;*/

			//}

		}
	}
}

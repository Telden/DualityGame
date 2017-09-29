using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{

	public bool isDead = false;

    public float mHealth = 10;
	public float mAttack = 10;
	public float mMagic = 10;
	public float mDefense = 10;
	public float mMagicDefense = 10;
	public float mSpeed = 10;
	public float mMovemnt = 100;
	public string mName;

	float mResetHealth;
	float mResetAttack;
	float mResetDefense;
	float mResetMagic;
	float mresetMagicDefense;
	float mResetSpeed;
	float mResetMovement;


	void Update()
	{
		if(isDead)
		{
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			gameObject.gameObject.GetComponent<BoxCollider2D>().enabled = false;
		}
	}
    public void setHealth(float nHealth)
    {
        mHealth = nHealth;
		if(mHealth < 1)
			isDead = true;
		//mResetHealth = mHealth;
    }

    public float getHealth()
    {
        return mHealth; 
    }
    
    public void setAttack(float nAttack)
    {
        mAttack = nAttack;
		mResetAttack = mAttack;
    }

    public float getAttack()
    {
        return mAttack;
    }

    public void setMagic(float nMagic)
    {
        mMagic = nMagic;
		mResetMagic = mMagic;
    }

    public float getMagic()
    {
        return mMagic;
    }

    public void setDefense(float nDefense)
    {
        mDefense = nDefense;
		mResetMagic = mDefense;
    }

    public float getDefense()
    {
        return mDefense;
    }

    public void setMagicDefense(float nMagicDefense)
    {
        mMagicDefense = nMagicDefense;
		mresetMagicDefense = mMagicDefense;
    }

    public float getMagicDefense()
    {
        return mMagicDefense;
    }

    public void setSpeed(float nSpeed)
    {
        mSpeed = nSpeed;
		mResetSpeed = mSpeed;
    }

    public float getSpeed()
    {
        return mSpeed;
    }
    
    public void setMovemnt(float nMovement)
    {
        mMovemnt = nMovement;
		mResetMovement = mResetMovement;
    }

    public float getMovement()
    {
        return mMovemnt;
    }


    public void setName(string nName)
    {
        mName = nName;
    }

    public string getName()
    {
        return mName;
    }

	public void reset()
	{
		mHealth = mResetHealth;
		mAttack = mResetAttack;
		mDefense = mResetDefense;
		mMagic = mResetMagic;
		mMagicDefense = mresetMagicDefense;
		mSpeed = mResetSpeed;
		mMovemnt = mResetMovement;
	}

}

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
	public float mMovemnt = 10;
	public string mName;

	float mResetHealth;
	float mResetAttack;
	float mResetDefense;
	float mResetMagic;
	float mresetMagicDefense;
	float mResetSpeed;
	float mResetMovement= 10;

    public bool mLoaded = false;
    public bool mSelected = false;


    void Start()
    {
        DontDestroyOnLoad(gameObject.transform);
    }

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
        if(!mLoaded)
        {
            mResetHealth = mHealth;
        }
            
    }

    public float getHealth()
    {
        return mHealth; 
    }
    
    public void setAttack(float nAttack)
    {
        mAttack = nAttack;
        if (!mLoaded)
            mResetAttack = mAttack;
            
    }

    public float getAttack()
    {
        return mAttack;
    }

    public void setMagic(float nMagic)
    {
        mMagic = nMagic;
        if (!mLoaded)
            mResetMagic = mMagic;
    }

    public float getMagic()
    {
        return mMagic;
    }

    public void setDefense(float nDefense)
    {
        mDefense = nDefense;
        if (!mLoaded)
            mResetMagic = mDefense;
    }

    public float getDefense()
    {
        return mDefense;
    }

    public void setMagicDefense(float nMagicDefense)
    {
        mMagicDefense = nMagicDefense;
        if (!mLoaded)
            mresetMagicDefense = mMagicDefense;
    }

    public float getMagicDefense()
    {
        return mMagicDefense;
    }

    public void setSpeed(float nSpeed)
    {
        mSpeed = nSpeed;
        if (!mLoaded)
            mResetSpeed = mSpeed;
    }

    public float getSpeed()
    {
        return mSpeed;
    }
    
    public void setMovemnt(float nMovement)
    {
        mMovemnt = nMovement;
        if (!mLoaded)
            mResetMovement = mMovemnt;
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

    public float getMaxHealth()
    {
        return mResetHealth;
    }
    
    public float getMaxMovement()
    {
        return mResetMovement;
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

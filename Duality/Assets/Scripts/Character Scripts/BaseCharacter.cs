using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{


    public float mHealth = 10;
	public float mAttack = 10;
	public float mMagic = 10;
	public float mDefense = 10;
	public float mMagicDefense = 10;
	public float mSpeed = 10;
	public float mMovemnt = 100;
	public string mName;

    public void setHealth(float nHealth)
    {
        mHealth = nHealth;
    }

    public float getHealth()
    {
        return mHealth; 
    }
    
    public void setAttack(float nAttack)
    {
        mAttack = nAttack;
    }

    public float getAttack()
    {
        return mAttack;
    }

    public void setMagic(float nMagic)
    {
        mMagic = nMagic;
    }

    public float getMagic()
    {
        return mMagic;
    }

    public void setDefense(float nDefense)
    {
        mDefense = nDefense;
    }

    public float getDefense()
    {
        return mDefense;
    }

    public void setMagicDefense(float nMagicDefense)
    {
        mMagicDefense = nMagicDefense;
    }

    public float getMagicDefense()
    {
        return mMagicDefense;
    }

    public void setSpeed(float nSpeed)
    {
        mMagicDefense = nSpeed;
    }

    public float getSpeed()
    {
        return mSpeed;
    }
    
    public void setMovemnt(float nMovement)
    {
        mMovemnt = nMovement;
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

}

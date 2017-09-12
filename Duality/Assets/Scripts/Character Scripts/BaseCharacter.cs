using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour {

    [SerializeField]
    float mHealth = 10;
    float mAttack = 10;
    float mMagic = 10;
    float mDefense = 10;
    float mMovemnt = 100;
    string mName;

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
        mAttack = nMagic;
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

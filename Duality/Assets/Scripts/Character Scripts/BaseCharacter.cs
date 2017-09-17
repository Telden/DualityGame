﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter {

    [SerializeField]
    float mHealth = 10;
    float mAttack = 10;
    float mMagic = 10;
    float mDefense = 10;
    float mMagicDefense = 10;
    float mSpeed = 10;
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
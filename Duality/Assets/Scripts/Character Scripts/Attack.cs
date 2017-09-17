using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    private BoxCollider2D mAttackHitbox;
    private SpriteRenderer fill;
    Collider2D[] results;
    string [] mTmpName;
    bool active = false;
	
	void Start () {
        mAttackHitbox = gameObject.GetComponent<BoxCollider2D>();
        mAttackHitbox.enabled = false;
        fill = gameObject.GetComponent<SpriteRenderer>();
        fill.enabled = false;

    }
	

	void Update () {
        if(active)
        {
            checkInput();
        }
		
	}

    //turn on the battle state
    public void init()
    {
        mAttackHitbox.enabled = true;
        fill.enabled = true;
        active = true;
        detectEnemies();
    }

    void checkInput()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            print("escape key pressed");


            mAttackHitbox.enabled = false;
            fill.enabled = false;
            active = false;
            for (int i = 0; i < mTmpName.Length; i++)
            {
                if (mTmpName[i] != null)
                {
                    GameObject.Find(mTmpName[i]).GetComponent<EnemyController>().resetColor();
                }
            }
        }
    }
    void detectEnemies()
    {
        int i = 0;
        results =  Physics2D.OverlapBoxAll(mAttackHitbox.bounds.center, mAttackHitbox.bounds.extents, LayerMask.GetMask("Enemy"));
        mTmpName = new string[results.Length];
        foreach(Collider2D c in results)
        {
            print(c.name);
            if(c.tag == "Enemy")
            {
                mTmpName[i] = c.name;
                i++;
                GameObject.Find(c.name).GetComponent<EnemyController>().Highlight();
            }
            
        }
    }
}

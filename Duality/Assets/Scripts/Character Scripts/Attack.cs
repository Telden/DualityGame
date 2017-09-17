using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    private BoxCollider2D mAttackHitbox;
    private SpriteRenderer fill;
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

        }
		
	}

    //turn on the battle state
    public void init()
    {
        mAttackHitbox.enabled = true;
        fill.enabled = true;

    }
    void detectEnemies()
    {

    }
}

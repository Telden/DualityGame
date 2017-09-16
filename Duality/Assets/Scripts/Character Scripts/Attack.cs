using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public Rigidbody2D mAttackHitbox;

	
	void Start () {
        mAttackHitbox = gameObject.GetComponent<Rigidbody2D>();
        mAttackHitbox.isKinematic = false;

    }
	

	void Update () {
		
	}

    void detectEnemies()
    {

    }
}

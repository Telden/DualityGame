using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    SpriteRenderer mColor;

    bool targetable = false;

	// Use this for initialization
	void Start () {
        mColor = gameObject.GetComponent<SpriteRenderer>();
        mColor.color = gameObject.GetComponent<SpriteRenderer>().color;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Highlight()
    {

        gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);


    }
    public void resetColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = mColor.color;
        targetable = true;
    }
}

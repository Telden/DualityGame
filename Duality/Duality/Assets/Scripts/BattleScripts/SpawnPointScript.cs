using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpawnPointScript : MonoBehaviour {

	public LoadCharacters mpLoadCharacters;
	ListManager mpListManager;
	bool mIsHoveredOver = false;
	Color mResetColor;
	[SerializeField]
	GameObject mSelectedUnit;
	public GameObject mSpawnPoints;

	// Use this for initialization
	void Start () {
		mResetColor = gameObject.GetComponent<SpriteRenderer>().color;
		mpListManager = GameObject.Find("GameSystem").GetComponent<ListManager>();
	}
	
	// Update is called once per frame
	void Update () {
		checkInput();
	}

	void OnMouseEnter()
	{
		gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f, 0.5f);
		mIsHoveredOver = true;

	}

	void OnMouseExit()
	{
		gameObject.GetComponent<SpriteRenderer>().color = mResetColor;
		mIsHoveredOver = false;
	}


	void checkInput()
	{
		if(mIsHoveredOver)
		{
			if(Input.GetMouseButtonDown(0))
			{
				mpLoadCharacters.getSelectedUnit().transform.position = gameObject.transform.position;
				gameObject.GetComponent<SpriteRenderer>().enabled = false;
				gameObject.GetComponent<BoxCollider2D>().enabled = false;
				//mSpawnPoints.SetActive(false);
			}
		}
	}
}

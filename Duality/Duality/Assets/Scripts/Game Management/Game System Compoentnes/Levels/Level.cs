using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Level : MonoBehaviour {

	[SerializeField]
	private int mLevelIndex; //Which level?
	public Image mImagePreview; //Show the layout of the level
	[SerializeField]
	private float[] mStartingLocations; //The different locations that the player can place units on
	[SerializeField]
	private int mTotalAllowed; //The total number of allowed characters on this level
	[SerializeField]
	private GameObject[] mSelectedUnits; //The Units that are selected for the level
							   //Brief Discription of the level
	Recruitment mpRecruitmentScript; // Script to get the selected army units
	private GameObject[] mArmy; // The selected army units




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

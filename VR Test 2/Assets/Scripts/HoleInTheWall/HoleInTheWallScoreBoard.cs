using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoleInTheWallScoreBoard : MonoBehaviour {

    public Text scoreboardText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeCounter(FloatVariable newNumber)
    {
        int number = (int)(Mathf.Ceil(newNumber.Value));
        scoreboardText.text = "" + number;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowStopper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        ArrowRotation ar = other.gameObject.GetComponent<ArrowRotation>();
        if (ar)
        {
            ar.StopRotation();
        }
    }
}

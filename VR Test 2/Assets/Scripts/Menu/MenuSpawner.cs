using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawner : MonoBehaviour {

    bool touchControllersAreTouching;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DebugText.DT.Debug("touchControllersAreTouching: " + touchControllersAreTouching);

    }

    public void SetTouchControllersAreTouching(bool controllersTouching)
    {
        touchControllersAreTouching = controllersTouching;
    }


}

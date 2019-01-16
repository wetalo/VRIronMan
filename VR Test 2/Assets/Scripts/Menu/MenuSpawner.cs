using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawner : MonoBehaviour {

    bool touchControllersAreTouching;

    bool hasSpawnedMenu = false;

    public GameObject menuPrefab;
    GameObject menuInstance = null;

    Vector3 pointA;
    Vector3 pointB;

    [SerializeField]
    float distanceBetween = 0.05f;

    public Transform playerHead;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (touchControllersAreTouching)
        {
            if (!hasSpawnedMenu)
            {
                if (TouchHandler.TH.RightTouchAButtonDown() && TouchHandler.TH.rightTouchPrimaryIndexTriggerPulled 
                    && TouchHandler.TH.LeftTouchAButtonDown() && TouchHandler.TH.leftTouchPrimaryIndexTriggerPulled)
                {
                    menuInstance = GameObject.Instantiate(menuPrefab);
                    hasSpawnedMenu = true;
                    pointA = TouchHandler.TH.LeftTouchPosition();
                    pointB = TouchHandler.TH.RightTouchPosition();

                    Vector3 between = (pointB - pointA).normalized;
                    float distance = between.magnitude;
                    //menuInstance.transform.localScale  = new Vector3(  distance, menuInstance.transform.localScale.y, menuInstance.transform.localScale.z);
                    menuInstance.transform.position = pointA + (between * distanceBetween);
                    
                    menuInstance.transform.LookAt(playerHead);
                }
            }
        }

    }

    public void SetTouchControllersAreTouching(bool controllersTouching)
    {
        touchControllersAreTouching = controllersTouching;

        if(!controllersTouching)
            hasSpawnedMenu = false;
    }


}

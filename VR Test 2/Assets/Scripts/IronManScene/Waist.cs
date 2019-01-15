using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waist : MonoBehaviour {

    public bool isTouchingController;
    public GameObject controllerTouched;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "GrabVolumeSmall")
        {
            isTouchingController = true;
            controllerTouched = other.gameObject;
            DebugText.DT.Debug(gameObject.name + " touched");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "GrabVolumeSmall")
        {
            isTouchingController = false;
        }
    }
}

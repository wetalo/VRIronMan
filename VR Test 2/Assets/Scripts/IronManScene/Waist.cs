using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waist : MonoBehaviour {

    public bool isTouchingController;
    public GameObject controllerTouched;
    OVRGrabber grabber;
    public GameObject gunPrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isTouchingController)
        {
            bool triggerPulled = false;
            if (grabber.name == "AvatarGrabberLeft")
            {
                triggerPulled = TouchHandler.TH.leftTouchPrimaryHandTriggerPulled;
            }
            else if (grabber.name == "AvatarGrabberRight")
            {
                triggerPulled = TouchHandler.TH.rightTouchPrimaryHandTriggerPulled;
            }

            if (triggerPulled && !grabber.grabbedObject)
            {
                GameObject gunInstance = GameObject.Instantiate(gunPrefab, controllerTouched.transform.position, controllerTouched.transform.rotation);
                OVRGrabbable grabbable = gunInstance.GetComponent<OVRGrabbable>();
                //grabbable.GrabBegin(grabber,grabbable.grabPoints[0]);
                isTouchingController = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        DebugText.DT.Debug(other.name + " entered");
        if (other.name == "GrabVolumeSmall" || other.name == "GrabVolumeBig")
        {
            isTouchingController = true;
            controllerTouched = other.gameObject;

            grabber = other.transform.parent.parent.gameObject.GetComponent<OVRGrabber>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DebugText.DT.Debug(other.name + " exited");
        if (other.name == "GrabVolumeSmall" || other.name == "GrabVolumeBig")
        {
            isTouchingController = false;
        }
    }
}

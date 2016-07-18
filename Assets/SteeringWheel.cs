using UnityEngine;
using System.Collections;

public class SteeringWheel : MonoBehaviour, Controllable
{
    public GameObject steeringWheel;
    public Steerable steerable;
    SteamVR_TrackedObject trackedObject;

    void Start ()
    {
        steeringWheel.SetActive(false);
    }
	
	void Update () {
        if (trackedObject != null)
        {
            var targetVelocity = trackedObject.transform.position - transform.position;
            targetVelocity = Vector3.ClampMagnitude(targetVelocity, steerable.maxSpeed);
            steeringWheel.transform.localScale = new Vector3(1, 1, targetVelocity.magnitude);
            steeringWheel.transform.LookAt(trackedObject.transform.position);
        }
	}

    public void OnButtonDown(ulong button, SteamVR_TrackedObject newTrackedObject)
    {
        if (button == SteamVR_Controller.ButtonMask.Grip)
        {
            trackedObject = newTrackedObject;
            steeringWheel.SetActive(true);
        }
    }

    public void OnButtonUp(ulong button)
    {
        if (button == SteamVR_Controller.ButtonMask.Grip)
        {
            steerable.targetVelocity = trackedObject.transform.position - transform.position;
            trackedObject = null;
            steeringWheel.SetActive(false);
        }
    }
}

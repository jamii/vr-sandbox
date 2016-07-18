using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour
{
    public SteamVR_Controller.Device device;

    public Collider target;
    public Transform tracker;
    public int framesGrabbing = 0;

    public Vector3 lastTransform;
    public Vector3 lastTracker;

    void Start()
    {
        var trackedObject = GetComponentInParent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObject.index);
    }

    void OnTriggerEnter(Collider other)
    {
        if (target == null)
        {
            target = other;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (target == other)
        {
            target = null;
        }
    }

    public void StartTracking()
    {
        if (device.GetPress(SteamVR_Controller.ButtonMask.Grip) && target != null)
        {
            tracker.transform.parent = target.transform;
            tracker.transform.position = transform.position;
            framesGrabbing += 1;
        }
        else
        {
            framesGrabbing = 0;
        }
        lastTracker = tracker.position;
        lastTransform = transform.position;
    }
}
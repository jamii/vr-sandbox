using UnityEngine;
using System.Collections;

public class Grab : MonoBehaviour {
    public Steerable player;

    public SteamVR_TrackedObject trackedObject;
    public SteamVR_Controller.Device device;
    public Vector3 lastPosition;
    public bool tracking = false;

    void Start()
    {
        trackedObject = GetComponentInParent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObject.index);
    }

    void OnTriggerStay()
    {
        if (device.GetPress(SteamVR_Controller.ButtonMask.Grip))
        {
            tracking = true;
        }
    }

    void Update()
    {
        if (!device.GetPress(SteamVR_Controller.ButtonMask.Grip))
        {
            tracking = false;
        }
        if (tracking)
        {
            player.velocity = (transform.position - lastPosition) / Time.deltaTime;
        }
        lastPosition = transform.position;
    }
}

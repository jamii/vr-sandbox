using UnityEngine;
using System.Collections;

public class VibrateOnCollision : MonoBehaviour
{
    public SteamVR_TrackedObject tracked;

    void OnCollisionStay(Collision coll)
    {
        var device = SteamVR_Controller.Input((int)tracked.index);
        device.TriggerHapticPulse();
    }

    void OnTriggerStay(Collider other)
    {
        var device = SteamVR_Controller.Input((int)tracked.index);
        device.TriggerHapticPulse();
    }
}
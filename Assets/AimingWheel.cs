using UnityEngine;
using System.Collections;

public class AimingWheel : MonoBehaviour, Controllable
{
    public GameObject aimingWheel;
    public Steerable steerable;
    public Steerable ammo;
    SteamVR_TrackedObject trackedObject;

    void Start()
    {
        aimingWheel.SetActive(false);
    }

    void Update()
    {
        if (trackedObject != null)
        {
            var targetVelocity = trackedObject.transform.position - transform.position;
            targetVelocity = Vector3.ClampMagnitude(targetVelocity, ammo.maxSpeed);
            aimingWheel.transform.localScale = new Vector3(1, 1, targetVelocity.magnitude);
            aimingWheel.transform.LookAt(trackedObject.transform.position);
        }
    }

    public void OnButtonDown(ulong button, SteamVR_TrackedObject newTrackedObject)
    {
        if (button == SteamVR_Controller.ButtonMask.Trigger)
        {
            trackedObject = newTrackedObject;
            aimingWheel.SetActive(true);
        }
    }

    public void OnButtonUp(ulong button)
    {
        if (button == SteamVR_Controller.ButtonMask.Trigger)
        {
            var targetVelocity = trackedObject.transform.position - transform.position;
            var fired = GameObject.Instantiate(ammo);
            fired.gameObject.SetActive(true);
            fired.transform.position = transform.position + (0.06f * targetVelocity.normalized);
            fired.transform.rotation = transform.rotation;
            fired.velocity = steerable.velocity;
            fired.targetVelocity = targetVelocity;
            trackedObject = null;
            aimingWheel.SetActive(false);
        }
    }
}

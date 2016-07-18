using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
    public GameObject ship;

    SteamVR_TrackedObject trackedObject;
    SteamVR_Controller.Device device;
    ulong button = 0;
    Controllable[] controllables;

    void Start()
    {
        trackedObject = GetComponentInParent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObject.index);
    }

    void OnTriggerStay(Collider other)
    {
        if (button == 0)
        {
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            {
                button = SteamVR_Controller.ButtonMask.Grip;
            }
            else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                button = SteamVR_Controller.ButtonMask.Trigger;
            }
            if (button != 0)
            {
                controllables = other.GetComponents<Controllable>();
                if (controllables.Length == 0)
                {
                    button = 0;
                }
                foreach (var controllable in controllables)
                {
                    controllable.OnButtonDown(button, trackedObject);
                }
            }
        }
    }

    void Update()
    {
        if (button != 0)
        {
            if (device.GetPressUp(button))
            {
                foreach (var controllable in controllables)
                {
                    controllable.OnButtonUp(button);
                }
                button = 0;
                controllables = new Controllable[0];
            }
        } else if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            var newShip = GameObject.Instantiate(ship);
            newShip.transform.position = trackedObject.transform.position;
            newShip.SetActive(true);
        }
    }
}
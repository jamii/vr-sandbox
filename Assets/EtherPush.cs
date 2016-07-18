using UnityEngine;
using System.Collections;

public class EtherPush : MonoBehaviour {
    public Steerable player;

    public SteamVR_TrackedObject trackedObject;
    public SteamVR_Controller.Device device;
    int node;

    void Start()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObject.index);
        node = 2000 + (int)device.index;
        OSCHandler.Instance.SendMessageToClient<System.Object>("SuperCollider", "/s_new", "tutorial-args", node, 1, 1, "out", (int) device.index - 1, "vol", 0);
    }

    void Update()
    {
        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            OSCHandler.Instance.SendMessageToClient<System.Object>("SuperCollider", "/n_set", node, "vol", 1, "freq", transform.position.y * 500);

        }
        else
        {
            OSCHandler.Instance.SendMessageToClient<System.Object>("SuperCollider", "/n_set", node, "vol", 0, "freq", transform.position.y * 500);
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            player.velocity += -trackedObject.transform.forward.normalized;
        }
    }
}

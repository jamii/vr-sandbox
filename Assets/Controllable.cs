using UnityEngine;
using System.Collections;

public interface Controllable
{
    void OnButtonDown(ulong button, SteamVR_TrackedObject trackedObject);

    void OnButtonUp(ulong button);
}
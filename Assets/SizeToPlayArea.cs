using UnityEngine;
using Valve.VR;

[ExecuteInEditMode, RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class SizeToPlayArea : MonoBehaviour
{
    public static bool GetBounds(ref HmdQuad_t pRect)
    {
        var initOpenVR = (!SteamVR.active && !SteamVR.usingNativeSupport);
        if (initOpenVR)
        {
            var error = EVRInitError.None;
            OpenVR.Init(ref error, EVRApplicationType.VRApplication_Other);
        }

        var chaperone = OpenVR.Chaperone;
        bool success = (chaperone != null) && chaperone.GetPlayAreaRect(ref pRect);
        if (!success)
            Debug.LogWarning("Failed to get Calibrated Play Area bounds!  Make sure you have tracking first, and that your space is calibrated.");

        if (initOpenVR)
            OpenVR.Shutdown();

        return success;
    }

    public void Update()
    {
        var rect = new HmdQuad_t();
        if (!GetBounds(ref rect))
            return;
        var transform = GetComponent<Transform>();
        transform.localPosition = new Vector3(0, 0, 0);
        transform.localScale = new Vector3(rect.vCorners2.v0 - rect.vCorners0.v0, rect.vCorners2.v1 - rect.vCorners0.v1, rect.vCorners2.v2 - rect.vCorners0.v2);
    }
}
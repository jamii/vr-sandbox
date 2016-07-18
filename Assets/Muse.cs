using UnityEngine;
using System.Collections;

public class Muse : MonoBehaviour
{
    public GameObject platonicStroke;

    public GameObject[] hands;
    public SteamVR_Controller.Device[] devices;
    public SteamVR_TrackedObject[] tracked;
    public ArrayList strokes;

    public bool refreshControls;

    public static Muse only;

    void Start()
    {
        only = this;
        hands = new GameObject[2];
        devices = new SteamVR_Controller.Device[2];
        tracked = new SteamVR_TrackedObject[3];
        strokes = new ArrayList();
        refreshControls = false; // no point refreshing until at least one control comes online
    }

    void FindControls()
    {
        Debug.Log("Finding controls");
        hands[0] = GameObject.Find("Controller (left)");
        hands[1] = GameObject.Find("Controller (right)");
        for (var i = 0; i < 2; i++)
        {
            if (hands[i] != null)
            {
                tracked[i] = hands[i].GetComponent<SteamVR_TrackedObject>();
                devices[i] = SteamVR_Controller.Input((int)tracked[i].index);
            } 
        }
        tracked[2] = GameObject.Find("Camera (head)").GetComponent<SteamVR_TrackedObject>();
        for (var i = 0; i < tracked.Length; i++)
        {
            if (tracked[i] == null)
            {
                Debug.Log("Tracked " + i + " missing");
            }
        }
    }
	
	void Update ()
    {
        if (refreshControls)
        {
            FindControls();
            refreshControls = false;
        }
        for (var i = 0; i < tracked.Length; i++)
        {
            if (tracked[i] != null)
            {
                tracked[i].Apply();
            }
        }
	    for (var i = 0; i < 2; i++)
        {
            if (hands[i] != null && devices[i].GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) {
                var stroke = GameObject.Instantiate(platonicStroke);
                stroke.GetComponent<Stroke>().control = i;
                stroke.SetActive(true);
                strokes.Add(stroke);
            }
        }
	}
}

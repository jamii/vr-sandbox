using UnityEngine;
using System.Collections;

public class OSCCall : MonoBehaviour {

	// Use this for initialization
	void Start () {
        OSCHandler.Instance.Init();
        Debug.Log("OSC init");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

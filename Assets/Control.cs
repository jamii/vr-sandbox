using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {
	void OnEnable () {
        Debug.Log(gameObject.name + " enabled");
        GameObject.Find("Player").GetComponent<Muse>().refreshControls = true;
	}

    void OnDisable()
    {
        Debug.Log(gameObject.name + " disabled");
        GameObject.Find("Player").GetComponent<Muse>().refreshControls = true;
    }
}

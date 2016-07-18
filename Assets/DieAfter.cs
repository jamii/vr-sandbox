using UnityEngine;
using System.Collections;

public class DieAfter : MonoBehaviour {
    public GameObject killable;
    public float lifetime;
    float born;
    
	void Start () {
        born = Time.fixedTime;
	}
	
	void Update () {
	    if (Time.fixedTime - born > lifetime)
        {
            killable.GetComponent<Killable>().Kill();
        }
	}
}

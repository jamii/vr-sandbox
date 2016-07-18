using UnityEngine;
using System.Collections;

public class DieOnTrigger : MonoBehaviour {
    public GameObject killable;

	void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.name != "Controller")
        {
            killable.GetComponent<Killable>().Kill();
        }
    }
}

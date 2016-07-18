using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
    public float radius;
    public float speed;
    public bool flip;
    Vector3 origin;

	void Awake()
    {
        origin = this.GetComponent<Transform>().localPosition;
    }

    void Update() {
        if (flip) {
            this.GetComponent<Transform>().localPosition = origin + new Vector3(Mathf.Sin(Time.fixedTime * speed) * radius, Mathf.Cos(Time.fixedTime * speed) * radius, 0);
        } else
        {
            this.GetComponent<Transform>().localPosition = origin + new Vector3(Mathf.Sin(Time.fixedTime * speed) * radius, 0, Mathf.Cos(Time.fixedTime * speed) * radius);
        }
    }
}
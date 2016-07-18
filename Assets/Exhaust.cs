using UnityEngine;
using System.Collections;

public class Exhaust : MonoBehaviour {
    public Steerable steerable;
    Vector3 maxScale;

	void Start () {
        steerable = GetComponentInParent<Steerable>();
        maxScale = transform.localScale;
	}
	
	void Update () {
        transform.LookAt(transform.position + steerable.acceleration);
        transform.localScale = new Vector3(maxScale.x, maxScale.y, maxScale.z * steerable.acceleration.magnitude / steerable.maxAcceleration);
	}
}

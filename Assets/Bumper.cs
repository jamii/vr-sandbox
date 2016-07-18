using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour {
    public Steerable frame;
    Vector3 contact;
    Vector3 normal;
    Transform tracker;
    float collisionTime;

    void Start()
    {
        tracker = transform.GetChild(0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "EyeTrigger" || other.gameObject.name == "LeftTrigger" || other.gameObject.name == "RightTrigger")
        {
            contact = GetComponent<Collider>().ClosestPointOnBounds(other.transform.position);
            normal = contact - transform.position;
            tracker.position = contact;
            tracker.parent = other.transform;
            collisionTime = Time.time;
            Debug.Log("track");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if ((Time.time > collisionTime) && (tracker.parent == other.transform))
        {
            var projected = Vector3.Project(frame.velocity - (tracker.position - contact) / Time.deltaTime, normal);
            frame.velocity -= projected * 2;
            Debug.Log(normal);
            Debug.Log(1000 * (tracker.position - contact));
            Debug.Log(1000 * projected);
            Debug.Log("bounce");
            tracker.parent = transform;
        }
    }
}

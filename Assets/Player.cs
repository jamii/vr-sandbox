using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public Hand left;
    public Hand right;
    public Vector3 velocity;

    public void Move()
    {
        var oldPosition = transform.position;
        if (left.framesGrabbing > 0 && right.framesGrabbing > 0)
        {
            // surely this could be simplified
            var trackerCenter = (left.tracker.position + right.tracker.position) / 2;
            transform.position = trackerCenter;
            transform.rotation = Quaternion.FromToRotation(left.transform.position - right.transform.position, left.tracker.position - right.tracker.position) * transform.rotation;
            transform.localScale = transform.localScale * (left.tracker.position - right.tracker.position).magnitude / (left.transform.position - right.transform.position).magnitude;
            var handCenter = (left.transform.position + right.transform.position) / 2;
            transform.position += trackerCenter - handCenter;
        }
        else if (left.framesGrabbing > 0)
        {
            transform.position += left.tracker.position - left.transform.position;
        }
        else if (right.framesGrabbing > 0)
        {
            transform.position += right.tracker.position - right.transform.position;
        } else
        {
            transform.position += velocity * Time.fixedDeltaTime;
        }
        velocity = (transform.position - oldPosition) / Time.fixedDeltaTime;
    }
}

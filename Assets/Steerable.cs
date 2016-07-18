using UnityEngine;
using System.Collections;

public class Steerable : MonoBehaviour {
    public Vector3 velocity;
    public Vector3 acceleration;
    public Vector3 rotationAxis;
    public float rotationSpeed;

    public Vector3 targetVelocity;
    public float maxSpeed;
    public float maxAcceleration;
    
    public void Steer()
    {
        //acceleration = targetVelocity - velocity;
        //acceleration = Vector3.ClampMagnitude(acceleration, maxAcceleration);
        velocity += acceleration * Time.fixedDeltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        transform.Translate(velocity * Time.fixedDeltaTime, Space.World);
        transform.Rotate(rotationAxis, rotationSpeed * Time.fixedDeltaTime, Space.Self);
    }
}

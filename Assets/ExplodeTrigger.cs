using UnityEngine;
using System.Collections;

public class ExplodeTrigger : MonoBehaviour {
    public Steerable frame;
    public float maxTimer;
    float timer;

    void Start()
    {
        timer = maxTimer;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "EyeTrigger" || other.gameObject.name == "LeftTrigger" || other.gameObject.name == "RightTrigger")
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                frame.velocity -= 5 * (other.transform.position - transform.position).normalized;
                timer = maxTimer;
                Destroy(transform.parent.gameObject);
            }
        }
    }
}

using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    public float lifetime;
    public string killer;
    float birth;

    void Awake()
    {
        birth = Time.fixedTime;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.name == killer)
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if (Time.fixedTime - birth > lifetime)
        {
            Destroy(this.gameObject);
        }
    }
}
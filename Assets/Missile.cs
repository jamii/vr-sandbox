using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour, Killable
{
    public GameObject unarmed;
    public GameObject armed;
    public float armingRange;
    public float maxRange;
    public GameObject boom;
    Vector3 start;
    bool isArmed = false;
    
	void Start () {
        armed.SetActive(false);
        start = transform.position;
	}
	
	void Update () {
        var travelled = (transform.position - start).magnitude;
        if (!isArmed && (travelled > armingRange))
        {
            isArmed = true;
            unarmed.SetActive(false);
            armed.SetActive(true);
        }
        if (isArmed && (travelled > maxRange))
        {
            Kill();
        }
	}

    public void Kill()
    {
        var boomed = GameObject.Instantiate(boom);
        boomed.SetActive(true);
        boomed.transform.position = transform.position;
        GameObject.Destroy(gameObject);
    }
}

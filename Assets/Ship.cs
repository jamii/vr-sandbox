using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour, Killable
{
    public GameObject boom;

    public void Kill()
    {
        GameObject.Destroy(gameObject);
        var boomed = GameObject.Instantiate(boom);
        boomed.SetActive(true);
        boomed.transform.position = transform.position;
    }
}

using UnityEngine;
using System.Collections;

public class Boom : MonoBehaviour, Killable {
    public void Kill()
    {
        GameObject.Destroy(this.gameObject);
    }
}

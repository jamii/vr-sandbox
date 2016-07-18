using UnityEngine;
using System.Collections;

public class Trail : MonoBehaviour {
    public GameObject prefab;
    public float interval_s;
    float last_spawn_s;
	
	// Update is called once per frame
	void Update () {
        if (Time.fixedTime - last_spawn_s > interval_s) {
            last_spawn_s = Time.fixedTime;
            var spawn = GameObject.Instantiate(prefab);
            spawn.transform.position = GetComponent<Transform>().position;
        }
	}
}

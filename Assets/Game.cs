using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
    public Steerable world; 
    public Steerable spar;
    public Transform mine;
    public Transform bumper;
    public Player player;
    public Hand left;
    public Hand right;

    //void Awake()
    //{
    //    spawns = new ArrayList();
    //    for (var i = 0; i < 100; i++)
    //    {
    //        var spawned = GameObject.Instantiate(spawn);
    //        spawned.transform.localPosition = Random.onUnitSphere * Random.Range(1f, 10f);
    //        spawned.transform.Rotate(Random.onUnitSphere, Random.Range(0f, 360f));
    //        spawned.gameObject.SetActive(true);
    //        spawns.Add(spawned);
    //    }
    //    for (var i = 0; i < 3; i++)
    //    {
    //        var centre = Random.onUnitSphere * 10f;
    //        foreach (Rigidbody spawned in spawns)
    //        {
    //            spawned.AddExplosionForce(10, centre, 100000000);
    //        }
    //    }
    //}

    void Awake()
    {
        for (var i = 0; i < 100; i++)
        {
            var spawned = GameObject.Instantiate(spar);
            spawned.transform.SetParent(world.transform);
            spawned.transform.position = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
            spawned.transform.Rotate(Random.onUnitSphere, Random.Range(0f, 360f));
            spawned.rotationAxis = Random.onUnitSphere;
            spawned.rotationSpeed = Random.Range(-10f, 10f);
            spawned.gameObject.SetActive(true);
        }
        //for (var i = 0; i < 100; i++)
        //{
        //    var spawned = GameObject.Instantiate(mine);
        //    spawned.transform.SetParent(world.transform);
        //    spawned.transform.position = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        //    spawned.gameObject.SetActive(true);
        //}
        //for (var i = 0; i < 100; i++)
        //{
        //    var spawned = GameObject.Instantiate(bumper);
        //    spawned.transform.SetParent(world.transform);
        //    spawned.transform.position = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        //    spawned.gameObject.SetActive(true);
        //}
    }

    void FixedUpdate()
    {
        if (left.device != null)
        {
            left.StartTracking();
        }
        if (right.device != null)
        {
            right.StartTracking();
        }
        foreach (var tracked in player.GetComponentsInChildren<SteamVR_TrackedObject>())
        {
            tracked.Apply();
        }
        foreach (var steerable in world.GetComponentsInChildren<Steerable>())
        {
            steerable.Steer();
        }
        player.Move();
    }

    //void Spawn()
    //{
    //    var spawned = GameObject.Instantiate(spawn);
    //    spawned.transform.SetParent(world.transform);
    //    spawned.transform.position = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 10f);
    //    spawned.transform.Rotate(Random.onUnitSphere, Random.Range(0f, 360f));
    //    spawned.rotationAxis = Random.onUnitSphere;
    //    spawned.rotationSpeed = Random.RandomRange(-10f, 10f) * world.velocity.z;
    //    //spawned.GetComponentInChildren<Transform>().localPosition = Random.onUnitSphere;
    //    spawned.gameObject.SetActive(true);
    //}
}

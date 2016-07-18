using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Stroke : MonoBehaviour
{
    public int control;
    public int maxPoints;
    public int nextPoint;
    public Vector3[] points;
    public bool[] edges;

    public Mesh mesh;
    public Vector3[] vertices;
    public Vector3[] normals;
    public int[] triangles;
    public Bounds bounds;

    public Vector3[] offsets;
    public int[] pyramid;

    void Start()
    {
        // control is set externally
        maxPoints = 10000;
        nextPoint = 0;
        points = new Vector3[maxPoints];
        edges = new bool[maxPoints];

        mesh = GetComponent<MeshFilter>().mesh = new Mesh();
        vertices = mesh.vertices = new Vector3[4 * maxPoints];
        normals = mesh.normals = new Vector3[4 * maxPoints];
        triangles = mesh.triangles = new int[12 * maxPoints];
        bounds = mesh.bounds;
        
        offsets = new Vector3[3];
        for (var i = 0; i < 3; i++)
        {
            var angle = 2 * Mathf.PI * i / 3f;
            offsets[i] = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0);
        }
        pyramid = new int[]
        {
            0, 1, 3,
            0, 2, 1,
            0, 3, 2,
            1, 2, 3,
        };
    }

    void Update()
    {
        if (Muse.only.devices[control].GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            points[nextPoint] = Muse.only.hands[control].transform.position;
            if (!Muse.only.devices[control].GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                edges[nextPoint] = true;
                SetVertices(nextPoint);
                SetTriangles(nextPoint);
            }
            nextPoint += 1;
        }
    }

    void SetVertices(int nextPoint)
    {
        var forward = points[nextPoint] - points[nextPoint - 1];
        var lookForward = Quaternion.FromToRotation(Vector3.forward, forward);
        vertices[4 * nextPoint] = points[nextPoint-1];
        normals[4 * nextPoint] = -forward;
        bounds.Encapsulate(vertices[4 * nextPoint]);
        for (var i = 0; i < 3; i++)
        {
            var nextVertex = (4 * nextPoint) + i + 1;
            var offset = lookForward * offsets[i];
            vertices[nextVertex] = points[nextPoint] + (0.001f * offset);
            normals[nextVertex] = offset;
            bounds.Encapsulate(vertices[nextVertex]);
        }
        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.bounds = bounds;
    }

    void SetTriangles(int nextPoint)
    {
        var nextVertex = 4 * nextPoint;
        var nextTriangle = 12 * nextPoint;
        for (var i = 0; i < 12; i++)
        {
            triangles[nextTriangle + i] = nextVertex + pyramid[i];
        }
        mesh.triangles = triangles;
    }
}

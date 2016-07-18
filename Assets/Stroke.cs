using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Stroke : MonoBehaviour
{
    public int control;
    public bool stroking;
    public Vector3[] points;
    public int maxPoints = 10000;
    public int nextPoint = 0;

    public Mesh mesh;
    public Vector3[] vertices;
    public Vector3[] normals;
    public int[] triangles;
    public Bounds bounds;

    public Vector3[] offsets;

    void Start()
    {
        // control is set externally
        stroking = true;
        points = new Vector3[maxPoints];

        mesh = GetComponent<MeshFilter>().mesh = new Mesh();
        vertices = mesh.vertices = new Vector3[3 * maxPoints];
        normals = mesh.normals = new Vector3[3 * maxPoints];
        triangles = mesh.triangles = new int[18 * maxPoints];
        bounds = mesh.bounds;
        
        offsets = new Vector3[6];
        for (var i = 0; i < 6; i++)
        {
            var angle = 2 * Mathf.PI * i / 6f;
            offsets[i] = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0);
        }

        points[nextPoint] = Muse.only.hands[control].transform.position;
        for (var i = 0; i < 3; i++)
        {
            vertices[i] = points[nextPoint];
        }
        nextPoint += 1;
    }

    void Update()
    {
        if (Muse.only.devices[control].GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            stroking = false;
        }
        if (stroking)
        {
            points[nextPoint] = Muse.only.hands[control].transform.position;
            SetVertices(nextPoint);
            SetTriangles(nextPoint);
            nextPoint += 1;
        }
    }

    void SetVertices(int nextPoint)
    {
        var forward = points[nextPoint] - points[nextPoint - 1];
        var lookForward = Quaternion.FromToRotation(Vector3.forward, forward);
        Debug.Log("offsets");
        for (var i = 0; i < 3; i++)
        {
            var nextVertex = (3 * nextPoint) + i;
            var nextOffset = (nextPoint + (2 * i)) % 6;
            var offset = lookForward * offsets[nextOffset];
            vertices[nextVertex] = points[nextPoint] + (0.05f * offset);
            normals[nextVertex] = offset;
            bounds.Encapsulate(vertices[nextVertex]);
        }
        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.bounds = bounds;
    }

    void SetTriangles(int nextPoint)
    {
        var nextVertex = 3 * nextPoint;
        var nextTriangle = (18 * (nextPoint - 1));
        triangles[nextTriangle + 0] = nextVertex - 3;
        triangles[nextTriangle + 1] = nextVertex + 0;
        triangles[nextTriangle + 2] = nextVertex - 2;
        triangles[nextTriangle + 3] = nextVertex - 2;
        triangles[nextTriangle + 4] = nextVertex + 1;
        triangles[nextTriangle + 5] = nextVertex - 1;
        triangles[nextTriangle + 6] = nextVertex - 1;
        triangles[nextTriangle + 7] = nextVertex + 2;
        triangles[nextTriangle + 8] = nextVertex - 3;
        triangles[nextTriangle + 9] = nextVertex + 0;
        triangles[nextTriangle + 10] = nextVertex + 1;
        triangles[nextTriangle + 11] = nextVertex - 2;
        triangles[nextTriangle + 12] = nextVertex + 1;
        triangles[nextTriangle + 13] = nextVertex + 2;
        triangles[nextTriangle + 14] = nextVertex - 1;
        triangles[nextTriangle + 15] = nextVertex + 2;
        triangles[nextTriangle + 16] = nextVertex + 0;
        triangles[nextTriangle + 17] = nextVertex - 3;
        // temporarily close the end
        triangles[nextTriangle + 18] = nextVertex + 0;
        triangles[nextTriangle + 19] = nextVertex + 2;
        triangles[nextTriangle + 20] = nextVertex + 1;
        mesh.triangles = triangles;
    }
}

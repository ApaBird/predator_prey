using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(MeshFilter)), RequireComponent(typeof(MeshRenderer)), RequireComponent(typeof(MeshCollider))]

public class UnityTerrain : MonoBehaviour
{
    private Terrain terrain;
    private List<Vector3> vertexes = new List<Vector3>();
    private List<int> triangles = new List<int>();

    public Terrain Terrain { get => terrain; set => terrain = value; }

    public void GenerateMesh()
    {
        Mesh mesh = new Mesh();

        for(int i = 0; i < terrain.Height - 1; i++)
        {
            for(int j = 0; j < terrain.Width - 1; j++)
            {
                Vector3 dot1 = new Vector3(i + 1, terrain.GetValueMap(i + 1, j), j);
                Vector3 dot2 = new Vector3(i + 1, terrain.GetValueMap(i + 1, j + 1), j + 1);
                Vector3 dot3 = new Vector3(i, terrain.GetValueMap(i, j + 1), j + 1);
                Vector3 dot4 = new Vector3(i, terrain.GetValueMap(i, j), j);

                GeneratePlane(dot3, dot2, dot1, dot4);
            }
        }

        mesh.vertices = vertexes.ToArray();
        mesh.triangles = triangles.ToArray();

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }

    private void GeneratePlane(Vector3 dot1, Vector3 dot2, Vector3 dot3, Vector3 dot4)//Ќеобходимо правильно посылать точки, dot1 - лева€ нижн€€ dot3 - права€ верхн€€, идем по часовой
    {
        vertexes.Add(dot1);
        vertexes.Add(dot2);
        vertexes.Add(dot3);
        vertexes.Add(dot4);

        triangles.Add(vertexes.Count - 4);
        triangles.Add(vertexes.Count - 3);
        triangles.Add(vertexes.Count - 1);

        triangles.Add(vertexes.Count - 1);
        triangles.Add(vertexes.Count - 3);
        triangles.Add(vertexes.Count - 2);
    }
}

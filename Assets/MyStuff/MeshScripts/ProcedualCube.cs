using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProcedualCube : MonoBehaviour
{
    Mesh mesh;
    List<Vector3> vertices;
    List<int> triangles;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        MakeCube();
        UpdateMesh();
    }
    void MakeCube()
    {
        vertices = new List<Vector3>();
        triangles = new List<int>();

        for (int i = 0; i < 6; i++)
        {
            MakeFace(i);
        }

    }
    void MakeFace(int dir)
    {
        vertices.AddRange(CubeMeshData.faceVertices(dir));
        int vCount = vertices.Count;

        triangles.Add(vCount - 4);
        triangles.Add(vCount - 4 + 1);
        triangles.Add(vCount - 4 + 2);
        triangles.Add(vCount - 4);
        triangles.Add(vCount - 4 + 2);
        triangles.Add(vCount - 4 + 3);
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
    }
}
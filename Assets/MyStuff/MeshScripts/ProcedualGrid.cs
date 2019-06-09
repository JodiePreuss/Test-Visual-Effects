using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProcedualGrid : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    // Grid Settings:
    public float cellSize = 1;
    public Vector3 gridOffset;
    public int gridSize;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        MakeDiscreteProzedualGrid();
        UpdateMesh();
    }

    void MakeDiscreteProzedualGrid()
    {
        //Set Array Size:
        vertices = new Vector3[gridSize * gridSize * 4];
        triangles = new int[gridSize * gridSize * 6];

        // Set Tracker integer:
        int v = 0;
        int t = 0;

        // Set Vertex Offset:
        float vertexOffset = cellSize * 0.5f;

        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Vector3 cellOffset = new Vector3(x * cellSize, 0, y * cellSize);

                // Populate the vertices and triangles:
                vertices[v] = new Vector3(-vertexOffset, (x + y) * 0.3f, -vertexOffset) + cellOffset + gridOffset;
                vertices[v + 1] = new Vector3(-vertexOffset, (x + y) * 0.3f, vertexOffset) + cellOffset + gridOffset;
                vertices[v + 2] = new Vector3(vertexOffset, (x + y) * 0.3f, -vertexOffset) + cellOffset + gridOffset;
                vertices[v + 3] = new Vector3(vertexOffset, (x + y) * 0.3f, vertexOffset) + cellOffset + gridOffset;

                triangles[t] = v;
                triangles[t + 1] = triangles[t + 4] = v + 1;
                triangles[t + 2] = triangles[t + 3] = v + 2;
                triangles[t + 5] = v + 3;

                v = v + 4;
                t = t + 6;
            }
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}

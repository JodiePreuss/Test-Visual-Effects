using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ContiguousGrid : MonoBehaviour
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
        MakeContiguousProzedualGrid();
        UpdateMesh();
    }

    void MakeContiguousProzedualGrid()
    {
        //Set Array Size:
        vertices = new Vector3[(gridSize + 1) * (gridSize + 1)];
        triangles = new int[gridSize * gridSize * 6];

        // Set Tracker integer:
        int v = 0;
        int t = 0;

        // Set Vertex Offset:
        float vertexOffset = cellSize * 0.5f;

        // Create Vertex Grid:
        for (int x = 0; x <= gridSize; x++)
        {
            for (int y = 0; y <= gridSize; y++)
            {
                vertices[v] = new Vector3((x + cellSize) - vertexOffset, (x + y) * 0.3f, (y + cellSize) - vertexOffset);
                v++;
            }
        }

        // Reset Vertex Tracker:
        v = 0;

        // Setting each Cell's Triangles:
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                triangles[t] = v;
                triangles[t + 1] = triangles[t + 4] = v + 1;
                triangles[t + 2] = triangles[t + 3] = v + (gridSize + 1);
                triangles[t + 5] = v + (gridSize + 1) + 1;
                v++;
                t += 6;
            }
            v++;
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

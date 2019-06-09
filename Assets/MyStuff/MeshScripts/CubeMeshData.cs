using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CubeMeshData
{
    public static Vector3[] vertices =
    {
        new Vector3(1,1,1),
        new Vector3(-1,1,1),
        new Vector3(-1,-1,1),
        new Vector3(1,-1,1),
        new Vector3(-1,1,-1),
        new Vector3(1,1,-1),
        new Vector3(1,-1,-1),
        new Vector3(-1,-1,-1)
    };

    public static int[][] faceTriangles =
    {
        new int[] {0,1,2,3},
        new int[] {0,3,6,5},
        new int[] {4,5,6,7},
        new int[] {4,7,2,1},
        new int[] {0,5,4,1},
        new int[] {2,7,6,3}
    };

    public static Vector3[] faceVertices(int dir)
    {
        Vector3[] fv = new Vector3[4];
        for (int i = 0; i < fv.Length; i++)
        {
            fv[i] = vertices[faceTriangles[dir][i]];
        }
        return fv;
    }
}

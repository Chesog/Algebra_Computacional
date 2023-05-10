using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
using System;

public class Vec_Grid : MonoBehaviour
{
    public static Vec3[,,] v_Grid;
    public int sizeX = 1;
    public int sizeY = 1;
    public int sizeZ = 1;
    public bool showGrid;
    public float pointsInGridSize = 0.1f;
    public static float delta = 1f;

    // Start is called before the first frame update
    void Start()
    {
        v_Grid = new Vec3[sizeX,sizeY,sizeZ];

        for (int x = 0; x < v_Grid.GetLength(0); x++)
        {
            for (int y = 0; y < v_Grid.GetLength(1); y++)
            {
                for (int z = 0; z < v_Grid.GetLength(2); z++)
                {
                    // Lo multiplico por delta para que cada punto tenga una separacion
                    v_Grid[x, y, z] = new Vec3(x,y,z) * delta;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        { return; }

        Gizmos.color = Color.black;

        if (!showGrid)
            return;

        for (int x = 0; x < v_Grid.GetLength(0); x++)
        {
            for (int y = 0; y < v_Grid.GetLength(1); y++)
            {
                for (int z = 0; z < v_Grid.GetLength(2); z++)
                {
                    Gizmos.DrawWireSphere(v_Grid[x,y,z], pointsInGridSize);
                }
            }
        }
    }
}

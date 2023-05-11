using CustomMath;
using System;
using System.Collections.Generic;
using UnityEngine;
using Color = UnityEngine.Color;



public class Vec_MeshColider : MonoBehaviour
{
    public int createdPlanes = 0;
    public bool showV_MeshColider;
    public List<Vec_Plane> m_planes;
    public List<Vec3> p_Inside_Mesh;
    public List<Vec3> pointsToCheck;
    public Mesh objMesh;


    public List<Vec3> colP;

    // Start is called before the first frame update
    void Start()
    {
        objMesh = GetComponent<MeshFilter>().mesh;
        p_Inside_Mesh = new List<Vec3>();
        pointsToCheck = new List<Vec3>();
        colP = new List<Vec3>();
        m_planes = new List<Vec_Plane>();
    }

    // Update is called once per frame
    void Update()
    {
        m_planes.Clear();
        createdPlanes = 0;

        // i += 3 Por que Recorremos los puntos de 3 en 3 Para conseguir los vertices de la mesh

        for (int i = 0; i < objMesh.GetIndices(0).Length; i += 3)
        {
            Vec3 v1 = new Vec3(transform.TransformPoint(objMesh.vertices[objMesh.GetIndices(0)[i]]));
            Vec3 v2 = new Vec3(transform.TransformPoint(objMesh.vertices[objMesh.GetIndices(0)[i + 1]]));
            Vec3 v3 = new Vec3(transform.TransformPoint(objMesh.vertices[objMesh.GetIndices(0)[i + 2]]));

            Vec_Plane plane = new Vec_Plane(v1, v2, v3);
            plane.normal *= -1;
            plane.Flip();
            m_planes.Add(plane);
            createdPlanes++;
        }

        // Por las dudas
        //foreach (var item in m_planes)
        //{
        //    item.Flip();
        //}


        //float nearPX = transform.position.x / Vec_Grid.delta;
        //float nearPY = transform.position.y / Vec_Grid.delta;
        //float nearPZ = transform.position.z / Vec_Grid.delta;
        //
        //// Redondea para arriba o abajo si es mayor a 0.5f
        //int x = nearPX - (int)nearPX > 0.5f ? (int)(nearPX + 1.0f) : (int)(nearPX);
        //int y = nearPY - (int)nearPY > 0.5f ? (int)(nearPY + 1.0f) : (int)(nearPY);
        //int z = nearPZ - (int)nearPZ > 0.5f ? (int)(nearPZ + 1.0f) : (int)(nearPZ);

        pointsToCheck.Clear();

        for (int x = 0; x < Vec_Grid.v_Grid.GetLength(0); x++)
        {
            for (int y = 0; y < Vec_Grid.v_Grid.GetLength(1); y++)
            {
                for (int z = 0; z < Vec_Grid.v_Grid.GetLength(2); z++)
                {
                    pointsToCheck.Add(Vec_Grid.v_Grid[x, y, z]);
                }
            }
        }

        p_Inside_Mesh.Clear();
        colP.Clear();
        // Chekea los puntos y si estan dentro de la mesh los agrega a la lista de p_Inside_Mesh
        foreach (var point in pointsToCheck)
        {
            int counter = 0;
            
            foreach (var plane in m_planes)
            {
                if (IsPointInPlane(plane, point, out Vec3 collisionPoint))
                {
                    if (IsValidPlane(plane, collisionPoint))
                    {
                        colP.Add(collisionPoint);
                        counter++;
                    }
                }
            }

            //Debug.Log("counter " + counter);

            if (counter % 2 == 1)
            {
                Debug.Log("Point cord " + point);
                p_Inside_Mesh.Add(point);
            }
        }

        DrawMeshPlanes();
    }

    public bool IsPointColliding(Vec3 pointToCheck)
    {
        foreach (var item in p_Inside_Mesh)
        {
            if (pointToCheck == item)
            {
                return true;
            }
        }
        return false;
    }

    // http://www.jeffreythompson.org/collision-detection/tri-point.php
    // Triangle Point Collision

    // Arreglar Esto Que parece ser donde esta el problema 
    private bool IsValidPlane(Vec_Plane mesh_P, Vec3 point)
    {
        float x1 = mesh_P.va.x; float y1 = mesh_P.va.y;
        float x2 = mesh_P.vb.x; float y2 = mesh_P.vb.y;
        float x3 = mesh_P.vc.x; float y3 = mesh_P.vc.y;

        // Area del triangulo
        float areaOrig = Mathf.Abs((x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1));

        // Areas de los 3 triangulos hechos con el punto y las esquinas
        float area1 = Mathf.Abs((x1 - point.x) * (y2 - point.y) - (x2 - point.x) * (y1 - point.y));
        float area2 = Mathf.Abs((x2 - point.x) * (y3 - point.y) - (x3 - point.x) * (y2 - point.y));
        float area3 = Mathf.Abs((x3 - point.x) * (y1 - point.y) - (x1 - point.x) * (y3 - point.y));


        // Si la suma del area de los 3 triangulos es igual a la del original estamos adentro
        return Math.Abs(area1 + area2 + area3 - areaOrig) < Vec3.epsilon; //fijatse de cambiar pr comparacion aepsilon

        //chequear con los 3 puntos de plane si el punto pertence al vertice
        // si pertenece true, y sumo counter
        //si no false;
    }

    // Chekea Que punto del ray esta en el plano
    bool IsPointInPlane(Vec_Plane meshPlane, Vec3 originPoint, out Vec3 collisionPoint)
    {
        // Si la variable point Coliciona quiero que me devuelva donde coliciono 
        collisionPoint = Vec3.Zero;

        float denom = Vec3.Dot(meshPlane.normal, Vec3.Right * 10f);

        if (Mathf.Abs(denom) > Vec3.epsilon)
        {
            float t = Vec3.Dot((meshPlane.normal * meshPlane.distance - originPoint), meshPlane.normal) / denom;
            if (t >= Vec3.epsilon)
            {
                collisionPoint = originPoint + (Vec3.Right * 10f) * t;
                return true;
            }
        }
        return false;
    }

    void DrawMeshPlanes()
    {
        if (!showV_MeshColider)
            return;

        foreach (var plane in m_planes)
        {
            plane.DrawPlane(Color.green, Color.red);
        }
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        { return; }

        //Gizmos.color = Color.red;
        //for (int i = 0; i < colP.Count; i++)
        //{
        //    Gizmos.DrawWireSphere(colP[i],0.1f);
        //}

        foreach (var item in pointsToCheck)
        {
            Gizmos.DrawRay(item,Vec3.Right * 10f);
        }
    }
}

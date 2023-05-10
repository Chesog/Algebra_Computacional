using CustomMath;
using System;
using System.Collections.Generic;
using UnityEngine;
using Color = UnityEngine.Color;



public class Vec_MeshColider : MonoBehaviour
{

    public struct MeshPlanes
    {
        public Vec_Plane plane;

        // Vertices para los planos de la mesh
        public Vec3 va;
        public Vec3 vb;
        public Vec3 vc;


        // Contructor para el meshPlane
        public MeshPlanes(Vec_Plane plane, Vec3 va, Vec3 vb, Vec3 vc)
        {
            this.plane = plane;
            this.va = va;
            this.vb = vb;
            this.vc = vc;
        }
    }

    public bool showV_MeshColider;
    public List<MeshPlanes> Planes;
    public List<Vec3> p_Inside_Mesh;
    public List<Vec3> pointsToCheck;
    public MeshFilter objMesh;


    public List<Vec3> colP;

    // Start is called before the first frame update
    void Start()
    {
        objMesh = GetComponent<MeshFilter>();
        p_Inside_Mesh = new List<Vec3>();
        pointsToCheck = new List<Vec3>();
        colP = new List<Vec3>();
        Planes = new List<MeshPlanes>();
    }

    // Update is called once per frame
    void Update()
    {
        Planes.Clear();

        // i += 3 Por que Recorremos los puntos de 3 en 3 Para conseguir los vertices de la mesh

        for (int i = 0; i < objMesh.mesh.GetIndices(0).Length; i += 3)
        {
            Vec3 aux1 = new Vec3(transform.TransformPoint(objMesh.mesh.vertices[objMesh.mesh.GetIndices(0)[i]]));
            Vec3 aux2 = new Vec3(transform.TransformPoint(objMesh.mesh.vertices[objMesh.mesh.GetIndices(0)[i + 1]]));
            Vec3 aux3 = new Vec3(transform.TransformPoint(objMesh.mesh.vertices[objMesh.mesh.GetIndices(0)[i + 2]]));

            Vec_Plane auxP = new Vec_Plane(aux1, aux2, aux3);
            auxP.normal *= -1;
            //auxP.Flip();
            Planes.Add(new MeshPlanes(auxP, aux1, aux2, aux3));
        }



        //// Por las dudas
        //foreach (var item in Planes)
        //{
        //    item.plane.Flip();
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
            
            foreach (var plane in Planes)
            {
                if (IsPointInPlane(plane, point, out var collisionPoint))
                {
                    if (IsValidPlane(plane, collisionPoint))
                    {
                        colP.Add(collisionPoint);
                        counter++;
                    }
                }
            }
            //Debug.Log("Counter " + counter);
            if (counter % 2 == 1)
            {
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
    private bool IsValidPlane(MeshPlanes mesh_P, Vec3 collisionPoint)
    {
        float x1 = mesh_P.va.x;
        float x2 = mesh_P.vb.x;
        float x3 = mesh_P.vc.x;

        float y1 = mesh_P.va.y;
        float y2 = mesh_P.vb.y;
        float y3 = mesh_P.vc.y;

        float px = collisionPoint.x;
        float py = collisionPoint.y;

        // get the area of the triangle
        float areaOrig = Math.Abs((x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1));

        // get the area of 3 triangles made between the point
        // and the corners of the triangle
        float area1 = Math.Abs((x1 - px) * (y2 - py) - (x2 - px) * (y1 - py));
        float area2 = Math.Abs((x2 - px) * (y3 - py) - (x3 - px) * (y2 - py));
        float area3 = Math.Abs((x3 - px) * (y1 - py) - (x1 - px) * (y3 - py));

        // if the sum of the three areas equals the original,
        // we're inside the triangle!
        return Math.Abs(area1 + area2 + area3 - areaOrig) < Vec3.epsilon;
    }

    bool IsPointInPlane(MeshPlanes meshPlane, Vec3 originPoint, out Vec3 collisionPoint)
    {
        // Si la variable point Coliciona quiero que me devuelva donde coliciono 

        Vec_Plane plane = meshPlane.plane;

        collisionPoint = Vec3.Zero;

        float denom = Vector3.Dot(plane.normal, Vec3.Down * 10);
        if (Mathf.Abs(denom) > Vec3.epsilon)
        {
            float t = Vector3.Dot((plane.normal * plane.distance - originPoint), plane.normal) / denom;
            if (t >= Vec3.epsilon)
            {
                collisionPoint = originPoint + Vec3.Down * 10 * t;
                return true;
            }
        }
        return false;
    }

    void DrawMeshPlanes()
    {
        if (!showV_MeshColider)
            return;

        foreach (var plane in Planes)
        {
            plane.plane.DrawPlane(Color.green, Color.red);
        }
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        { return; }
        Gizmos.color = Color.red;
        for (int i = 0; i < colP.Count; i++)
        {
            Gizmos.DrawSphere(colP[i],0.1f);
        }
    }
}

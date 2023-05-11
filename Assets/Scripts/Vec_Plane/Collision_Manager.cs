using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Collision_Manager : MonoBehaviour
{
    public List<Vec_MeshColider> objs_Mesh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in objs_Mesh[0].p_Inside_Mesh)
        {
            if (objs_Mesh[1].IsPointColliding(item))
            {
                Debug.Log("Colliding");
            }
        }
    }
}

//float x1 = mesh_P.va.x;
//float x2 = mesh_P.vb.x;
//float x3 = mesh_P.vc.x;
//
//float y1 = mesh_P.va.y;
//float y2 = mesh_P.vb.y;
//float y3 = mesh_P.vc.y;
//
//float px = collisionPoint.x;
//float py = collisionPoint.y;
//
//// get the area of the triangle
//float areaOrig = Math.Abs((x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1));
//
//// get the area of 3 triangles made between the point
//// and the corners of the triangle
//float area1 = Math.Abs((x1 - px) * (y2 - py) - (x2 - px) * (y1 - py));
//float area2 = Math.Abs((x2 - px) * (y3 - py) - (x3 - px) * (y2 - py));
//float area3 = Math.Abs((x3 - px) * (y1 - py) - (x1 - px) * (y3 - py));
//
//// if the sum of the three areas equals the original,
//// we're inside the triangle!
////if (area1 + area2 + area3 == areaOrig)
////{
////    return true;
////}
////return false;
//return Math.Abs(area1 + area2 + area3 - areaOrig) < Vec3.epsilon;

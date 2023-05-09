using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;

public class Vec_MeshColider : MonoBehaviour
{

    public struct MeshPlanes
    {
        public Vec_Plane vec_Plane;

        // Vertices para los planos de la mesh
        public Vec3 va;
        public Vec3 vb;
        public Vec3 vc;


        // Contructor para el meshPlane
        public MeshPlanes(Vec_Plane plane, Vec3 va, Vec3 vb, Vec3 vc)
        {
            this.vec_Plane = plane;
            this.va = va;
            this.vb = vb;
            this.vc = vc;
        }
    }

    public bool showV_MeshColider;
    public List<MeshPlanes> vec_Planes;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

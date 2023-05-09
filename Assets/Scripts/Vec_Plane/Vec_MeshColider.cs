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
    public MeshFilter objMesh;


    // Start is called before the first frame update
    void Start()
    {
        objMesh = GetComponent<MeshFilter>();

    }

    // Update is called once per frame
    void Update()
    {
        // i += 3 Por que Recorremos los puntos de 3 en 3 Para conseguir los vertices de la mesh

        for (int i = 0; i < objMesh.mesh.GetIndices(0).Length; i += 3)
        {
            Vec3 aux1 = new Vec3 (objMesh.mesh.vertices[objMesh.mesh.GetIndices(0)[i]]);
            Vec3 aux2 = new Vec3(objMesh.mesh.vertices[objMesh.mesh.GetIndices(0)[i + 1]]);
            Vec3 aux3 = new Vec3 (objMesh.mesh.vertices[objMesh.mesh.GetIndices(0)[i + 2]]);

            Vec_Plane auxP = new Vec_Plane(aux1, aux2, aux3);
            vec_Planes.Add(new MeshPlanes(auxP,aux1,aux2,aux3));
        }
    }
}

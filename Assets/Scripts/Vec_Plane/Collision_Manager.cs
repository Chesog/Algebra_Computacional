using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

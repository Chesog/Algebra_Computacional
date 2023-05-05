using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
using MathDebbuger;

public class Vec_3_Ej : MonoBehaviour
{
    [SerializeField] private int ejToShow = 1;
    [SerializeField] private Vec3 First_Vec;
    [SerializeField] private Vec3 Second_Vec;
    private Vector3 Res_Vec;
    private float lerp = 0;

    private void Start()
    {

        Vector3Debugger.AddVector(First_Vec, Color.red, "First_Vec");
        Vector3Debugger.EnableEditorView("First_Vec");
        Vector3Debugger.AddVector(Second_Vec, Color.blue, "Second_Vec");
        Vector3Debugger.EnableEditorView("Second_Vec");
        Vector3Debugger.AddVector(Res_Vec, Color.green, "Res_Vec");
        Vector3Debugger.EnableEditorView("Res_Vec");
    }

    enum Ejercicios
    {
        Suma = 1,
        Resta,
        Mult,
        Cross,
        Lerp,
    }

    // Update is called once per frame
    void Update()
    {
        Vector3Debugger.UpdatePosition("First_Vec",First_Vec);
        Vector3Debugger.UpdatePosition("Second_Vec", Second_Vec);
        Vector3Debugger.UpdatePosition("Res_Vec", Res_Vec);

        switch (ejToShow)
        {
            case (int)Ejercicios.Suma:
                Ej1();
                break;
            case (int)Ejercicios.Resta:
                Ej2();
                break;
            case (int)Ejercicios.Mult:
                Ej3();
                break;
            case (int)Ejercicios.Cross:
                Ej4();
                break;
            case (int)Ejercicios.Lerp:
                Ej5();
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            default:
                break;
        }
    }

    private void Ej1()
    {
        Res_Vec = First_Vec + Second_Vec;
    }

    private void Ej2() 
    {
        Res_Vec = First_Vec - Second_Vec;
    }
    
    private void Ej3() 
    {
        Res_Vec.x = First_Vec.x * Second_Vec.x;
        Res_Vec.y = First_Vec.y * Second_Vec.y;
        Res_Vec.z = First_Vec.z * Second_Vec.z;
    }

    private void Ej4() 
    {
        Res_Vec = Vec3.Cross(Second_Vec,First_Vec);
    }

    private void Ej5() 
    {
        lerp += Time.deltaTime;

        Res_Vec = Vec3.Lerp(First_Vec, Second_Vec, lerp);

        if (lerp >= 1)
        {
            lerp = 0;
        }
    }
}

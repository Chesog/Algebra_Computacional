using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
using MathDebbuger;

public class Vec_3_Ej : MonoBehaviour
{
    [SerializeField] public Vector3 First_Vec;
    [SerializeField] public Vector3 Second_Vec;
    private Vector3 Res_Vec;
    [SerializeField] private int ejToShow = 1;

    private void Start()
    {

        Vector3Debugger.AddVector(First_Vec, Color.red, "First_Vec");
        Vector3Debugger.EnableEditorView("First_Vec");
        Vector3Debugger.AddVector(Second_Vec, Color.blue, "Second_Vec");
        Vector3Debugger.EnableEditorView("Second_Vec");
        Vector3Debugger.AddVector(Res_Vec, Color.green, "Res_Vec");
        Vector3Debugger.EnableEditorView("Res_Vec");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3Debugger.UpdatePosition("First_Vec",First_Vec);
        Vector3Debugger.UpdatePosition("Second_Vec", Second_Vec);
        Vector3Debugger.UpdatePosition("Res_Vec", Res_Vec);

        switch (ejToShow)
        {
            case 1:
                Ej1();
                break;
            case 2:
                Ej2();
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
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
}

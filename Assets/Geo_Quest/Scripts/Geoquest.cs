using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geoquest : MonoBehaviour
{
    int variable1 = 67;
    string Globalv = "hello ";
    int Var2 = 67;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello world");
        string Globalv2 = "world";
        Debug.Log(Globalv + Globalv2);
    }

    // Update is called once per frame
    // Function for variable 2
    void Update()
    {
        int variable2 = variable1 + 67;
        print(variable2);
        print(variable1 + variable2);
        Debug.Log(Var2++);
     
    }
}


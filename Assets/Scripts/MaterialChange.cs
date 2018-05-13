using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour {

    // put the first material here.
    public Material material1;
    // put the second material here.
    public Material material2;

    bool FirstMaterial = true;
    bool SecondndMaterial = false;

    void Start()
    {
      GetComponent<Renderer>().material = material1;
    }

    void OnMouseDown()
    {
        if (FirstMaterial)
        {
            GetComponent<Renderer>().material = material2;
            SecondndMaterial = true;
            FirstMaterial = false;
        }
        else if (SecondndMaterial)
        {
            GetComponent<Renderer>().material = material1;
            FirstMaterial = true;
            SecondndMaterial = false;
        }
    }
}

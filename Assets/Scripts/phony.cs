using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class phony : MonoBehaviour
{

  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeText() {

        

    }

    public void buttonPress() {
        print("pressed button to compile");
        GameObject.Find("Cube (3)").GetComponent<Compile>().CompileCode();
    }
} 


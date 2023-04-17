using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionPoints 
{

    private ArrayList points = new ArrayList(); 

    public ConnectionPoints(string tag)
        //, for, while, print, if, else, start, end, end loop, 
    {
        switch(tag){
            case "start":
            points.Add("Bottom");
            break;
            case "end":
            points.Add("Top");
            break;
            case "while":
            points.Add("Top");
            points.Add("Bottom");
            points.Add("Right");
             break;
            case "for":
            points.Add("Top");
            points.Add("Bottom");
            points.Add("Right");
            break;
            case "if":
            points.Add("Top");
            points.Add("Bottom");
            points.Add("Right");
            break;
            case "endLoop":
            points.Add("Top");
            points.Add("Bottom");
            break;
            case "conditional":
            points.Add("Left");
            break;
            case "print":
            points.Add("Top");
            points.Add("Bottom");
            points.Add("Right");
            break;
            case "var":
            points.Add("Top");
            points.Add("Bottom");
            points.Add("Right");
            points.Add("Left");
            break;
            case "value":
            points.Add("Left");
            break;
            case "operator":
            points.Add("Left");
            points.Add("Right");
            break;

        }

       
    }
    public ArrayList getPoints() { return points; }
    // Start is called before the first frame update
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// "<color=#ede485>"
public class TextGenerator : MonoBehaviour {
    [SerializeField] public GameObject database;
    public string NewLine() {
        return "\n";
    }

    public string CloseFunc() {
        return "<color=yellow>}</color>";
    }
    
    public string InitalizeClass() {
        return
            "<color=#008080ff>using</color>" +
            " " +
            "System" +
            "\n" +
            "<color=#008080ff>using</color>" +
            " " +
            "UnityEngine" +
            "\n" +

            "[" +
            "<color=green>SerializeField</color>" +
            "]" +
            " " +
            "<color=#008080ff>public</color>" +
            " " +
            "<color=green>GameObject</color>" +
            " " +
            "cube;" +

            "<color=#008080ff>public</color>" +
            " " +
            "<color=#008080ff>class</color>" +
            " " +
            "<color=green>Program</color>" + 
            " " +
            "{";
    }
    public string InitalizeMain() {
        return
            "<color=#008080ff>static</color>" +
            " " +
            "<color=#008080ff>void</color>" +
            " " +
            "<color=#ede485>Main</color> + " +
            "(" +
            "<color=#008080ff>string</color>" +
            "[]" +
            " " +
            "<color=lightblue>args</color>" +
            ")" +
            " " +
            "{";
    }

    public string DeclareString(string name, string str) {

        return
            "<color=#008080ff>string</color>" +
            " " +
            "<color=lightblue>" + name + "</color>" +
            " " +
            "<color=white>=</color>" +
            " " +
            "<color=#4858b0>\"" + str + "\"</color>";
    }

    public string DeclareInt(string type, string name, int value) {

        return
            "<color=#008080ff>int</color>" +
            " " +
            "<color=lightblue>" + name + "</color>" +
            " " +
            "<color=white>=</color>" +
            " " +
            "<color=#41a839>" + value + "</color>";
    }

    //"<color=></color>"
    //for(int var = i, var sign value, increment);
    //for(int i = 0; i < 10; i = i + 1) {
    public string AddForLoop(int iVal, string sign, int value, int increment) {
        return
            "<color=purple>for</color>" +
            "<color=yellow>(</color>" +
            "<color=#008080ff>int</color>" +
            " " +
            "<color=lightblue>i</color>" +
            " " +
            "<color=white>=</color>" +
            " " +
            "<color=#41a839>" + iVal + "</color>" +
            "<color=white>;</color>" +
            " " +
            "<color=lightblue>i</color>" +
            " " +
            "<color=white>" + sign + "</color>" +
            " " +
            "<color=#41a839>" + value + "</color>" +
            "<color=white>;</color>" +
            " " +
            "<color=lightblue>i</color>" +
            " " +
            "<color=white>=</color>" +
            " " +
            "<color=lightblue>i</color>" +
            " " +
            "<color=white>+</color>" +
            " " +
            "<color=#41a839>" + increment + "</color>" +
            "<color=yellow>)</color>" +
            " " +
            "<color=yellow>{</color>";
    }

    public string AddWhileLoop(String val1, String sign, String val2) {

        return
            "<color=purple>while</color>" +
            "<color=yellow>(</color>" +
            "<color=lightblue>" + val1 + "</color>" +
            " " +
            "<color=white>" + sign + "</color>" +
            " " +
            "<color=#41a839>" + val2 + "</color>" +
            "<color=yellow>)</color>" +
            " " +
            "<color=yellow>{</color>";
    }

    public string MathExpression(string expression) {
        string returnStr = "";

        string[] elements = expression.Split(' ');
        foreach (string element in elements) {
            int number;
            bool isNumber = int.TryParse(element, out number);
            if (isNumber) {
                returnStr += "<color=#41a839>" + element + "</color>";
            } else if (element == "+" || element == "-" || element == "*" || element == "/" || element == "=") {
                returnStr += "<color=white>" + element + "</color>";
            } else if (Char.IsLetter(element[0])) {
                returnStr += "<color=lightblue>" + element + "</color>";
            } else {
                Console.WriteLine("Error in MathExpression, invalid character");
            }
        }

        return returnStr;
    }

    internal string ColorBlock(Color color) {
        return
            "cube.GetComponent<" +
            "<color=green>Renderer</color>" +
            ">().material.color = " +
            "<color=lightblue>" + color.ToString() + "</color>;";
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem.Controls;
using System.Text;
using System;

public class Compile : MonoBehaviour
{
    public List<int> compile = new List<int>();
    public TMPro.TextMeshPro toPrint;
    public List<Block> blocks = new List<Block>();
    StringBuilder sb = new StringBuilder();
    Dictionary<string, string> variables = new Dictionary<string, string>();
    // Start is called before the first frame update
    void Start()
    {
        toPrint.text = "";
        compile.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)) {
            CompileCode();
            
        }
    }

    public void CompileCode() {
        print("compiling...");
        GameObject [] blockCount = GameObject.FindGameObjectsWithTag("Block");
        
        foreach(GameObject block in blockCount) {
            blocks.Add(block.gameObject.transform.parent.gameObject.GetComponent<Block>());
        }





        foreach (Block block in blocks) {
            if(block.uniqueID == 0) {
                compile.Add(0);
                getConnectedBlockID(block);
            }
        }
       

       
        for(int i = 0; i < compile.Count; i++) {
            print(compile[i]);
            //getConnectedBlockID(blocks[i]);
        }
        ExecuteCompile(compile);

    }     



    public void getConnectedBlockID (Block block){
      
       

         foreach (Pin pin in block.pins) {
            if (pin.isConnected && pin.name != "Bottom") {
                if (compile.Contains(pin.connectedBlock.GetComponent<Block>().uniqueID)) {
                    continue;
                }

                if (block.uniqueID == -1) {
                    compile.Add(-1);
                    return;
                }
                compile.Add(pin.connectedBlock.GetComponent<Block>().uniqueID);
                getConnectedBlockID(pin.connectedBlock.GetComponent<Block>());
                print("adding pin " + pin.connectedBlock.GetComponent<Block>().uniqueID);


            } 
        }
        foreach (Pin pin in block.pins) {
            if (pin.isConnected && pin.name == "Bottom") {
                if (compile.Contains(pin.connectedBlock.GetComponent<Block>().uniqueID)) {
                    continue;
                }

                if (block.uniqueID == -1) {
                    compile.Add(-1);
                    return;
                }
                compile.Add(pin.connectedBlock.GetComponent<Block>().uniqueID);
                getConnectedBlockID(pin.connectedBlock.GetComponent<Block>());
                print("adding pin " + pin.connectedBlock.GetComponent<Block>().uniqueID);


            }
        }


        /* if (block.uniqueID == -1) {
             compile.Add(-1);
             return;
         }*/


    }
    public void ExecuteCompile(List<int> compile) {

        for (int i = 0; i < compile.Count; i++) {
           
            Block block = getBlockFromUniqueID(int.Parse(compile[i].ToString()));
            executeFunctionOfBlock(block);
            
        }

        toPrint.text = sb.ToString();
    }


    private string executeFunctionOfBlock(Block block) {
        //Tags: conditional, variable, for, if, start, end, etc
        switch(block.tag) {
            case "start": //nothing needs to happen here
            break;
            case "end": 
            break;
            case "print": printVar(block);
            break;
            case "var": if(block.gameObject.GetComponent<Variable>())
                    initializeVar(block);
            break;
           
            
        }
        return "";
    }

    private void initializeVar(Block block) {
      
        Variable var = block.gameObject.GetComponent<Variable>();
        var.VarName = block.gameObject.GetComponentInChildren<TextMeshPro>().text;
        int position = compile.IndexOf(block.uniqueID);
        print("position" + position);
        print(compile.ToString());
        if (getBlockFromUniqueID(compile[position + 1]).tag == "operator" && getBlockFromUniqueID(compile[position + 2]).tag == "value") {
            getBlockFromUniqueID(compile[position + 2]).gameObject.GetComponent<Value>().Val = getBlockFromUniqueID(compile[position + 2]).gameObject.GetComponentInChildren<TextMeshPro>().text;
            var.Value = getBlockFromUniqueID(compile[position + 2]).gameObject.GetComponent<Value>().Val;
            variables.Add(var.VarName, var.Value);
        }
    }

    private void checkVar(Block block) {

        Variable var = block.gameObject.GetComponent<Variable>();
        var.VarName = block.gameObject.GetComponentInChildren<TextMeshPro>().text;
        int position = compile.IndexOf(block.uniqueID);
        print("position" + position);
        print(compile.ToString());
        if(variables.ContainsKey(var.VarName)) {
            if (getBlockFromUniqueID(compile[position + 1]).tag == "operator" && getBlockFromUniqueID(compile[position + 2]).tag == "value") {
                setValueOfVar(var.VarName, getBlockFromUniqueID(compile[position + 2]).gameObject.GetComponent<Value>().Val);
            }
        }
    }
    private void setValueOfVar(string varName, string value) {
        variables[varName] = varName;
        variables[value] = value ;

    }

    private void printFunction(string text) {
        sb.Append(text);
        sb.Append("\n");
    }
    private void printVar(Block block) {

        int position = compile.IndexOf(block.uniqueID);
        print("position" + position);
        print(compile.ToString());
        if (getBlockFromUniqueID(compile[position + 1]).tag == "var") {
            sb.Append(getBlockFromUniqueID(compile[position + 1]).gameObject.GetComponent<Variable>().Value);
            
        }

    }

    private Block getBlockFromUniqueID(int uniqueID) {
        foreach (Block block in blocks) {

            if (block.uniqueID == uniqueID) return block;
        }

        return null;
    }
}

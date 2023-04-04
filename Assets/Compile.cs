using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Compile : MonoBehaviour
{
    public ArrayList compile = new ArrayList();
    

    // Start is called before the first frame update
    void Start()
    {
        
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
        List<Block> blocks = new List<Block>();
        foreach(GameObject block in blockCount) {
            blocks.Add(block.gameObject.transform.parent.gameObject.GetComponent<Block>());
        }
        
        getConnectedBlockID(blocks[0]);
       

        for(int i = 0; i < compile.Count; i++) {
            print(compile[i]);
        }

    }     



    public void getConnectedBlockID (Block block){

        
        foreach (Pin pin in block.pins) {
            if (compile.Contains(pin.connectedBlock.GetComponent<Block>().uniqueID)) { return; }
            if (pin.isConnected) {
                
                if(block != pin.connectedBlock.GetComponent<Block>()  ) {
                    print(block.uniqueID + " connected to " + pin.connectedBlock.GetComponent<Block>().uniqueID);
                    getConnectedBlockID(pin.connectedBlock.GetComponent<Block>());
                    compile.Add(block.uniqueID);


                }

            }
        }


    }
}

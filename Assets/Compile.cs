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
        List<Block> blocks = new List<Block>();
        foreach(GameObject block in blockCount) {
            blocks.Add(block.gameObject.transform.parent.gameObject.GetComponent<Block>());
        }





        compile.Add(0);
        foreach (Block block in blocks) {
            if(block.uniqueID == 0) {
                getConnectedBlockID(block);
            }
        }
       

       
        for(int i = 0; i < compile.Count; i++) {
            print(compile[i]);
            //getConnectedBlockID(blocks[i]);
        }

    }     



    public void getConnectedBlockID (Block block){
      
       

         foreach (Pin pin in block.pins) {
             if (pin.isConnected) {
                if (compile.Contains(pin.connectedBlock.GetComponent<Block>().uniqueID)) {
                    continue;
                }

                if (block.uniqueID == -1) {
                 
                }
                compile.Add(pin.connectedBlock.GetComponent<Block>().uniqueID);
                    getConnectedBlockID(pin.connectedBlock.GetComponent<Block>());
                    print("adding pin " + pin.connectedBlock.GetComponent<Block>().uniqueID);

                }
            }


        if (block.uniqueID == -1) {
            compile.Add(-1);
            return;
        }


    }
}

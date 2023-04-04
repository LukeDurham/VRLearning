using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField]
    public bool isConnected;
    [SerializeField]
    public string pinType; //Male & Female
    [SerializeField]
    public GameObject pinGO;
    public bool canSnap = false;
    public GameObject otherBlockCollision;
    public GameObject connectedBlock;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsConnected() {
        return isConnected;
    }
   
   
    private void OnTriggerEnter(Collider otherCube) {
        if (otherCube.gameObject.name != "ThrowableCube" || otherCube.gameObject == this.gameObject.transform.parent.gameObject) { return; }
        Block otherBlockScript = otherCube.gameObject.GetComponent<Block>();
        foreach (Pin otherPin in otherBlockScript.pins) {
            if ( this.pinType != otherPin.pinType && this.gameObject.name != otherPin.gameObject.name) {
                canSnap = true;
                otherBlockCollision = otherCube.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider otherCube) {
        if (otherCube.gameObject.name == "ThrowableCube") {
            Block thisPinsBlock = this.gameObject.GetComponentInParent<Block>();
            canSnap = false;
            otherBlockCollision = null;
           
        }

    }

    public void setPinType(string type) {
        pinType = type;
    }
    public void setPinGO(GameObject go) {
        pinGO = go;
    }

    public void setConnectedBlock(GameObject block) {
        connectedBlock = block;
        isConnected = true;
        canSnap = false;
        

       
    }




}

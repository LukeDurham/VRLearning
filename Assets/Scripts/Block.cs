using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Block : MonoBehaviour {
    [SerializeField]
    public ArrayList connections;
    public ConnectionPoints connectionPoints;
    [SerializeField]
    public ArrayList pins = new ArrayList();
    public int uniqueID;
    public string blockTag;
    private Rigidbody rigidBody;
    public bool isGrabbed;
    GameObject thisCube;


    // Start is called before the first frame update
    void Start() {
        if (this.gameObject.name != "ThrowableCube") {
            this.gameObject.name = "ThrowableCube";
        }
        rigidBody = gameObject.GetComponent<Rigidbody>();
        connectionPoints = new ConnectionPoints(this.gameObject.tag);
        connections = connectionPoints.getPoints();
        blockTag = this.gameObject.tag;
        //float cubeSizeX = this.gameObject.transform.localScale.x;
        float cubeSizeY = this.gameObject.transform.localScale.y;
        float cubeSizeZ = this.gameObject.transform.localScale.z;
        float positionX = this.gameObject.transform.position.x;
        float positionY = this.gameObject.transform.position.y;
        float positionZ = this.gameObject.transform.position.z;

        foreach (var value in connections) {
            switch (value) {
                case "Top":
                GameObject pinT = Instantiate(GameObject.Find("ClonePin"), new Vector3(positionX, positionY + cubeSizeY / 2 / 10, positionZ), this.gameObject.transform.rotation, this.gameObject.transform);
                pinT.gameObject.name = "Top";
                GameObject pinObjectT = Instantiate(GameObject.Find("PinGameObject"), pinT.transform.position, pinT.transform.rotation, this.gameObject.transform);
                Pin topPin = pinT.AddComponent<Pin>();
                topPin.setPinType("Male");
                topPin.setPinGO(pinT);

                pins.Add(topPin);

                break;

                case "Bottom":
                GameObject pinB = Instantiate(GameObject.Find("ClonePin"), new Vector3(positionX, positionY - cubeSizeY / 2 / 10, positionZ), this.gameObject.transform.rotation, this.gameObject.transform);
                pinB.gameObject.name = "Bottom";
                GameObject pinObjectB = Instantiate(GameObject.Find("PinGameObject"), pinB.transform.position, pinB.transform.rotation, this.gameObject.transform);

                Pin bottomPin = pinB.AddComponent<Pin>();
                bottomPin.setPinType("Female");
                bottomPin.setPinGO(pinB);
                pins.Add(bottomPin);

                break;
                case "Right":
                GameObject pinR = Instantiate(GameObject.Find("ClonePin"), new Vector3(positionX, positionY, positionZ + cubeSizeZ / 2 / 10), this.gameObject.transform.rotation, this.gameObject.transform);
                pinR.gameObject.name = "Right";
                GameObject pinObjectR = Instantiate(GameObject.Find("PinGameObject"), pinR.transform.position, pinR.transform.rotation, this.gameObject.transform);

                Pin rightPin = pinR.AddComponent<Pin>();
                rightPin.setPinType("Female");
                rightPin.setPinGO(pinR);
                pins.Add(rightPin);

                break;

                case "Left":
                GameObject pinL = Instantiate(GameObject.Find("ClonePin"), new Vector3(positionX, positionY, positionZ - cubeSizeZ / 2 / 10), this.gameObject.transform.rotation, this.gameObject.transform);
                pinL.gameObject.name = "Left";
                GameObject pinObjectL = Instantiate(GameObject.Find("PinGameObject"), pinL.transform.position, pinL.transform.rotation, this.gameObject.transform);

                Pin leftPin = pinL.AddComponent<Pin>();
                leftPin.setPinType("Male");
                leftPin.setPinGO(pinL);
                pins.Add(leftPin);

                break;


            }
        }

    }

    // Update is called once per frame
    void Update() {

    }


    public void Grab() {

        rigidBody.isKinematic = false;
        isGrabbed = true;
        this.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);


    }
    public void Release() {

        rigidBody.isKinematic = true;
        gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        isGrabbed = false;
        foreach (Pin pin in pins) {
            print("Release");
            if (pin.canSnap) {
                Snap(pin);
                pin.canSnap = false;
            }
        }

    }

    private void Snap(Pin pin) {
        print("Snapping");
        GameObject otherCube = pin.otherBlockCollision;
        float otherCubeX = otherCube.transform.position.x;
        float otherCubeY = otherCube.transform.position.y;
        float otherCubeZ = otherCube.transform.position.z;
        float otherCubeScaleY = otherCube.transform.localScale.y / 10;
        float otherCubeScaleZ = otherCube.transform.localScale.z / 10;

        Vector3 newPosition = this.gameObject.transform.position;
        print(pin.gameObject.name);

        switch (pin.gameObject.name) {

            case "Bottom":
            newPosition = new Vector3(otherCubeX, 0.12f, otherCubeZ);
            this.gameObject.transform.position = newPosition;

            break;
            case "Top":
            newPosition = new Vector3(otherCubeX, otherCubeY - otherCubeScaleY, otherCubeZ);
            this.gameObject.transform.position = newPosition;


            break;
            case "Right":
            newPosition = new Vector3(otherCubeX, otherCubeY, otherCubeZ - otherCubeScaleZ);
            this.gameObject.transform.position = newPosition;

            print("TOP INSIDE SWITCH");
            break;
            case "Left":
            newPosition = new Vector3(otherCubeX, otherCubeY, otherCubeZ + otherCubeScaleZ);
            this.gameObject.transform.position = newPosition;

            print("TOP INSIDE SWITCH");
            break;
        }
        Block otherCubeBlock = otherCube.GetComponent<Block>();
        foreach (Pin otherPin in otherCubeBlock.pins) {
            if (otherPin.canSnap) {
                otherPin.isConnected = true;
                otherPin.canSnap = false;
                otherPin.setConnectedBlock(this.gameObject);
                
            }



            print("Snapping");
        }
        foreach (Pin thispin in this.pins) {
            if (thispin.canSnap) {
                thispin.isConnected = true;
                thispin.canSnap = false;
                thispin.setConnectedBlock(otherCube);

            }
            print("Snapping");
        }



        }
}

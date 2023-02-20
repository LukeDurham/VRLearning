using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBlocks : MonoBehaviour {
    [SerializeField]
    Rigidbody RB;
    [SerializeField]
    BoxCollider BC;
    private bool allowSnap;
    private Transform collisionTransform;
    // Start is called before the first frame update
    void Start()
    {
        RB = this.GetComponent<Rigidbody>();
        BC = this.GetComponentInChildren<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Release() {
        RB.isKinematic = true;
        if (allowSnap) {
            Snap();
        }
    }

    private void Snap() {
        print("snap");
        this.transform.position = new Vector3(collisionTransform.position.x, collisionTransform.position.y - 0.1f, collisionTransform.position.z);
    }

    public void Grab() {
        RB.isKinematic = false;
        


    }
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Block") {
            print("Enter");
            collisionTransform = collision.transform;
            allowSnap = true;
        }
    }
    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.tag == "Block") {
            print("Exit");
            collisionTransform = null;
            allowSnap = false;
        }
    }
  
}

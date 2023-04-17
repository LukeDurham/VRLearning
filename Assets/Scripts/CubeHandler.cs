using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour {

    public GameObject cube;


    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.U)) {
            ChangeScale(2);
        }

        if (Input.GetKeyDown(KeyCode.I)) {
           // ChangeColor(Color.blue);
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            RotateCube(10);
        }
        
    }

    public void ChangeScale(float addScale) {
        float currentSize = cube.transform.lossyScale.x;
        float finalSize = currentSize + addScale;
        cube.transform.localScale = new Vector3(finalSize, finalSize, finalSize);
    }

    public void ChangeColor(Color newColor) {
        GetComponent<Renderer>().material.color = newColor;
    }

    //Removed move functionality as it was not needed for the project
    /*
    public void MoveToPosition(Vector3 newPosition, float speed) {
        StartCoroutine(SlowMover(newPosition, speed));
    }

    private IEnumerator SlowMover(Vector3 newPosition, float speed) {
        while (transform.position != newPosition) {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
    */

    public void RotateCube(int rotationAmount) {
        transform.Rotate(new Vector3(0, rotationAmount, 0));
    }

}

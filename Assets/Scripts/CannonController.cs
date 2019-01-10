using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    //public variables -- set in the inspector
    public int minRot = -50; //the min degree range it can be rotated
    public int maxRot = 50; //the max degree range it can be rotated
    public float minX; //far left point that cannon can be moved to
    public float maxX; //far right point that cannon can be moved to

    //private variables
    private bool drag; //is the mouse dragging the cannon

    // Start is called before the first frame update
    void Start() {
      //rotate the cannon on a random z
      transform.Rotate(0, 0, Random.Range(minRot, maxRot));
      //don't drag on start
      drag = false;
    }

    // Update is called once per frame
    void Update(){
      //drag
      if (drag) {
        Debug.Log(Input.mousePosition.x); //print current mouse pos
      }
    }

    void OnMouseDown() {
      //mouse button pressed, start drag mode
      drag = true;
    }

    void OnMouseUp() {
      //mouse button released, stop drag mode
      drag = false;
    }
}

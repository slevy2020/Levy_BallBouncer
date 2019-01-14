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
    public float speed = 1.0f; //mult to keep cannon movement alligned with the mouse movement

    //private variables
    private bool drag; //is the mouse dragging the cannon
    private int oldMouseX; //store where the mouse was
    private DropButton dropScript; //pointer to the drop button

    // Start is called before the first frame update
    void Start() {
      //rotate the cannon on a random z
      transform.Rotate(0, 0, Random.Range(minRot, maxRot));
      //don't drag on start
      drag = false;
      //get control of the drop script
      dropScript = GameObject.Find("drop").GetComponent<DropButton>();
    }

    // Update is called once per frame
    void Update(){
      //drag
      if (drag) {
        Debug.Log(Input.mousePosition.x); //print current mouse pos
        //new posX = current pos x + (mouse current pos x - mouse old pos x)
        float posX = transform.position.x + ((Input.mousePosition.x - oldMouseX)*speed);
        posX = Mathf.Min (Mathf.Max (minX, posX), maxX); //keep x within the valid range
        transform.position = new Vector3(posX, transform.position.y, transform.position.z); //move the Cannon
        oldMouseX = (int)Input.mousePosition.x; //store this mouse x for the next update
      }
    }

    void OnMouseDown() {
      if (!dropScript.dropped) {
        //mouse button pressed, start drag mode
        drag = true;
        oldMouseX = (int)Input.mousePosition.x; //store this mouse x for the next update
      }
    }

    void OnMouseUp() {
      //mouse button released, stop drag mode
      drag = false;
    }
}

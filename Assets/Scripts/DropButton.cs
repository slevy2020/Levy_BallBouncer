using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DropButton : MonoBehaviour
{
    //public variables -- set in the inspector
    public GameObject ball; //pointer to the ball prefab
    public GameObject spawn; //pointer to the spawn point object
    public bool dropped; //has the ball dropped

    //private variables
    private Vector3 pos;
    private Quaternion rot;
//    private bool dropped; //has the ball dropped

    // Start is called before the first frame update
    void Start() {
      //init variables
      dropped = false; //have not yet dropped the ball
      //call DropBall() when the button is clicked
      Button drop = GetComponent<Button>();
      drop.onClick.AddListener(DropBall);
    }

    // Update is called once per frame
    void Update() {

    }

    void DropBall() {
      //on left mouse click create an instance of the ball
      if (!dropped) {
        //set up the position and orientation of the ball
        pos = spawn.transform.position; //position at spawn location
        rot = spawn.transform.rotation; //allign to the spawn
        //create an instance of the ball prefab
        Instantiate(ball, pos, rot);
        dropped = true;
      }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DropButton : MonoBehaviour
{
    //public variables -- set in the inspector
    public GameObject ball; //pointer to the ball prefab

    //private variables
    private Vector3 pos;
    private Quaternion rot;

    // Start is called before the first frame update
    void Start() {
      //init variables
      pos = new Vector3(0, 8, 0); //position close to the top wall
      rot = Quaternion.identity; //align to the world

      //call DropBall() when the button is clicked
      Button drop = GetComponent<Button>();
      drop.onClick.AddListener(DropBall);
    }

    // Update is called once per frame
    void Update() {

    }

    void DropBall() {
      //on left mouse click create an instance of the ball
      //set up the position and orientation of the ball

      //create an instance of the ball prefab
      Instantiate(ball, pos, rot);
    }
}

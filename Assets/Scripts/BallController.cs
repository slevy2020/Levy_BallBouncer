using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
      //add a force to a ball from the direction it is aimed
      GetComponent<Rigidbody>().AddForce(-transform.up*500);
    }

    // Update is called once per frame
    void Update() {

    }

    void OnCollisionEnter (Collision collision) {
      //handle collisions
      if (collision.gameObject.name == "CollisionWallBottom") {
        //hit bottom wall, lose, end the game
        SceneManager.LoadScene("end");
      }
      if (collision.gameObject.name == "GoalTop") {
        //hit the goal, win, end the game
        SceneManager.LoadScene("end");
      }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

  //public variables - set in the inspector
  public int hitScore = 10; //how many points for each piece hit
  public GameObject firework; //particle prefab

  //private variables
  private int score; //the score this ball has earned
  private Text scoreUI; //pointer to the UI Text Object
  private PersistentData persistentScript; //pointer to the persistent data

    // Start is called before the first frame update
    void Start() {
      //add a force to a ball from the direction it is aimed
      GetComponent<Rigidbody>().AddForce(-transform.up*500);
      //reset the score
      score = 0;
      //find the scoreUI object
      scoreUI = GameObject.Find("UI Text - Score").GetComponent<Text>();
      //get control of the persistent data
      persistentScript = GameObject.Find("PersistentObject").GetComponent<PersistentData>();
    }

    // Update is called once per frame
    void Update() {
      scoreUI.text = "Score: " + score.ToString();
    }

    void OnCollisionEnter (Collision collision) {
      //handle collisions
      if (collision.gameObject.name == "CollisionWallBottom") {
        //hit bottom wall, lose, end the game
        persistentScript.SetWin(false); //we lost!
        SceneManager.LoadScene("end");
      }
      if (collision.gameObject.name == "GoalTop") {
        //hit the goal, win, triple score and end the game
        score *= 3;
        persistentScript.AddScore(score); //add to the collective score
        persistentScript.SetWin(true); //We won!
        persistentScript.LevelComplete(); //another level completed
        SceneManager.LoadScene("end");
      }
      if (collision.gameObject.tag == "Obstacle") {
            //gain score
            score += hitScore;
      }
      if (collision.gameObject.name == "star") {
        //double score
        score *= 2;
        //remove the star
        Destroy(collision.gameObject);
        //create a particle System
        Instantiate(firework, transform.position, Quaternion.identity);
      }
    }
}

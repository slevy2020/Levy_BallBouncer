using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

  //public variables - set in the inspector
  public int hitScore = 10; //how many points for each piece hit
  public GameObject firework; //particle prefab
  public GameObject fireworkWin; //particle prefab if hit goal

  //private variables
  private Text scoreUI; //pointer to the UI Text Object
  private PersistentData persistentScript; //pointer to the persistent data
  private GameObject transitionScreen;
  private int score; //the score this ball has earned
  private Scene endScene;
  private Scene nextScene;
  private static System.Timers.Timer transitionTimer;

    // Start is called before the first frame update
    void Start() {
      //add a force to a ball from the direction it is aimed
      GetComponent<Rigidbody>().AddForce(-transform.up*500);
      //find the scoreUI object
      scoreUI = GameObject.Find("UI Text - Score").GetComponent<Text>();
      //get control of the persistent data
      persistentScript = GameObject.Find("PersistentObject").GetComponent<PersistentData>();
      //get control of transition screen Object
      Renderer transitionScreen = GameObject.Find("Transition").GetComponent<Renderer>();
      //get control of the end scene
      endScene = SceneManager.GetSceneByName("end");
      //get control of next Scene
      nextScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update() {
      scoreUI.text = "Score: +" + score.ToString();
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
        Instantiate(fireworkWin, transform.position, Quaternion.identity);
        TransitionTimer();
        transitionScreen.SetActive(true);
        TransitionTimer();
        score *= 3;
        persistentScript.AddScore(score); //add to the collective score
        persistentScript.LevelComplete(); //add to level counter
        if (persistentScript.win) {
          SceneManager.LoadScene(nextScene.buildIndex + 1);
        }
      }
      if (collision.gameObject.tag == "Obstacle") {
            //gain score
            score += hitScore;
      }
      if (collision.gameObject.tag == "Star") {
        //double score
        score *= 2;
        //remove the star
        Destroy(collision.gameObject);
        //create a particle System
        Instantiate(firework, transform.position, Quaternion.identity);
      }
    }

    // IEnumerator TransitionDelay() {
    //   Debug.Log("yup");
    //   yield return new WaitForSeconds(2);
    //   transitionScreen.GetComponent<Renderer>().enabled = true;
    //   yield return new WaitForSeconds(2);
    //   persistentScript.SetWin(true); //We won!
    // }
    private static void TransitionTimer() {
      transitionTimer = new System.Timers.Timer(1000);
      transitionTimer.AutoReset = false;
    }
}

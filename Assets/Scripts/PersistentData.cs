using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentData : MonoBehaviour {
    //public variables
    public bool win; //win or lose

    //private variables
    private int score; //the collective score
    private int level; //how many levels were completed
    private Scene prevScene;
    private int nextScene;

    // Start is called before the first frame update
    void Start() {
      //init vars
      Reset();
      //make this object persistent
      DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update() {

    }

    public void Reset() {
      //reset all persistent data
      score = 0;
      win = false;
      level = 0;
    }

    public void AddScore (int amount) {
      //add the provided score amount to the collective score
      score += amount;
    }

    public int GetScore () {
      //return the value of the current collective score
      return score;
    }

    public void SetWin (bool state) {
      //record the win state provided
      win = state;
    }

    public void LevelComplete () {
      //advance the number of levels completed
      level += 1;
    }

    public int GetLevel () {
      //return the number of levels completed
      return level;
    }

    public void SetLastScene () {
      prevScene = SceneManager.GetActiveScene();
      nextScene = (prevScene.buildIndex + 1);
      Debug.Log("previous scene: " + prevScene.buildIndex);
    }

    public void LoadNextScene () {
      SceneManager.LoadScene(nextScene);
      Debug.Log("next scene (persist): " + nextScene);
    }
}

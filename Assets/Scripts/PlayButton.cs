﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour {
    //public variables

    //private variables
    private PersistentData persistentScript; //pointer to the persistent data
    private BallController scoreScript; //pointer to the score on the ball controller

    // Start is called before the first frame update
    void Start()
    {
      Button start = GetComponent<Button>();
      start.onClick.AddListener(StartGame);
      //get control of the persistent data
      persistentScript = GameObject.Find("PersistentObject").GetComponent<PersistentData>();
      //get control of the ball controller
//      scoreScript = GameObject.Find("Ball").GetComponent<BallController>();
      //update the persistent score
//      scoreScript.score = persistentScript.GetScore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartGame()
    {
      //on left mouse click go to level1 Scene
      Debug.Log("starting game");
      SceneManager.LoadScene("level1");
      //reset score and level counter
      persistentScript.Reset();
    }
}

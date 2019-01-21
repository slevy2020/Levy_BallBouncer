using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
    //private variables
    private static System.Timers.Timer transitionTimer;
    private PersistentData persistentScript;

    // Start is called before the first frame update
    void Start()
    {
      //get control of the persistent data
      persistentScript = GameObject.Find("PersistentObject").GetComponent<PersistentData>();
      TransitionTimer();
      persistentScript.LoadNextScene();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private static void TransitionTimer() {
      transitionTimer = new System.Timers.Timer(3000);
      transitionTimer.AutoReset = false;
    }
}

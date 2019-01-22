using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
    //public variables
    public float transitionTimer = 2.0f;

    //private variables
    private PersistentData persistentScript;

    // Start is called before the first frame update
    void Start()
    {
      //get control of the persistent data
      persistentScript = GameObject.Find("PersistentObject").GetComponent<PersistentData>();
    }

    // Update is called once per frame
    void Update()
    {
      transitionTimer -= Time.deltaTime;
      if (transitionTimer < 0) {
        persistentScript.LoadNextScene();
      }
    }

    // private static void TransitionTimer() {
    //   transitionTimer = new System.Timers.Timer(1000);
    //   transitionTimer.AutoReset = false;
    // }

    IEnumerator TransitionTimer() {
      yield return new WaitForSeconds(3);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour {
    //public variables

    //private variables
    private PersistentData persistentScript; //pointer to the persistent data

    // Start is called before the first frame update
    void Start() {
      //get control of the persistent data
      persistentScript = GameObject.Find("PersistentObject").GetComponent<PersistentData>();
      //get the current score
      gameObject.GetComponent<Text>().text = "Score: " + persistentScript.GetScore().ToString();
    }

    // Update is called once per frame
    void Update() {

    }
}

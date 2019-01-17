using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Update is called once per frame
    void Update() {
      //rotate the object every game cycle
      transform.Rotate(0, 0, 3); //in degrees
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
      Button quit = GetComponent<Button>();
      quit.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update() {

    }

    void QuitGame () {
      Debug.Log("Goodbye");
      Application.Quit();
    }
}

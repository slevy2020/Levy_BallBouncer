using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      Button start = GetComponent<Button>();
      start.onClick.AddListener(StartGame);
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
    }
}

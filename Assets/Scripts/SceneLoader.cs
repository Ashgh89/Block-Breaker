using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // Our current scene
        SceneManager.LoadScene(currentSceneIndex + 1); // Load next scene
    }
    public void LoadStartScene()
    {

        // from scene 2 to 0 or from Win Screen to Start Game
        SceneManager.LoadScene(0);
        FindObjectOfType<GameController>().ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit(); // just for editor
    }
}

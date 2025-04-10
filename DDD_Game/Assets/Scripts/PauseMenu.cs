using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            unPause();
        }
    }

    public void unPause()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("PauseMenu");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void quitGame()
    {
        Application.Quit();
    }
}

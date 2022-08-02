using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSceneController : MonoBehaviour
{
    [Header("UI Panel References")]
    public GameObject pauseMenuUI;
    public GameObject hud;

    public static bool Paused = false;

    private void Awake()
    {
        Time.timeScale = 1f;
        Paused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Restarted");

            Scene _sceneToReload = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(_sceneToReload.name);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("escape hit");

            if (Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        hud.gameObject.SetActive(false);

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        hud.gameObject.SetActive(true);
    }

    public void LoadScene(string _sceneToLoad)
    {
        SceneManager.LoadScene(_sceneToLoad);
    }

    public void ReloadScene(string _sceneToReload)
    {
        SceneManager.LoadScene(_sceneToReload);
    }

    public void ExitLevel(string _menuScene)
    {
        SceneManager.LoadScene(_menuScene);
    }
}

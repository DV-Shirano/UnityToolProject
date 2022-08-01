using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    
    public GameObject pauseMenuUI;
    public GameObject hud;
    public GameObject gun;

    [SerializedField]

    public static float currentScore;
    public static bool Paused = false;

    private void Awake()
    {
        currentScore = 0;
        Time.timeScale = 1f;
        Paused = false;
    }

    private void Update()
    {
        
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

        currentScoreTextView.text = "Score: " + currentScore.ToString();
        currentScoreTextViewGO.text = "Final Score: " + currentScore.ToString();
        currentScoreTextViewWIN.text = "Final Score: " + currentScore.ToString();
    }

    public void Pause()
    {
        hud.gameObject.SetActive(false);

        gun.gameObject.SetActive(false);

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

        gun.gameObject.SetActive(true);
    }

    public void LoadScene(string Level01)
    {
        float highScore = PlayerPrefs.GetFloat("HighScore");
        if (currentScore > highScore)
        {
            PlayerPrefs.SetFloat("HighScore", currentScore);
            Debug.Log("New High Score: " + currentScore);
        }



        SceneManager.LoadScene(Level01);
    }

    public void ExitLevel()
    {
        float highScore = PlayerPrefs.GetFloat("HighScore");
        if(currentScore > highScore)
        {
            PlayerPrefs.SetFloat("HighScore", currentScore);
            Debug.Log("New High Score: " + currentScore);
        }

        SceneManager.LoadScene("MainMenu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause_menu : MonoBehaviour
{

    public static bool game_paused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu_manager();
        }
    }

    public void menu_manager()
    {
        if (game_paused)
        {
            Resume();
        }else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        game_paused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        game_paused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        game_paused = false;
        FindObjectOfType<level_picker>().level_pick();
    }

    public void QuitGame()
    {
        game_paused = false;
        Application.Quit();
    }

}

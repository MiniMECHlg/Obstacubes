using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class game_manager : MonoBehaviour
{

    Scene scene;

    public static bool game_has_ended = false;

    public float restart_delay = 1f;

    public GameObject complete_level_ui;

    void Start ()
    {
        game_has_ended = false;
    }

    public void end_level()
    {
        complete_level_ui.SetActive(true);
        game_has_ended = true;
        scene = SceneManager.GetActiveScene();
        double coin_value = scene.buildIndex / 2;
        int coins = (int)Math.Round(coin_value);
        if (scene.buildIndex - 1 > 80)
        {
            SaveManager.Instance.add_coins(coins - 16);
        }
        else if (scene.buildIndex - 1 > 60)
        {
            SaveManager.Instance.add_coins(coins - 12);
        }
        else if (scene.buildIndex - 1 > 40)
        {
            SaveManager.Instance.add_coins(coins - 8);
        }
        else if (scene.buildIndex - 1 > 20)
        {
            SaveManager.Instance.add_coins(coins - 4);
        }
        else
        {
            SaveManager.Instance.add_coins(coins);
        }
    }

    public void EndGame()
    {
        if (game_has_ended == false)
        {
            game_has_ended = true;
            SaveManager.Instance.death();
            Invoke("Restart", restart_delay);
        }
    }
        
    void Restart()
        {
            game_has_ended = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            game_has_ended = false;
        }

}

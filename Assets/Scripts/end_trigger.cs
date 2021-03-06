using UnityEngine;

public class end_trigger : MonoBehaviour
{

    public game_manager gameManager;
    public bool won = false; 

    void OnTriggerEnter ()
    {
        if (game_manager.game_has_ended == false)
        {
            won = true;
            FindObjectOfType<audio_manager>().Play("won_round");
            SaveManager.Instance.level_complete();
            FindObjectOfType<player_collide>().stop_movement();
            gameManager.end_level();
        }  
    }
}

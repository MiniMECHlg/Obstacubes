using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_collide : MonoBehaviour
{

    public player_move movement;


    public void stop_movement()
    {
        movement.enabled = false;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            FindObjectOfType<audio_manager>().Play("hit_block");
            stop_movement();
            FindObjectOfType<game_manager>().EndGame();
        }
    }

}
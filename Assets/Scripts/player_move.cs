using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{

    public Rigidbody rb;

    public bool slowed = false;
    public bool exploded = false;

    public bool death = true;

    float[,] speeds = new float[,]
        {
            {1800f, 40f},
            {2000f, 60f},
            {2400f, 80f},
        };

    public time_manager timeManager;
    public Explode explode_s;

    public void explode()
    {
        if (exploded == false)
        {
            exploded = true;
            FindObjectOfType<audio_manager>().Play("sonic_wave");
            explode_s.explode();
        }
    }

    void FixedUpdate()
    {
        //FindObjectOfType<Explode>().explode();
        //adds a constant forward force
        rb.AddForce(0, 0, speeds[SaveManager.Instance.difficulty() - 1,0] * Time.deltaTime, ForceMode.Force);
        if (Input.GetKey("d"))
        {
            rb.AddForce(speeds[SaveManager.Instance.difficulty() - 1, 1] * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-speeds[SaveManager.Instance.difficulty() - 1, 1] * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("s"))
        {
            time();
        }

        if (death == true)
        {
            if (rb.position.y < -1f)
            {
                FindObjectOfType<game_manager>().EndGame();
            }
        }
    }

    public void time()
    {

        if (slowed == false)
        {
            slowed = true;
            timeManager.slow_motion();
        }
    }

}

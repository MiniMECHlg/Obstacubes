using UnityEngine;

public class player_move_touch : MonoBehaviour
{
    public Rigidbody rb;
    public Canvas movement_ui;
    private float ScreenWidth;
    private bool moveLeft = false;
    private bool moveRight = false;

    float[,] speeds = new float[,]
        {
            {1800f, 60f},
            {2000f, 80f},
            {2400f, 1000f},
        };

    public void Start()
    {
        ScreenWidth = Screen.width;
        if (SaveManager.Instance.touch() == true)
        {
            movement_ui.enabled = true;
        }
        else
        {
            movement_ui.enabled = false;
        }
    }

    public void move_left()
    {
        moveLeft = true;
    }

    public void stop_left()
    {
        moveLeft = false;
    }

    public void move_right()
    {
        moveRight = true;
    }

    public void stop_right()
    {
        moveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveManager.Instance.touch() == false)
        {
            int i = 0;
            while (i < Input.touchCount)
            {
                if (Input.GetTouch(i).position.x > ScreenWidth / 2)
                {
                    rb.AddForce(speeds[SaveManager.Instance.difficulty() - 1, 1] * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }
                if (Input.GetTouch(i).position.x < ScreenWidth / 2)
                {
                    rb.AddForce(-speeds[SaveManager.Instance.difficulty() - 1, 1] * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }
                ++i;
            }
        }
        else if (moveRight) {
            rb.AddForce(speeds[SaveManager.Instance.difficulty() - 1, 1] * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        else if (moveLeft)
        {
            rb.AddForce(-speeds[SaveManager.Instance.difficulty() - 1, 1] * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }
}

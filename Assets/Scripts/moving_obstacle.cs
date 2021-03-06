using UnityEngine;

public class moving_obstacle : MonoBehaviour
{

    public Rigidbody rb;
    public float sideways_force = 4f;
    public bool direction = true;

    // Update is called once per frame
    void Update()
    {
        if (direction == true)
        {
            transform.position += new Vector3(sideways_force * Time.deltaTime, 0, 0);
            if (transform.position[0] >= 9)
            {
                direction = false;
            }
        } else
        {
            transform.position -= new Vector3(sideways_force * Time.deltaTime, 0, 0);
            if (transform.position[0] <= -9)
            {
                direction = true;
            }
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            if (collisionInfo.collider.tag == "Obstacle")
            {
                if (direction == true)
                {
                    direction = false;
                }
                else
                    direction = true;
            }
        }
    }
}

using UnityEngine;
using System.Collections;

public class MovingVertical : MonoBehaviour
{
    private float speed;
    public float dirSpeed = 9.0f;
    float origY;
    public float distance = 8.0f;
    // Use this for initialization
    void Start()
    {
        origY = transform.position.y;
        speed = -dirSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (origY - transform.position.y > distance)
        {
            speed = dirSpeed;
        }
        else if (origY - transform.position.y < -distance)
        {
            speed = -dirSpeed;
        }

        transform.Translate(0, speed * Time.deltaTime, 0);
    }
}

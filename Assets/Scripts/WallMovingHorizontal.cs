using UnityEngine;
using System.Collections;

public class WallMovingHorizontal : MonoBehaviour {

    private float speed;
    public float dirSpeed = 9.0f;
    float origX;
    public float distance = 8.0f;
    // Use this for initialization
    void Start()
    {
        origX = transform.position.x;
        speed = -dirSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float compare = origX - transform.position.x;
        if (compare > distance)
        {
            speed = -dirSpeed;
        }
        else if (compare < -distance)
        {
            speed = dirSpeed;
        }
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
}

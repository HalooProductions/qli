using UnityEngine;
using System.Collections;

public class BoulderSpawner : MonoBehaviour {

    public GameObject Boulder;
    public float spawnTimer;
    private float timer;
    private float x;
    private float y;

    // Use this for initialization
    void Start()
    {
        timer = spawnTimer;
        /*
        for (int i = 0; i < 10; i++)
        {
            Spawn();
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Spawn();
            timer = spawnTimer;
        }

    }

    public void Spawn()
    {
        x = 21;
        y = 17.5F;
        Vector3 newPos = new Vector3(x, y, 0);
        transform.rotation = Quaternion.Euler(0, 0, Time.deltaTime);
        GameObject g = (GameObject)Instantiate(Boulder, newPos, transform.rotation);
    }
}

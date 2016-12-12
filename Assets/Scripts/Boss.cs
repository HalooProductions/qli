using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

    public bool isUsingCloseBy = false;
    GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
	    if (Mathf.Abs(player.transform.position.x - transform.position.x) < 10)
        {
            if (player.transform.position.x - transform.position.x < 0)
            {
                transform.Translate(new Vector3(0.1f, 0));
            }
            else
            {
                transform.Translate(new Vector3(-0.1f, 0));
            }
        }
	}
}

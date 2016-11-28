using UnityEngine;
using System.Collections;

public class StopSliding : MonoBehaviour {

    private float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
        void OnCollisionStay2D(Collision2D coll) {
            // Jos pelaaja katsoo vasemmalle, tarvitsee kertoa -1.
            if (coll.gameObject.tag == "Player")
            {
                Player player = coll.gameObject.GetComponent<Player>();

                if (player.facingRight)
                {
                    player.transform.Translate(speed * Time.deltaTime, 0, 0);
                }

                else
                {
                    player.transform.Translate((speed * Time.deltaTime) * -1, 0, 0);
                }
            }
            else
            {
                coll.gameObject.transform.Translate(speed * Time.deltaTime, 0, 0);
            }
        }
}

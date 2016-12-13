using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour {

    public bool isUsingCloseBy = false;
    public GameObject JalluPullo;
    public GameObject JalluSpawnPoint;
    private GameObject player;
    private Rigidbody2D rb2d;
    private bool isFlipped = false;
    public float life = 10f;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("ThrowJallu", 2.0f, 5.0f);
    }
	
	// Update is called once per frame
	void Update () {
        rb2d.freezeRotation = true;

        if (player.transform.position.x - transform.position.x > 0 && !isFlipped)
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
            isFlipped = true;
        }
        else if (player.transform.position.x - transform.position.x < 0 && isFlipped)
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
            isFlipped = false;
        }

        if (Mathf.Abs(player.transform.position.x - transform.position.x) < 10)
        {
            if (isFlipped)
            {
                if (player.transform.position.x - transform.position.x > 0)
                {
                    transform.Translate(new Vector3(0.1f, 0));
                }
                else
                {
                    transform.Translate(new Vector3(-0.1f, 0));
                }
            }
            else
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

        if (life <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("CongratulationsScene");
        }
	}

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "PlayerBoulder")
        {
            life--;
        }
    }

    void ThrowJallu () {
        GameObject obj = (GameObject) Instantiate(JalluPullo, JalluSpawnPoint.transform.position, JalluSpawnPoint.transform.rotation);
        if (GameObject.FindWithTag("Player").transform.position.y >= 5)
        {
            obj.GetComponent<Rigidbody2D>().velocity = (GameObject.FindWithTag("Player").transform.position - transform.position);
        }
        else
        {
            if (player.transform.position.x - transform.position.x < 0)
            {
                obj.GetComponent<Rigidbody2D>().velocity = new Vector2(-15, 5);
            }
            else
            {
                obj.GetComponent<Rigidbody2D>().velocity = new Vector2(15, 5);
            }
        }
    }
}

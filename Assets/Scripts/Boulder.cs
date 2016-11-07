using UnityEngine;
using System.Collections;

public class Boulder : MonoBehaviour {

    public float speed;
    private Rigidbody2D boulder;

	// Use this for initialization
	void Start () {
        boulder = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 v = new Vector3(1.0F, 0.0F, 0.0F);
        boulder.AddForce(v * speed);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "FallCollider")
        {
            Destroy(gameObject);
        }
    }
}

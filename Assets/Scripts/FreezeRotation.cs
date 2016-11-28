using UnityEngine;
using System.Collections;

public class FreezeRotation : MonoBehaviour {

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();

        if (rb2d != null)
        {
            rb2d.freezeRotation = true;
        }
	}
}

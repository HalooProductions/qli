using UnityEngine;
using System.Collections;

public class JalluPullo : MonoBehaviour {

    private float rotation = 360;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void LateUpdate () {
        RotateLeft();
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }

    void RotateLeft() {
        Quaternion theRotation = transform.localRotation;
        theRotation *= Quaternion.Euler(0, 0, 5);
        transform.rotation = theRotation;
    }
}

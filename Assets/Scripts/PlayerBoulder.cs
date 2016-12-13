using UnityEngine;
using System.Collections;

public class PlayerBoulder : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}

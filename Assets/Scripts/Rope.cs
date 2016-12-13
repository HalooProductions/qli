using UnityEngine;
using System.Collections;

public class Rope : MonoBehaviour {

    public GameObject ropeShooter;
    public int maxRopeFrameCount;
    public LineRenderer lineRenderer;

    private Player player;
    private DistanceJoint2D rope;    
    private int ropeFrameCount;
    private bool ropeOn;
    

    // Use this for initialization
    void Start () {
        ropeOn = false;
        lineRenderer.sortingOrder = 10;
        lineRenderer.sortingLayerName = "Objects";
        player = ropeShooter.GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            if (ropeOn)
            {
                GameObject.DestroyImmediate(rope);
                ropeOn = false;
            }
            else
            {
                Fire();
                ropeOn = true;
            }
            
        }
    }

    void LateUpdate()
    {
        if (rope != null)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetVertexCount(2);
            lineRenderer.SetPosition(0, ropeShooter.transform.position);
            lineRenderer.SetPosition(1, rope.connectedAnchor);
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    void FixedUpdate()
    {
        /*if (rope != null)
        {
            ropeFrameCount++;

            if (ropeFrameCount > maxRopeFrameCount)
            {
                GameObject.DestroyImmediate(rope);
                ropeFrameCount = 0;
            }
        }*/
    }

    void Fire()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 position = ropeShooter.transform.position;
        Vector3 direction;
        position.x = position.x + 5;
        position.y = position.y + 5;
        if (player.facingRight)
        {
            direction = new Vector3(1, 1, 0);
        }
        else
        {
            direction = new Vector3(-5, 1, 0);
        }


        RaycastHit2D hit = Physics2D.Raycast(position, direction, 20f);

        if (hit.collider != null)
        {
            DistanceJoint2D newRope = ropeShooter.AddComponent<DistanceJoint2D>();
            newRope.enableCollision = true;
            //newRope.frequency = 1f;
            newRope.connectedAnchor = hit.point;
            newRope.enabled = true;
            newRope.distance = 8;

            //GameObject.DestroyImmediate(rope);
            rope = newRope;
            ropeFrameCount = 0;
        }
    }

}

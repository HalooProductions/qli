using UnityEngine;
using System.Collections;

public class CharMove : MonoBehaviour {

    public float speed = 2.0F;
    public float jumpSpeed = 3.0F;
    public float gravity = 20.0F;
    private bool isMoving = false;
    private Vector3 moveDirection = Vector3.zero;
    //GameObject player;
    control_script asd;

	// Use this for initialization
	void Start () {
        //player = GameObject.FindWithTag("player");
        asd = GetComponent<control_script>();
    }
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        float z = Input.GetAxis("Horizontal");

        if (z != 0.0f)
        {
            isMoving = true;
        } else
        {
            isMoving = false;
        }

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0.0f, 0.0f, -z);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
            asd.Run();
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        if (!isMoving)
        {
            asd.GetComponentInChildren<Animator>().SetBool("isRun", false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private MoveAnimation moveAnimation;
    private float turnSmoothVel;
    private bool groundedPlayer;
    private float gravityValue = -9.81f;
    private Vector3 playerVelocity;

    public Transform cam;
    public CharacterController controller;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    // Update is called once per frame

    void Start(){
        moveAnimation = GetComponent<MoveAnimation>();
    }
    void Update()
    {
        //if player is on the ground, stop him falling
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0) {
            playerVelocity.y = 0f;
            moveAnimation.StopJump();
        }


        //get users input for movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f){
            //set animation to running
            moveAnimation.StartAnimation();

            //set the players face to the same as the camera
            float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // move player in the direction required
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle,0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }else if (direction.magnitude == 0f){
            //stop running animation
            moveAnimation.StopAnimation();
        }

        if (playerVelocity.y == 0f && Input.GetKeyDown(KeyCode.Space)) {
            moveAnimation.Jump();
            playerVelocity.y += Mathf.Sqrt(5f * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    //public bool isDummy = false;

    private MoveAnimation moveAnimation;
    private float turnSmoothVel;
    private bool groundedPlayer;
    private float gravityValue = -9.81f;
    private Vector3 playerVelocity;

    public Transform cam;
    public CharacterController controller;

    private float runLimit;
    private float level;
    private float spending;
    private bool isRunning = false;
    public Image bar;

    private float speed;
    public float walkSpeed;
    public float runSpeed;
    public float turnSmoothTime = 0.1f;
    // Update is called once per frame

    void Start(){
        moveAnimation = GetComponent<MoveAnimation>();
        //if(isDummy == null){ isDummy = false;}
        speed = walkSpeed;
        runLimit = 100;
        spending = 10;
        level = runLimit;
    }
    void Update()
    {
        //if(isDummy){return;}

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
            if(!isRunning){
                moveAnimation.StartAnimation();
            }
            

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
            playerVelocity.y += Mathf.Sqrt(2f * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.LeftShift) && level > 0){
            speed = runSpeed;
            moveAnimation.StartRunning();
            isRunning = true;
        }else if (Input.GetKeyUp(KeyCode.LeftShift) || level < 0){
            speed = walkSpeed;
            moveAnimation.StopRunning();
            isRunning = false;
        }

        if(isRunning && level > 0){
            level -= spending * (Time.deltaTime * 1.5f);
            bar.rectTransform.localScale = new Vector3((level/100),1f,1f);
        }else if (!isRunning && level < 100){
            level += spending * (Time.deltaTime / 2);
            bar.rectTransform.localScale = new Vector3((level/100),1f,1f);
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float jumpSpeed;
    private bool canJump = true;
    public bool isCarrying = false;
    private int numOfChild;
    public string scene;
    private bool isLose = false;

    private float maxDashTime = 1.0f;
    private float dashSpeed = 10.0f;
    private float dashStoppingSpeed = 0.1f;
    private float currentDashTime;

    public Animator playerAnim;
    private bool isRunningPressed;
    private bool isJumpingPressed;
    private bool isDashPressed;
    private bool isRunning2Pressed;

    public KPUBuilding kpuBuilding;
    public SFX sfx;
    public PlayerManager playerManager;

    private void Start()
    {
        currentDashTime = maxDashTime;
        scene = SceneManager.GetActiveScene().name;
        kpuBuilding = FindObjectOfType<KPUBuilding>();
        sfx = FindObjectOfType<SFX>();
        sfx.PlayBackground();
        playerManager = FindObjectOfType<PlayerManager>();
        isLose = false;
    }

    void LateUpdate()
    {
        ChildrenCheck();
        PlayerMovement();     
        if (isLose == true)
        {
            playerManager.Die();
        }
        if(kpuBuilding.winning == true)
        {
            playerManager.Win();
        }
    }

    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //PLAYER MOVEMENT
        Vector3 playerMovement = new Vector3(horizontal, 0f, vertical) * speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
        
        if (horizontal != 0 || vertical != 0)
        {
            isRunningPressed = true;
            playerAnim.SetBool("IsRunning", isRunningPressed);

            if (numOfChild > 6)
            {
                isRunning2Pressed = true;
                playerAnim.SetBool("IsRunning2", isRunning2Pressed);
            }

            else
            {
                isRunning2Pressed = false;
                playerAnim.SetBool("IsRunning2", isRunning2Pressed);
                isRunningPressed = true;
                playerAnim.SetBool("IsRunning", isRunningPressed);

                //DASH
                if (canJump == true && Input.GetKeyDown(KeyCode.LeftShift))
                {
                    currentDashTime = 0.0f;
                    speed = 8.0f;
                    sfx.PlayDash();
                }

                if (currentDashTime < maxDashTime)
                {
                    speed = dashSpeed;
                    isDashPressed = true;
                    playerAnim.SetBool("IsDash", isDashPressed);
                    currentDashTime += dashStoppingSpeed;
                }
                else
                {
                    speed = 4.0f;
                    isDashPressed = false;
                    playerAnim.SetBool("IsDash", isDashPressed);
                }

                //JUMP
                if (canJump == true && Input.GetKeyDown(KeyCode.Space))
                {
                    Vector3 jump = new Vector3(0, jumpSpeed, 0);
                    rb.AddForce(jump, ForceMode.Impulse);
                    isJumpingPressed = true;
                    playerAnim.SetBool("IsJumping", isJumpingPressed);
                    isJumpingPressed = false;
                    canJump = false;
                    sfx.PlayJump();
                }

                if ((canJump == false) && (Input.GetKeyUp(KeyCode.Space)))
                {
                    isJumpingPressed = false;
                    playerAnim.SetBool("IsJumping", isJumpingPressed);
                    canJump = false;
                }

            }
        }

        else
        {
            isRunning2Pressed = false;
            playerAnim.SetBool("IsRunning2", isRunning2Pressed);
            isRunningPressed = false;
            playerAnim.SetBool("IsRunning", isRunningPressed);
        }

        //JUMP
        if (canJump == true && Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 jump = new Vector3(0, jumpSpeed, 0);
            rb.AddForce(jump, ForceMode.Impulse);
            isJumpingPressed = true;
            playerAnim.SetBool("IsJumping", isJumpingPressed);
            isJumpingPressed = false;
            canJump = false;
            sfx.PlayJump();
        }  

        if ((canJump == false) && (Input.GetKeyUp(KeyCode.Space)))
        {
            isJumpingPressed = false;
            playerAnim.SetBool("IsJumping", isJumpingPressed);
            canJump = false;
        }

    }

    void ChildrenCheck()
    {
        numOfChild = transform.childCount;
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        canJump = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy" && kpuBuilding.winning == false)
        {
            isLose = true;
        }
    }

}

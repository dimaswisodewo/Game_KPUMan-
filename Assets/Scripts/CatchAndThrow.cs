using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchAndThrow : MonoBehaviour
{
    public Rigidbody rb;
    public Transform player;
    private float throwForce = 600f;
    private bool hasPlayer = false;
    private bool beingCarried = false;
    public PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerController.isCarrying = false;
        player = playerController.transform;
    }
    
    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.transform.position);
        
        if (dist <= 1.5f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }

        if (hasPlayer && playerController.isCarrying == false && Input.GetMouseButtonDown(0))
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2.2f, player.transform.position.z);
            rb.isKinematic = true;
            transform.parent = player;
            beingCarried = true;
            playerController.isCarrying = true;
        }
        if (beingCarried && playerController.isCarrying == true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                rb.isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                rb.AddForce(player.forward * throwForce);
                playerController.isCarrying = false;
            }
        }

    }
  
}

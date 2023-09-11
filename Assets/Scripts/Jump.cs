using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Jump : MonoBehaviour
{ 
    private Rigidbody rigidBody = null;
    private bool canJump = true;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }    
    
    private void FixedUpdate()
    {
        if(canJump == true)
        {
            Vector3 jump_velocity = new Vector3(0f, 5f, 0f);
            Vector3 velocity_change = jump_velocity - rigidBody.velocity;
       
            rigidBody.AddForce(velocity_change , ForceMode.VelocityChange);
            canJump = false;
        }        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground") // if we collide with the ground, we dont want to fall through it
        {
            //rigidBody.constraints &= RigidbodyConstraints.FreezePositionY; // turn on freeze y position
            canJump = true;
        }
    }

}

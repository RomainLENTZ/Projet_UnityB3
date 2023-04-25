using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float sideWaysForce = 200.0f;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey("left")){
            rb.AddForce(-sideWaysForce*Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(Input.GetKey("right")){
            rb.AddForce(sideWaysForce*Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(rb.position.y < -2){
            FindObjectOfType<GameManager>().EndGame();
        }

    }
}

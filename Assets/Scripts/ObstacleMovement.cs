using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float forwardForce = 10.0f;
    [SerializeField] float increasedRate = 1f;
    private float currentForwardForce;
    private float timeElapsed = 0;

    void Start()
    {
        currentForwardForce = forwardForce;
    }

    void FixedUpdate()
    {
        timeElapsed += Time.deltaTime;
        currentForwardForce = forwardForce + increasedRate * timeElapsed;
        rb.AddForce(0, 0, -currentForwardForce*Time.deltaTime, ForceMode.Impulse);
    }
}

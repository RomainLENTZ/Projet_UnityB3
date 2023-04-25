using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvicibilityItemCollisions : MonoBehaviour
{
    [SerializeField] int invisibilityDuration = 5;
    void OnCollisionEnter(Collision collisionInfo){
        if(collisionInfo.collider.tag == "Player"){
            FindObjectOfType<PlayerCollision>().ActivateInvicibility(invisibilityDuration);
            FindObjectOfType<GameManager>().scoreBonus = true;
            Destroy(gameObject);
        }
    }
}

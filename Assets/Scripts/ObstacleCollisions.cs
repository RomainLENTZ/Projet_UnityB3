using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollisions : MonoBehaviour
{
    [SerializeField] ObstacleMovement obstacleMovement;
    [SerializeField] AudioClip audioImpact;
    private AudioSource audioSource;

    void Start(){
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collisionInfo){
        if(collisionInfo.collider.tag == "Player" || collisionInfo.collider.tag == "obstacle"){
            obstacleMovement.enabled = false;
            audioSource.PlayOneShot(audioImpact);
        }

    }
}

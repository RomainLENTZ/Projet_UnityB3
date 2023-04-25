using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] PlayerMovements playerMovements;
    [SerializeField] Material invicibilityMaterial;
    [SerializeField] Material defaultMaterial;
    [SerializeField] Color defaulBackgroundColor;
    [SerializeField] float explosionForce = 1000f;
    [SerializeField] float explosionRadius  = 10f;
    [SerializeField] AudioClip invincibilitySound;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject invicibilityImageLeft;
    [SerializeField] GameObject invicibilityImageRight;
    [SerializeField] float animationSpeed;

    private AudioSource audioSource;
    private float invincibilityEndTime = 0;
    private bool isInvicible = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collisionInfo){

        if(collisionInfo.collider.tag == "obstacle" && !isInvicible){
            playerMovements.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }

        else if(collisionInfo.collider.tag == "obstacle" && isInvicible){
            collisionInfo.collider.attachedRigidbody.AddExplosionForce(explosionForce, collisionInfo.collider.transform.position, explosionRadius);
        }
    }

    void Update(){
        if(isInvicible){
            gameObject.GetComponent<Renderer>().material = invicibilityMaterial;
            float step = animationSpeed * Time.deltaTime;
            invicibilityImageLeft.transform.position = Vector3.MoveTowards(invicibilityImageLeft.transform.position, new Vector3(invicibilityImageLeft.transform.position.x, 3.72f, invicibilityImageLeft.transform.position.z ), step);
            invicibilityImageRight.transform.position = Vector3.MoveTowards(invicibilityImageRight.transform.position, new Vector3(invicibilityImageRight.transform.position.x, 3.72f, invicibilityImageLeft.transform.position.z ), step);
            if(Time.time >= invincibilityEndTime){
                isInvicible = false;
                audioSource.Stop();
                gameObject.GetComponent<Renderer>().material = defaultMaterial;
                mainCamera.GetComponent<Camera>().backgroundColor = defaulBackgroundColor;
                StopCoroutine("FlashEnvironment");
            
            }
        }

        else{
            float step = animationSpeed * Time.deltaTime;
            invicibilityImageLeft.transform.position = Vector3.MoveTowards(invicibilityImageLeft.transform.position, new Vector3(invicibilityImageLeft.transform.position.x, 8f, invicibilityImageLeft.transform.position.z ), step);
            invicibilityImageRight.transform.position = Vector3.MoveTowards(invicibilityImageRight.transform.position, new Vector3(invicibilityImageRight.transform.position.x, 8, invicibilityImageLeft.transform.position.z ), step);
        }
    }

    public void ActivateInvicibility(int invisibilityDuration){
        isInvicible = true;
        invincibilityEndTime = Time.time + invisibilityDuration;
        audioSource.clip = invincibilitySound;
        audioSource.Play();
        StartCoroutine("FlashEnvironment");
    }

    private IEnumerator FlashEnvironment()
    {
        while (isInvicible)
        {
            mainCamera.GetComponent<Camera>().backgroundColor = Color.Lerp(defaultMaterial.color, new Color(Random.value, Random.value, Random.value), Mathf.PingPong(Time.time, 1));
            yield return new WaitForSeconds(0.1f);
        }
    }
}

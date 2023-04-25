using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObstacle : MonoBehaviour
{
    void Update()
    {
        if(gameObject.transform.position.y <= 0){
            Destroy(gameObject);
        }
    }
}

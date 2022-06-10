using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGrounded : MonoBehaviour
{
    public bool playerGrounded;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag != "Player"){
            playerGrounded = true;
        }
        
        
        
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag != "Player"){
            playerGrounded = false;
        }
    }
}

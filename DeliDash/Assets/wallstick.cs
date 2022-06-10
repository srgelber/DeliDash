using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallstick : MonoBehaviour
{

    private BoxCollider box;
    public bool touchingWall;
    // Start is called before the first frame update
   

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag != "Player"){
            touchingWall = true;
        }
        
        
        
    }

    private void OnTriggerExit(Collider other) {

        if(other.gameObject.tag != "Player"){
            touchingWall = false;
        }
        
        
        
    }
}

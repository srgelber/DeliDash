using UnityEngine;
using System.Collections;
 
public class PingPong : MonoBehaviour {
    private Transform attacher;
    public int height = 10;//max height of Box's movement
    private float yCenter = 0f;
 
    void Start () {
        attacher = this.transform;
        yCenter = this.transform.position.y;
    }
 
    void FixedUpdate () {
    transform.position = new Vector3(transform.position.x, yCenter + Mathf.PingPong(Time.time * 1, height) - height/2f, transform.position.z);//move on y axis only
    }
}

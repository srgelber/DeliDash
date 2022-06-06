using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoorSystem
{
public class Gate : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;
    
    private bool doorOpen = false;

    private void Start()
    {
        StartCoroutine(callChange());
    }

    private void FixedUpdate() {
        transform.position += (velocity * Time.deltaTime);
    }

    private IEnumerator callChange()
    {
        while (!doorOpen)
        {
        raise();
        yield return new WaitForSeconds(1);
        stop();
        //yield return new WaitForSeconds(.1f);
        lower();
        yield return new WaitForSeconds(.2f);
        stop();
        yield return new WaitForSeconds(1);
        }

    }

    void raise()
    {
        velocity.y = 5;
    }

    void lower()
    {
        velocity.y = -25;
    }

    void stop()
    {
        velocity.y = 0;
    }

    public void Open()
    {
        if (!doorOpen)
        {
            StartCoroutine(callChange());
        }
    }
}

}
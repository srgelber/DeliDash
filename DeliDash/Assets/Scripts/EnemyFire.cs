using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [SerializeField] private float damage;

    public bool invincible = false;

    private IEnumerator Invincibility()
    {
        yield return new WaitForSeconds(3);
        invincible = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!invincible)
            {
                invincible = true;
                other.GetComponent<Health>().TakeDamage(damage);
                StartCoroutine(Invincibility());
            }
        }
    }

}

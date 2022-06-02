using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem
{
public class Toppings : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteLib _spriteLib = null;
    [SerializeField] public int numTopping = 0;

    private bool facingRight = true;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (facingRight)
            {
                
                facingRight = false;
                transform.Rotate(0f, 180f, 0f);
            }
        }

        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (!facingRight)
            {
                
                transform.Rotate(0f, -180f, 0f);
                facingRight = true;
            }
        }
    }

    public void AddTopping(Sprite collectedSprite, int number)
    {
        if (number == numTopping)
        {
        spriteRenderer.sprite = collectedSprite;
        }
    }
}
}
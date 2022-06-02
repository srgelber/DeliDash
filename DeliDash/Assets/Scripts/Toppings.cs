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

    public void AddTopping(Sprite collectedSprite, int number)
    {
        if (number == numTopping)
        {
        spriteRenderer.sprite = collectedSprite;
        }
    }
}
}
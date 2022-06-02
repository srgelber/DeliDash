using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem
{
public class Collectable : MonoBehaviour
{
    [SerializeField] private SpriteLib _spriteLib = null;
    [SerializeField] private Toppings toppings;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            toppings = _spriteLib.GetTopping();

            if (this.tag == "Cheese")
            {
                toppings.AddTopping(_spriteLib.cheese, _spriteLib.numTopping);
                _spriteLib.numTopping += 1;
            }

            else if (this.tag == "Tomato")
            {
                toppings.AddTopping(_spriteLib.tomato, _spriteLib.numTopping);
                _spriteLib.numTopping += 1;
            }

            else if (this.tag == "Lettuce")
            {
                toppings.AddTopping(_spriteLib.lettuce, _spriteLib.numTopping);
                _spriteLib.numTopping += 1;
            }
            
            else if (this.tag == "Ham")
            {
                toppings.AddTopping(_spriteLib.ham, _spriteLib.numTopping);
                _spriteLib.numTopping += 1;
            }

            else if (this.tag == "Chicken")
            {
                toppings.AddTopping(_spriteLib.chicken, _spriteLib.numTopping);
                _spriteLib.numTopping += 1;
            }

            else if (this.tag == "Bacon")
            {
                toppings.AddTopping(_spriteLib.bacon, _spriteLib.numTopping);
                _spriteLib.numTopping += 1;
            }

            gameObject.SetActive(false);
        }
    }
}
}
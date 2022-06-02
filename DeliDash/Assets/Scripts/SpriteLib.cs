using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem
{
public class SpriteLib : MonoBehaviour
{
    public Sprite cheese;
    public Sprite tomato;

    public int numTopping = 0;

    public Toppings topping0;
    public Toppings topping1;

    public Toppings GetTopping()
    {
        if (numTopping == 0)
        {
            return topping0;
        }

        else if (numTopping == 1)
        {
            return topping1;
        }

        else
        {
            return topping0;
        }
    }
}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem
{
public class SpriteLib : MonoBehaviour
{
    public Sprite cheese;
    public Sprite tomato;
    public Sprite lettuce;
    public Sprite chicken;
    public Sprite ham;
    public Sprite bacon;

    public int numTopping = 0;

    public Toppings topping0;
    public Toppings topping1;
    public Toppings topping2;
    public Toppings topping3;
    public Toppings topping4;
    public Toppings topping5;
    public Toppings topping6;


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

        else if (numTopping == 2)
        {
            return topping2;
        }

        else if (numTopping == 3)
        {
            return topping3;
        }

        else if (numTopping == 4)
        {
            return topping4;
        }

        else if (numTopping == 5)
        {
            return topping5;
        }

        else if (numTopping == 6)
        {
            return topping6;
        }

        else
        {
            return topping0;
        }
    }
}
}
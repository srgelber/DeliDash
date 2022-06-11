using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public Canvas canvas0;
    public Canvas canvas1;
    public Canvas canvas2;
    public Canvas canvas3;
    public Canvas canvas4;
    public Canvas canvas5;
    public Canvas canvas6;
    public Canvas canvas7;
    public Canvas canvas8;
    public Canvas canvas9;
    
    public int currentScene = 0;

    public void nextScene()
    {
        if (currentScene == 0)
        {
            canvas0.gameObject.SetActive(false);
            
        }
        
        if (currentScene == 1)
        {
            canvas1.gameObject.SetActive(false);
            
        }

        if (currentScene == 2)
        {
            canvas2.gameObject.SetActive(false);
            
        }

        if (currentScene == 3)
        {
            canvas3.gameObject.SetActive(false);
            
        }

        if (currentScene == 4)
        {
            canvas4.gameObject.SetActive(false);
            
        }

        if (currentScene == 5)
        {
            canvas5.gameObject.SetActive(false);
            
        }

        if (currentScene == 6)
        {
            canvas6.gameObject.SetActive(false);
            
        }

        if (currentScene == 7)
        {
            canvas7.gameObject.SetActive(false);
            
        }

        if (currentScene == 8)
        {
            canvas8.gameObject.SetActive(false);
            
        }

        if (currentScene == 9)
        {
            canvas9.gameObject.SetActive(false);
            
        }
        currentScene += 1;
    }
}

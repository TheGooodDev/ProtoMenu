using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{   
    //Reference to button to access its components
    private Image _This;
    private float r ;
    private float g ;
    private float b ;
    private int rate = 0;
    private bool switchColor = false;
    private Transform panel;

    private int posy;

    //this get the Transitions of the Button as its pressed
    private ColorBlock theColor;
 


    void Update()
    {
        if (switchColor)
        {
            if (rate == 60)
            {              
                r = Random.Range(0f, 1.1f);
                g = Random.Range(0f, 1.1f);
                b = Random.Range(0f, 1.1f);
                Image img = GameObject.Find("MyPanelLeft").GetComponent<Image>();
                img.color = new Color(r, g, b, 0.5f);
                print("Cliked : " + r + "," + g + "," + b);
                rate = 0;
            }
            rate += 1;
        }
    }
 
    public void ButtonTransitionColors()
    {
        if (switchColor)
        {
            switchColor = false;
        }
        else
        {
            switchColor = true;
        }
        rate = 0;
    }
}

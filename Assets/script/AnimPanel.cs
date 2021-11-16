using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimPanel : MonoBehaviour
{

    private RectTransform panelrect;
    private float posY;
    private int i = 1440;
    private int l = 0;
    private bool isdown = false;
    private bool move = true;

    void Awake()
    {
        panelrect = this.GetComponent<RectTransform>();
        panelrect.offsetMax = new Vector2(0, -i);
        panelrect.offsetMin = new Vector2(0, -l);
    }
    // Update is called once per frame
    void Update()
    {
        if (l <= 1220 && l >= 220)
        {
            isdown = !isdown;
        }else if(i == 1440 && l == 0)
        {
            isdown = !isdown;
            float r = Random.Range(0f, 1.1f);
            float g = Random.Range(0f, 1.1f);
            float b = Random.Range(0f, 1.1f);
            Image img = this.GetComponent<Image>();
            img.color = new Color(r, g, b, 0.5f);
        }
        if ((i <= 1220 && l == 0))
        {
            move = !move;
        }
        if (isdown)
        {
            if (move)
            {
                panelrect.offsetMax = new Vector2(0, -i);
                i -= 1;
            }
            else
            {
                panelrect.offsetMin = new Vector2(-0, l);
                l += 1;
            }
        }
        else
        {
            if (move)
            {
                panelrect.offsetMax = new Vector2(0, -i);
                i += 1;
            }
            else
            {
                panelrect.offsetMin = new Vector2(0, l);
                l -= 1;
            }
        }
    }
}

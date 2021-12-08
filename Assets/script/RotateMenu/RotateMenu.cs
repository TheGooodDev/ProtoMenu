using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RotateMenu : MonoBehaviour
{

    private float posX;
    private float posY;
    private int first = -5;
    private List<Button> buttons = new List<Button>();
    private Button[] carousel;
    public Button SelectedMusic;

    // Start is called before the first frame update
    void Start()
    {
        carousel = new Button[11];

        GetObject();
        ChangeCarousel(0);
        carousel[carousel.Length - 1].gameObject.SetActive(false);
        setOpacity();
        SetMusic();

    }


    void GetObject()
    {
        GameObject[] btn = GameObject.FindGameObjectsWithTag("Music");
        for (int i = 0; i < btn.Length; i++)
        {
            buttons.Add(btn[i].GetComponent<Button>());
        }
        int count = 1;
        foreach (Button i in buttons)
        {
            i.gameObject.SetActive(false);
            count++;
        }

    }


    void SetMusic()
    {
        float angle = 180 / (carousel.Length - 1) * Mathf.Deg2Rad;
        for(int i=0; i < carousel.Length; i++)
        {
            if(carousel[i] != null)
            {
                float xpos = Mathf.Sin(angle * -i) * 700;
                float ypos = Mathf.Cos(angle * -i) * 500;
                carousel[i].transform.position = new Vector2(this.transform.position.x + xpos, this.transform.position.y + ypos);
                
            }
        }
        setOpacity();
    }

    void setOpacity()
    {
        bool isOpacity = true;
        float opacity = 0;
        
        for (int i = 0; i < carousel.Length; i++)
        {
            if (carousel[i] != null)
            {
                var color = carousel[i].GetComponent<Image>().color;
                if (opacity == 1f)
                {
                    carousel[i].GetComponent<RectTransform>().sizeDelta = new Vector2(200, 200);
                    color.a = opacity;
                    carousel[i].GetComponent<Image>().color = color;
                    OnChange(carousel[i]);
                }
                else
                {
                    

                    carousel[i].GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);
                    color.a = opacity;
                    carousel[i].GetComponent<Image>().color = color;
                }
                if (carousel[i].targetGraphic.color.a <= 0f)
                {
                    
                    carousel[i].gameObject.SetActive(false);
                }
                else
                {
                    carousel[i].gameObject.SetActive(true);
                }
                if (i == carousel.Length - 1)
                {
                    carousel[i].gameObject.SetActive(false);
                }

            }

            if (opacity == 1f)
            {
                isOpacity = false;
            }

            if (isOpacity)
            {
                opacity += 0.2f;
            }
            else
            {
                opacity -= 0.2f;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeCarousel(1);
            SetMusic();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangeCarousel(-1);
            SetMusic();
        }
    }

    void ChangeCarousel(int nbr)
    {
        first += nbr;
        if (first <= -5)
        {
            first = -5;
        }else if(first >= buttons.Count - 5)
        {
            first = buttons.Count-6;
        }

        for (int i = 0; i <= 10; i++)
        {
            if ((first+i) <= buttons.Count-1 && (first+i)>= 0)
            {
                carousel[i] = buttons[first + i];
            }
            else
            {
                carousel[i] = null;
            }

        }
    }


    void OnChange(Button music)
    {
        if (SelectedMusic != null)
        {
            SelectedMusic.GetComponentInChildren<AudioSource>().Stop();
        }
        SelectedMusic = music;
        
        SelectedMusic.GetComponentInChildren<AudioSource>().Play();
        GameObject.Find("SelectImage").GetComponent<Image>().sprite = music.GetComponent<Image>().sprite;
        GameObject.Find("SelectArtist").GetComponent<Text>().text = music.transform.Find("Artist").GetComponent<Text>().text;
        GameObject.Find("SelectTitle").GetComponent<Text>().text = music.transform.Find("Title").GetComponent<Text>().text;


    }
}

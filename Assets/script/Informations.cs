using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Informations : MonoBehaviour
{

    private Button music;
    // Start is called before the first frame update
    void Start()
    {
        music = GameObject.Find("Pivot").GetComponent<RotateMenu>().SelectedMusic;
    }

    // Update is called once per frame
    void Update()
    {
        music = GameObject.Find("Pivot").GetComponent<RotateMenu>().SelectedMusic;
    }
}

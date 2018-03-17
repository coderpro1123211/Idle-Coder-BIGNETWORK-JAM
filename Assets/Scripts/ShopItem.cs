using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour {

    public Text title;
    public Text desc;
    public Image img;
    public Button buy;
    public bool isGoogle;
    public string descr;
    public string descr2;
    GameManager gm;


    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (isGoogle)
        {
            desc.text = descr + "\nCost : " + ((gm.Lines+1) * 10) + descr2; 
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour {

    public ShopItemDecl[] items;
    public ShopItem itemPrefab;
    public Transform itemParent;

    private void Start()
    {
        for (int i = 0; i < items.Length; i++)
        {
            var it = items[i];
            var pref = Instantiate(itemPrefab, itemParent);
            pref.title.text = it.title;
            pref.desc.text = it.description + "\nCost : " + (it.isGoogle ? "" : it.cost.ToString()) + " lines\n<color=#" + ColorUtility.ToHtmlStringRGBA(it.effectCol) + ">" + it.effect + "</color>";
            pref.isGoogle = it.isGoogle;
            if (it.isGoogle)
            {
                pref.descr = it.description;
                pref.descr2 = "\n<color=#" + ColorUtility.ToHtmlStringRGBA(it.effectCol) + ">" + it.effect + "</color>";
            }
            pref.img.sprite = it.image;

            pref.buy.onClick.AddListener(() => {
                if (it.cost > FindObjectOfType<GameManager>().Lines || it.isGoogle)
                {
                    return;
                }
                FindObjectOfType<GameManager>().OnClick(true, -it.cost);
                FindObjectOfType<ClickManager>().AddCps(it.cpsInc);
                FindObjectOfType<ClickManager>().linesPerClick += it.pcInc;
            });

        }
    }
}

[System.Serializable]
public struct ShopItemDecl
{
    public string title;
    public string description;
    public string effect;
    public Color effectCol;
    public Sprite image;
    public int cost;
    public int cpsInc;
    public int pcInc;
    public bool isGoogle;
}

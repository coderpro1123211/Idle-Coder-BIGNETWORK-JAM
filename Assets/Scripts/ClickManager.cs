using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickManager : MonoBehaviour {

    GameManager gm;

    public float cpsToAdd;
    float delayBetween;
    public int linesPerClick;

    float t;

	// Use this for initialization
	void Start () {
        gm = FindObjectOfType<GameManager>();
	}

    public void AddCps(float cps)
    {
        cpsToAdd += cps;
    }
	
	// Update is called once per frame
	void Update () {
        delayBetween = 1f / cpsToAdd; 

		if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && !gm.isInShop)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            gm.OnClick(false, linesPerClick);
        }

        t += Time.deltaTime;
        while (t > delayBetween)
        {
            t -= delayBetween;
            gm.SetAddCps(cpsToAdd);
            if (gm.isInShop) break;
            gm.OnClick(true);
        }
	}
}

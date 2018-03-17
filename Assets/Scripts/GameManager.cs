using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    int loc; //Lines Of Code, aka. Currency
    public int Lines { get { return loc; } }

    public float displayCps; // Actual cps value to display
    float cps; // Clicks Per Second
    float targetCps; // Raw CPS
    float addCps; // Cps to add because of workers

    public AnimationCurve cpsCurve; // For smoothing out TargetCps when user is not clicking
    public Animator doodAnim;

    public float falloff;
    public float smoothTime;
    public float maxSpeed;

    public Text codeText; // Text for LOC and CPS

    public bool isInShop;

    float vel; // For SmoothDamp

    float delay; // Delay between last OnClick call, for calculating clicks per sec

    public void OnClick(bool ignoreCps = false, int clicks = 1)
    {
        loc+=clicks;
        if (ignoreCps) return; // Probably shouldn't do dis
        float d = Time.timeSinceLevelLoad - delay;

        targetCps = ((float)clicks) / d;

        delay = Time.timeSinceLevelLoad;
    }

    public void SetAddCps(float add)
    {
        addCps = add;
    }

    public void SetShopState(bool state)
    {
        isInShop = state;
    }

    private void Update()
    {
        if (float.IsNaN(cps)) cps = 0;
        cps = Mathf.SmoothDamp(cps, targetCps * Mathf.Clamp01(cpsCurve.Evaluate(Mathf.Clamp01((Time.timeSinceLevelLoad - delay)*falloff))), ref vel, smoothTime, maxSpeed);
        doodAnim.SetFloat("speed", Mathf.Min(cps / 10, 30));
        displayCps = cps + addCps;

        codeText.text = "Lines of Code : " + loc + (isInShop ? "" : ("\nCode per Second : " + Mathf.Round(displayCps) + " lines/s"));
    }
}

using UnityEngine;

[ExecuteInEditMode]
public class SlidePanel : MonoBehaviour {
    [Range(0,100)]
    public float transition;
    Canvas canvas;

    public Side side;
    RectTransform t;

    void Update ()
    {
        if (canvas == null) canvas = FindObjectOfType<Canvas>();
        Vector2 center = canvas.pixelRect.center;
        Vector2 w = canvas.pixelRect.size;
        Vector2 outside = Vector2.zero;
        switch (side)
        {
            case Side.Left:
                outside = new Vector2(center.x - w.x, center.y);
                break;
            case Side.Right:
                outside = new Vector2((w.x - center.x) + w.x, center.y);
                break;
            case Side.Up:
                outside = new Vector2(center.x, center.y - w.y);
                break;
            case Side.Down:
                outside = new Vector2(center.x, (w.y - center.y) + w.y);
                break;
            default:
                break;
        }

        if (t == null) t = GetComponent<RectTransform>();
        t.localPosition = Vector2.Lerp(outside, center, transition/100f);
    }

    public void In()
    {
        GetComponent<Animator>().SetTrigger("in");
    }

    public void Out()
    {
        GetComponent<Animator>().SetTrigger("out");
    }
}

public enum Side { Left, Right, Up, Down }

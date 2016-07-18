using UnityEngine;
using System.Collections;

public class FPS : MonoBehaviour
{
    public int missedFrames = 0;
    private GUIStyle style;
    private Rect rect;

    void Start()
    {
        int w = Screen.width, h = Screen.height;
        rect = new Rect(0, 0, w, h * 2 / 100);
        style = new GUIStyle();
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
    }

    void Update()
    {
        if (Time.deltaTime > 0.012)
        {
            missedFrames += 1;
        }
    }

    void OnGUI()
    {
        string text = string.Format("{0:0.0} missed frames)", missedFrames);
        GUI.Label(rect, text, style);
    }
}
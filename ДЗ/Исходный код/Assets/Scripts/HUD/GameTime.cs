using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTime : MonoBehaviour {

    Text text;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
    }

    public static string getTime()
    {
        int seconds = (int)Time.timeSinceLevelLoad;
        int minutes = seconds / 60;
        seconds = seconds % 60;
        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    // Update is called once per frame
    void Update () {
        int seconds = (int)Time.timeSinceLevelLoad;
        int minutes = seconds / 60;
        seconds = seconds % 60;
        text.text = "Время: " + getTime();
    }
}

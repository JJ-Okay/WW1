using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetDeathsCount : MonoBehaviour {

    Text text;
	// Use this for initialization


    void Start()
    {
        text = GetComponent<Text>();
        int deaths = SingletonClass.instance.deaths_count;
        text.text = "Смертей: " + deaths;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

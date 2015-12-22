using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SingletonClass : MonoBehaviour {

    public static SingletonClass instance;

    public GameObject camera;
    public int deaths_count = 0;
    public int collected_coins = 0;
    public Menu menu;


    public static void increment_deaths_count()
    {
        instance.deaths_count++;
    }

    public static void increment_collected_coins()
    {
        instance.collected_coins++;
    } 

    public static int get_collected_coins()
    {
        return instance.collected_coins;
    }

    void Awake()
    {
        Menu menu = GetComponent<Menu>();

        if (instance != null && instance != this)
        {
            instance.camera = camera;
            instance.collected_coins = 0;
            //instance.menu = menu;

            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            instance.menu = menu;
            DontDestroyOnLoad(instance.gameObject);
        }

    }
	
	// Update is called once per frame
	void Update () {
        if(camera)
        { 
            instance.transform.position = camera.transform.position;
        }
    }
}

using UnityEngine;
using System.Collections;
using System.Threading;

public class Menu : MonoBehaviour {

    Font pauseMenuFont;
    private bool pauseEnabled = false;
    bool display_score = false;

    readonly object syncPrimitive = new object();

    public void pause()
    {
            pauseEnabled = true;
            display_score = true;
            AudioListener.volume = 0;
            Time.timeScale = 0;
            Cursor.visible = true;

    }

    // Use this for initialization
    void Start () {
        pauseEnabled = false;
        Time.timeScale = 1;
        AudioListener.volume = 1;
        Cursor.visible = false;

        if(display_score)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        display_score = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("escape"))
        {

            //check if game is already paused		
            if (pauseEnabled == true)
            {
                //unpause the game
                Start();

            }

            //else if game isn't paused, then pause it
            else if (pauseEnabled == false)
            {
                display_score = false;
                pauseEnabled = true;
                AudioListener.volume = 0;
                Time.timeScale = 0;
                Cursor.visible = true;
            }
        }
    }

    void OnGUI()
    {

        GUI.skin.box.font = pauseMenuFont;
        GUI.skin.button.font = pauseMenuFont;

        if (pauseEnabled == true)
        {

            //Make a background box
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 250, 200), "Меню");

            if(display_score)
            {
                GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 80, 250, 50), "Время: " + GameTime.getTime());
                GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 65, 250, 50), "Собрано монет: " + SingletonClass.get_collected_coins());
            }

            //Make Main Menu button
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 30, 250, 50), "Продолжить"))
            {
                Start();
            }


            //Make quit game button
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 30, 250, 50), "Выход"))
            {
                Application.Quit();
            }
        }
    }
}

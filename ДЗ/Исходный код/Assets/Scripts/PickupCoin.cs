using UnityEngine;
using System.Collections;

public class PickupCoin : MonoBehaviour
{
    AudioSource source;
    // Use this for initialization
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SingletonClass.increment_collected_coins();
            source.time = 0.5f;
            source.Play();
            Renderer render = GetComponent<Renderer>();
            render.enabled = false;
            Destroy(gameObject, 5);
        }
    }
}
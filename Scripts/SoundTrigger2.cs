using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger2 : MonoBehaviour {

    public GameObject Player_C1;
    AudioSource audioSource;

    //USED FOR SPIDERS AND JUMP SCARES

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.volume = Random.Range(0.9f, 1f);
            audioSource.pitch = Random.Range(0.9f, 1f);

            GetComponent<AudioSource>().Play();
        }


    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit called, should stop audio.");
        AudioSource audio = GetComponent<AudioSource>();
        audio.Stop();

    }

}

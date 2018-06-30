using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SoundTrigger1 : MonoBehaviour {
    public GameObject Player_C1;
    AudioSource audioSource;

    //USED FOR THE BACKGROUND MUSIC

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
            audioSource.volume = Random.Range(0.6f, 0.8f);
            audioSource.pitch = Random.Range(0.6f, 0.8f);

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderLashOut : MonoBehaviour {
    public Transform myTransform;
    public Transform playerLockedOn;

    public float smooth;
    public AudioClip Spider_Hiss;

    AudioSource spiderHiss;
    // Use this for initialization
    void Start () {
        playerLockedOn = GameObject.FindWithTag("Player").transform; //target the player

    }
	
	// Update is called once per frame
	void Update () {
   
    //Turns the spider in the direction of the player
    myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
    Quaternion.LookRotation(playerLockedOn.position - myTransform.position), smooth * Time.deltaTime);

        var distance = Vector3.Distance(playerLockedOn.position, myTransform.position);
        if (distance < 2.0f)
        {
            GetComponent<Animation>().Play("attack1");
            AudioSource.PlayClipAtPoint(Spider_Hiss, transform.position,0.5f);
        }
        else if (distance < 15.0f)
        {
            GetComponent<Animation>().Play("idle");
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAttackSpider : MonoBehaviour {

    public Transform[] target;
    public float speed;
    public float smooth;

    private int current;
   // public Transform myTransform;
    public Transform playerLockedOn;
    public Transform myTransform;

    public AudioClip Spider_Hiss;

    AudioSource spiderHiss;
    // Use this for initialization
    void Start()
    {
        //playerLockedOn = GameObject.FindWithTag("Player").transform; //target the player

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position != target[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);

        }
        else current = (current + 1) % target.Length;

        if (target[current] == target[1])
        {

            Quaternion target = Quaternion.Euler(0, -90, 0); //Turns left 90 degrees downward
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

        }

        if (target[current] == target[2])
        {
            Quaternion target = Quaternion.Euler(0, -180, 0); //-180, -360, -270 Turns to the right 90 degrees
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

        }

        if (target[current] == target[3])
        {
            Quaternion target = Quaternion.Euler(0, -270, 0); //Turns left 90 degrees upward
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

        }

        if (target[current] == target[4])
        {
            Quaternion target = Quaternion.Euler(0, -360, 0); //-180, -360, -270 Turns to the right 90 degrees
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

        }
        //myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
//Quaternion.LookRotation(playerLockedOn.position - myTransform.position), smooth * Time.deltaTime);

        var distance = Vector3.Distance(playerLockedOn.position, myTransform.position);
        if (distance < 3.0f)
        {
            GetComponent<Animation>().Play("attack1");
            AudioSource.PlayClipAtPoint(Spider_Hiss, transform.position, 0.7f);
        }

        else if (distance < 15.0f)
        {
            GetComponent<Animation>().Play("walk");
        }

    }
}




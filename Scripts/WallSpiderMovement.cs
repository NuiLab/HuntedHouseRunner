using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpiderMovement : MonoBehaviour {

    public Transform[] target;
    public float speed;
    public float smooth;

    private int current;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {



        if (transform.position != target[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
            
        }
        else current = (current + 1) % target.Length;

        if (target[current] == target[1]) {  

            Quaternion target = Quaternion.Euler(90, -180,-90); //Turns left 90 degrees downward
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime*smooth);
            
        }

        if (target[current] == target[2])
        {
            Quaternion target = Quaternion.Euler(-180, -360, -270); //-180, -360, -270 Turns to the right 90 degrees
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            
        }

        if (target[current] == target[3])
        {
            Quaternion target = Quaternion.Euler(-90, 180, -90); //Turns left 90 degrees upward
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

        }

        if (target[current] == target[4])
        {
            Quaternion target = Quaternion.Euler(0, 0, 90); //-180, -360, -270 Turns to the right 90 degrees
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

        }
        

    }
}

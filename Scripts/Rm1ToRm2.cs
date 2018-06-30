using System;
using System.IO;
using UnityEngine;
using System.Collections;


public class Rm1ToRm2 : MonoBehaviour {

    public GameObject Player_C1;
    public BoxCollider collider1; //moving from room 1 to room 2
    //public BoxCollider collider2; //moving from room 2 to room 1
    //IEnumerator

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) //changes player
        {

            //previous path created for testing 
            string path = "C:/Users/charm/Documents/HauntedHouseRunner/playerPaths.txt";

            //path needed to use after build was completed
            //string path = "C:/Users/charm/Desktop/TaxiRush_Data/playerPaths.txt";
            

            // This text is added only once to the file. 
            if (!File.Exists(path))
            {

                var sr = File.CreateText("horrorTimes.txt");
                sr.WriteLine("RIGHT");
                sr.Close();

            }

            var relativePosition = transform.InverseTransformPoint(other.transform.position);


            if (relativePosition.x > 0 && collider1)  
            {             
                string appendText =
                       "Room 1 -> Room 2" + Environment.NewLine;
                File.AppendAllText(path, appendText);
            }


            /*if (relativePosition.x > 0 && collider2)
            {
                collider1.enabled = false;  //turn off the 1st collider
                string appendText =
                         "Room 2 -> Room 1" + Environment.NewLine;
                 File.AppendAllText(path, appendText);         
            }*/

           // yield return new WaitForSeconds(4);  //wait before activating the 2nd collider
            //collider1.enabled = true;   //reactivates the 2nd collider



            // Open the file to read from. 
            string readText = File.ReadAllText(path);
            Console.WriteLine(readText);
        }




    }


}

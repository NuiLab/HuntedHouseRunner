using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HallwayToRm1 : MonoBehaviour {


    public GameObject Player_C1;
    private int playerCount;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) //changes player
        {
            WriteInFile(); //saves time in playerPaths.txt
        }

    }

    void WriteInFile()
    {
        //previous path created for testing 
        string path = "C:/Users/charm/Documents/HauntedHouseRunner/playerPaths.txt";

        //path needed to use after build was completed
        //string path = "C:/Users/charm/Desktop/TaxiRush_Data/playerTimes.txt";


        // This text is added only once to the file. 
        if (!File.Exists(path))
        {

                var sr = File.CreateText("horrorTimes.txt");
                sr.Write("Player #: " + ++playerCount);
                sr.WriteLine("");
                sr.WriteLine("-----Horror Ver, Path Taken-----");
                sr.WriteLine("Entrance hallway -> Room 1" );
                sr.Close();

        }
            string appendText =
                Environment.NewLine + "Player #: " + ++playerCount +
                Environment.NewLine + "-----Horror Ver, Path Taken-----" +
                Environment.NewLine + "Entrance hallway -> Room 1" + 
                Environment.NewLine;
            File.AppendAllText(path, appendText);
        


        // Open the file to read from. 
        string readText = File.ReadAllText(path);
        Console.WriteLine(readText);
    }








}

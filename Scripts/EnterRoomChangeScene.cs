using System;
using System.IO;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;



public class EnterRoomChangeScene : MonoBehaviour {

    [SerializeField] private string levelName;
    public Text timerLabel;
    private float time;

    private bool stopTimer = false;


   // public Camera playerCam;

    public GameObject Player_C1;


    void Update()
    {
        if (!stopTimer)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = time + 0; //stops timer
        }

        var minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
        var seconds = time % 60;//division for the seconds.
        var fraction = (time * 100) % 100;

        //update the label value
        timerLabel.text = string.Format("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);



    }

    int changeTheScene;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) //changes player
        {
            WriteInFile(); //saves time in horrorTimes.txt
           
            SceneManager.LoadScene(changeTheScene);


        }

    }

    void WriteInFile()
    {
        //previous path created for testing 
        string path = "C:/Users/charm/Documents/HauntedHouseRunner/horrorTimes.txt";

        //path needed to use after build was completed
        //string path = "C:/Users/charm/Desktop/TaxiRush_Data/playerTimes.txt";

        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;
        int playerCount = 0;


        // This text is added only once to the file. 
        if (!File.Exists(path))
        {
            if (sceneName == "Map_Hosp2")
            {
                var sr = File.CreateText("horrorTimes.txt");
                sr.Write("Player #: " + playerCount);
                sr.WriteLine("");
                sr.WriteLine("Horror Version");
                sr.WriteLine("Time: " + time);
                sr.Close();

            }          

        }

        // This text is always added, making the file longer over time 
        if (sceneName == "Map_Hosp2")
        {
            string appendText = Environment.NewLine + "Player #: " + playerCount++ + 
                Environment.NewLine + "-----Horror Version-----" + 
                Environment.NewLine + "Time: " + time + 
                Environment.NewLine;
            File.AppendAllText(path, appendText);
        }


        // Open the file to read from. 
        string readText = File.ReadAllText(path);
        Console.WriteLine(readText);
    }




}

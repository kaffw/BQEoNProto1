using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSequenceInitializer : MonoBehaviour
{
    public static List<int> mapsequence = new List<int>();
    public static List<int> mapsequence2 = new List<int>();

    public static int location = 0;
    public static int act2Location = 0;


    public static bool NagasLairEntry = false;

    public static int counterToAct1End = 0;
    public static int counterToAct2End = 0;

    public bool dupeChecker = false;

    public static bool entryToAct2 = false;
    public static bool entryToAct3 = false;
    
    public static int oneInstance = 0;
    public static float savedCurrentHealth = 5; //recently removed

    void Start()
    {
        if (oneInstance == 0) { MapSequenceUpdate(); oneInstance++; }
    }

    void Update()
    {
        if (moveset.deathCounter == 5)
        {
            mapsequence.Clear();
            mapsequence2.Clear();
            MapSequenceUpdate();
            moveset.deathCounter = 0;
            if(moveset.ActLocation == 1) SceneManager.LoadScene(1);
            if(moveset.ActLocation == 2) SceneManager.LoadScene(8);
            if(moveset.ActLocation == 3) SceneManager.LoadScene(18);
        }

        if (Health.damaged) { savedCurrentHealth--; Health.damaged = false; }

    }

    public void MapSequenceUpdate()
    {
        location = 0;
        act2Location = 0;
        counterToAct1End = 0;
        counterToAct2End = 0;
        entryToAct2 = false;
        entryToAct3 = false;

        mapsequence.Add(1);

        while (mapsequence.Count < 7)
        {
            int num = UnityEngine.Random.Range(2, 8);
            dupeChecker = false;

            foreach (int numInSequence in mapsequence)
            {

                if (num == numInSequence)
                {
                    dupeChecker = true;
                    break;
                }
            }

            if (!dupeChecker)
            {
                mapsequence.Add(num);
            }
        }

        mapsequence.Add(8);

        while(mapsequence2.Count < 9)
        {
            int num = UnityEngine.Random.Range(9, 18);
            dupeChecker = false;

            foreach (int numInSequence in mapsequence2)
            {

                if (num == numInSequence)
                {
                    dupeChecker = true;
                    break;
                }
            }

            if (!dupeChecker)
            {
                mapsequence2.Add(num);
            }
        }
        /*
        for (int y = 0; y < 10; y++)
        {
            Debug.Log(mapsequence2[y]);
        }
        */
    }
}
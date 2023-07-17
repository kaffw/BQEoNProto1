using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSequenceInitializer : MonoBehaviour
{
    public static List<int> mapsequence = new List<int>();
    public static int location = 0;

    public static int counterToAct1End = 0;

    public bool dupeChecker = false;

    public static bool entryToAct3 = false;
    public static int oneInstance = 0;

    public static float savedCurrentHealth = 5;

    void Start()
    {
        if (oneInstance == 0) { MapSequenceUpdate(); oneInstance++; }
    }

    void Update()
    {
        if (moveset.deathCounter == 5)
        {

            mapsequence.Clear();
            MapSequenceUpdate();
            moveset.deathCounter = 0;
            SceneManager.LoadScene(1);
        }

        if (Health.damaged) { savedCurrentHealth--; Health.damaged = false; }
    }

    void MapSequenceUpdate()
    {
        location = 0;
        counterToAct1End = 0;
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
    }
}
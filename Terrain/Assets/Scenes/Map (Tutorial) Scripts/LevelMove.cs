using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    public static List<int> mapsequence = new List<int>();  // Declare mapsequence as a member variable
    public static int location=0;
    public bool dupeChecker = false;

    public static int counterToAct1End=0;

    private void OnTriggerEnter2D(Collider2D other)
    {

    mapsequence.Add(0);
    
    while (mapsequence.Count < 7)
    {
        int num = UnityEngine.Random.Range(1, 7);
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

        mapsequence.Add(7);

        if (other.CompareTag("Player"))
        {
            counterToAct1End++;
            location++;
            SceneManager.LoadScene(mapsequence[location]);
        }

    }
}
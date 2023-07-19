using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreviousMap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterPositionManager.ifFromEntrance = true;
            MapSequenceInitializer.location--;

            if(moveset.ActLocation == 1) MapSequenceInitializer.counterToAct1End--;
            if(moveset.ActLocation == 2) MapSequenceInitializer.counterToAct2End--;
            SceneManager.LoadScene(MapSequenceInitializer.mapsequence[MapSequenceInitializer.location]);
        }
    }
}

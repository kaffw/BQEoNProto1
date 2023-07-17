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
            MapSequenceInitializer.counterToAct1End--;
            SceneManager.LoadScene(MapSequenceInitializer.mapsequence[MapSequenceInitializer.location]);
        }
    }
}

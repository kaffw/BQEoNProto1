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
            //MapSequenceInitializer.location--;

            if (moveset.ActLocation == 1)
            {
                if (MapSequenceInitializer.location != 1)
                {
                    MapSequenceInitializer.location--;
                    MapSequenceInitializer.counterToAct1End--;
                    CharacterPositionManager.ifFromEntrance = true;
                    SceneManager.LoadScene(MapSequenceInitializer.mapsequence[MapSequenceInitializer.location]);

                }

            }

            //MapSequenceInitializer.act2Location--;
            if (moveset.ActLocation == 2)
            {
                if (MapSequenceInitializer.act2Location != 1)
                {
                    MapSequenceInitializer.act2Location--;
                    MapSequenceInitializer.counterToAct2End--;
                    CharacterPositionManager.ifFromEntrance = true;
                    SceneManager.LoadScene(MapSequenceInitializer.mapsequence2[MapSequenceInitializer.act2Location]);
                }
            }
        }
    }
}

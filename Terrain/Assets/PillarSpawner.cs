using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PillarSpawner : MonoBehaviour
{
    public List<GameObject> pillarType = new List<GameObject>();
    public List<GameObject> mobType = new List<GameObject>();

    public Vector2 oldPillarPos; //storing old Pillar Pos

    public GameObject Target;

    public GameObject SpawnTriggerDetector; //To limit pillar spawning
    public static bool ifSpawn = false;
    public float spawnRate = 0f;

    public float timer = 0f;

    public bool ifExit = false; //to end script

    public static List<int> yRisePos = new List<int>();
    public static int yRiseCurrentPos = 0;
    private int yRiseCurrentInstancePos = 0;
    private List<int> typeOfPillarToSpawn = new List<int>();

    private int oldPillarYPosInInt;

    private int numOfPillarsToSpawn = 120;
    private int pillarsToSpawnIndex = 0;

    private int i = 0;
    void Start()
    {
        Target = GameObject.Find("Bulan");
        Instantiate(pillarType[0], new Vector2(Target.transform.position.x, Target.transform.position.y - 8), transform.rotation);
        oldPillarPos = new Vector2(Target.transform.position.x + 5, Target.transform.position.y - 8);

        while (pillarsToSpawnIndex < numOfPillarsToSpawn)
        {
            typeOfPillarToSpawn.Add(UnityEngine.Random.Range(0, 3));
            if (typeOfPillarToSpawn[pillarsToSpawnIndex] == 2)
            {
                oldPillarYPosInInt = (int)oldPillarPos.y;
                if (oldPillarYPosInInt < -10) oldPillarYPosInInt += 5;

                yRisePos.Add(UnityEngine.Random.Range(-10, oldPillarYPosInInt - 5));
                pillarsToSpawnIndex++;
            }
            else
            {
                if (oldPillarYPosInInt > 5) oldPillarYPosInInt -= 5;

                yRisePos.Add(UnityEngine.Random.Range(-10, oldPillarYPosInInt + 5));
                pillarsToSpawnIndex++;
            }
        }
    }

    void Update()
    {
        moveset.ActLocation = 3;
        MapSequenceInitializer.entryToAct3 = true;
        if (!ifExit)
        {
            if (timer <= 120f) //condition to change scene
            {
                timer += Time.deltaTime;
            }
            else
            {
                //SceneManager.LoadScene(10);
                ifExit = true;
            }

            if (!ifSpawn && yRiseCurrentInstancePos <= 120)
            {
                Instantiate(pillarType[typeOfPillarToSpawn[yRiseCurrentInstancePos]], new Vector2(oldPillarPos.x + 5, -14), transform.rotation);
                oldPillarPos = new Vector2(oldPillarPos.x + 10, yRisePos[yRiseCurrentInstancePos]);
                yRiseCurrentInstancePos++;
                spawnRate = 0f;

                if (i == 2)
                {
                    ifSpawn = true;
                    i = 0;
                }
                else i++;

            }

            //timer += Time.deltaTime; //timer to End
            spawnRate += Time.deltaTime; //spawnRate
        }
        else SceneManager.LoadScene(24);
    }

}
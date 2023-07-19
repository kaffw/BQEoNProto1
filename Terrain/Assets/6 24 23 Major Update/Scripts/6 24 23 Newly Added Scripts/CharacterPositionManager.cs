using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPositionManager : MonoBehaviour
{
    public static Vector2 entrancePosition = new Vector2 (0, 0);
    public static Vector2 exitPosition = new Vector2 (80, 0);
    public static bool ifFromEntrance = false;

    public static Vector2 entrancePositionAct2 = new Vector2(0, 2);
    public static Vector2 exitPositionAct2 = new Vector2(100, 2);
}

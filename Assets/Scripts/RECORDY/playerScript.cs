using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    #region playerFields
    [Header("PlayerBaseStats")]

    public static float playerHP;//baseValue=10;
    public static float movSpeed;//baseValue=1.2;
    [Header("PlayerSpecialStats")]
    
    public static float charmCooldown;//baseValue=10(seconds);
    public static float charmRange;//baseValue=5(meters);
    public static float summonBonusHP;//baseValue=5;
    public static int currentWave=0;
    public static int EnemiesCount;
    #endregion
}
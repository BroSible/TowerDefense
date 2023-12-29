using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class WaveGeneratorScript : MonoBehaviour
{
    [Header("EnemyPrefab")]
    [SerializeField] private GameObject _enemy;
    
    [Header("EnemyCoordinates")]
    [SerializeField] private float _spawnX;//координата X места спавна врагов 
    [SerializeField] private float _spawnY;//координата Y места спавна врагов 

    [Header("UpgradeCanvas")]
    [SerializeField] private Canvas _UpgradeMenuCanvas;

    private float _enemySpawnDelay=2f;
    private float _bonusSelectConditionDelay=1f;

    private void Start()
    {
        SpawnWaveFuncCall();
    }
    private void Update()
    {
        _bonusSelectConditionDelay-=Time.deltaTime;
        if(_bonusSelectConditionDelay<=0 && playerScript.EnemiesCount<=0)
        {
            ChooseUpgrade();
        }
    }
    public void SpawnWaveFuncCall()
    {
        SpawnWave(_enemySpawnDelay,_enemy);
    }
    private IEnumerator SpawnEnemy(GameObject enemy)
    {
        for(int i=0;i<playerScript.EnemiesCount;i++)
        {
            yield return new WaitForSeconds(_enemySpawnDelay);
            GameObject newEnemy = Instantiate(enemy, new Vector2(_spawnX, _spawnY), Quaternion.identity);
        }
    }
    private void SpawnWave(float enemySpanwDelay,GameObject enemy)
    {
        _bonusSelectConditionDelay=1f;
        playerScript.currentWave++;//счетчик волн
        playerScript.EnemiesCount=1+playerScript.currentWave*2;//растчет количества врагов

        StartCoroutine(SpawnEnemy(enemy));
    }
    public static void DecreaseEnemiesCount()
    {
        playerScript.EnemiesCount--;
    } 
    ////////////////////////////////////////////////////////////////////////
    public void DecreaseCharmCooldown()
    {
        playerScript.charmCooldown+=.5f;
        _UpgradeMenuCanvas.gameObject.SetActive(false); 
        Time.timeScale = 1;
        SpawnWaveFuncCall();
    }

    public void UpgradeCharmRange()
    {
        playerScript.charmRange+=.5f;
        _UpgradeMenuCanvas.gameObject.SetActive(false); 
        Time.timeScale = 1;
        SpawnWaveFuncCall();
    }

    public void UpgradeSummonHP()
    {
        playerScript.summonBonusHP+=5;
        _UpgradeMenuCanvas.gameObject.SetActive(false); 
        Time.timeScale = 1;
        SpawnWaveFuncCall();
    }

    public void ChooseUpgrade()
    {
       _UpgradeMenuCanvas.gameObject.SetActive(true);
       Time.timeScale = 0;
    }
}
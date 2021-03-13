using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public AudioSource orc1Sound;
    public AudioSource orc2Sound;
    //public float timeBetweenWaves = 45f;
    public float timeCounted = 0;
    int currentWave = 0;
    public WinLoseScript winLoseScript;

    public Text counter;
    public Text waveNum;

    public ToolSelector toolSelector;

    public Transform spawnPos1;
    public Transform spawnPos2;

    public GameObject enemy1;
    public GameObject enemy2;
    public Transform enemyHolder;

    float enemy1CD = 0.5f;
    float enemy2CD = 3f;
    float enemy1CDctr = 0;
    float enemy2CDctr = 0;

    int enemy1Stack = 0;
    int enemy2Stack = 0;

    float enemycount;

    // Update is called once per frame
    void Update()
    {
        enemycount = enemy1Stack + enemy2Stack + enemyHolder.childCount;
        counter.text = "Enemies remaining:      " + enemycount;
        waveNum.text = "" + (currentWave);
        if (toolSelector.score > 0)
        {
            timeCounted += Time.deltaTime;
            //check wave
            if (timeCounted > 5f)
            {
                if (currentWave == 0)
                {
                    currentWave = 1;
                    enemy1Stack = 13;
                    enemy2Stack = 2;
                }
                else if (enemycount == 0)
                {
                    if (currentWave == 1)
                    {
                        currentWave = 2;
                        enemy1Stack = 23;
                        enemy2Stack = 4;
                    }
                    else if (enemycount == 0)
                    {
                        if (currentWave == 2)
                        {
                            currentWave = 3;
                            enemy1Stack = 40;
                            enemy2Stack = 6;
                        }
                        else if (enemycount == 0)
                        {
                            if (currentWave == 3)
                            {
                                winLoseScript.Win();
                            }
                        }
                    }
                }
            }

            //spawn enemies
            if (enemy1Stack > 0)
            {
                if (enemy1CDctr <= 0)
                {
                    GameObject temp1 = Instantiate(enemy1, spawnPos1.position, Quaternion.identity, enemyHolder);
                    EnemyScript tempScript1 = temp1.GetComponent<EnemyScript>();
                    tempScript1.toolSelector = toolSelector;
                    tempScript1.sound = orc1Sound;
                    enemy1CDctr = enemy1CD;
                    enemy1Stack--;
                }
                enemy1CDctr -= Time.deltaTime;
            }
            if (enemy2Stack > 0)
            {
                if (enemy2CDctr <= 0)
                {
                    GameObject temp2 = Instantiate(enemy2, spawnPos2.position, Quaternion.identity, enemyHolder);
                    EnemyScript tempScript2 = temp2.GetComponent<EnemyScript>();
                    tempScript2.toolSelector = toolSelector;
                    tempScript2.sound = orc2Sound;
                    enemy2CDctr = enemy2CD;
                    enemy2Stack--;
                }
                enemy2CDctr -= Time.deltaTime;

            }
        }
    }
}

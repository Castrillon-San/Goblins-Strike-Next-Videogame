using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    public GameObject enemie1;
    public GameObject enemie2;
    public GameObject enemie3;
    public GameObject enemie4;

    public Transform spawnPoint;
    public int currentAliveEnemies;

    public ushort wave = 1;
    public int numOfEnemies = 0;

    private ushort[] numEnemiesVector = new ushort[4];
    private bool waiting = false;

    void Start()
    {
        StartCoroutine(WaveGenerator());
        //spawnPoint = GameObject.Find("SpawnPoint").transform;
    }

    private void Update()
    {
        if(waiting && Input.GetKey(KeyCode.Space))
        {
            StopCoroutine(WaveWaiter());
            waiting = false;
            NextWave();
        }
    }


    IEnumerator WaveGenerator()
    {
        switch (wave)
        {
            case 1:
                numEnemiesVector[0] = 5;  // arqueros
                numEnemiesVector[1] = 3;  // guerreros
                numEnemiesVector[2] = 1;  // goblins
                numEnemiesVector[3] = 0;  // magos
                numOfEnemies = numEnemiesVector[0] + numEnemiesVector[1] + numEnemiesVector[2] + numEnemiesVector[3];
                currentAliveEnemies = numOfEnemies;
                break;
            case 2:
                numEnemiesVector[0] = 2;
                numEnemiesVector[1] = 5;
                numEnemiesVector[2] = 1;
                numEnemiesVector[3] = 9;
                numOfEnemies = numEnemiesVector[0] + numEnemiesVector[1] + numEnemiesVector[2] + numEnemiesVector[3];
                currentAliveEnemies = numOfEnemies;
                //  Se llena del contenido de las oleadas # de cada enemigo y los totales
                break;
            case 3:
                //  Se llena del contenido de las oleadas # de cada enemigo y los totales
                break;
            case 4:
                //  Se llena del contenido de las oleadas # de cada enemigo y los totales
                break;
            case 5:
                //  Se llena del contenido de las oleadas # de cada enemigo y los totales
                break;
            case 6:
                //  Se llena del contenido de las oleadas # de cada enemigo y los totales
                break;
            case 7:
                //  Se llena del contenido de las oleadas # de cada enemigo y los totales
                break;
        }

        do
        {
            Generator();
            numOfEnemies--;
            yield return new WaitForSeconds(2);

        } while (numOfEnemies != 0);


    }

    public void Generator()
    {
        int x;
        x = Random.Range(0, 3);
        if (numEnemiesVector[x] != 0)
        {
            switch(x)
            {
                case 0:
                    Instantiate(enemie1, spawnPoint.transform);
                    numEnemiesVector[0]--;
                    break;
                case 1:
                    Instantiate(enemie2, spawnPoint.transform);
                    numEnemiesVector[1]--;
                    break;
                case 2:
                    Instantiate(enemie3, spawnPoint.transform);
                    numEnemiesVector[2]--;
                    break;
                case 3:
                    Instantiate(enemie4, spawnPoint.transform);
                    numEnemiesVector[3]--;
                    break;
            }
        }
        else
        {
            Generator();
        }
    }

    public void AliveCount()
    {
        currentAliveEnemies--;
        if (currentAliveEnemies<=0)
        {
            StartCoroutine(WaveWaiter());
        }
    }

    public IEnumerator WaveWaiter()
    {
        waiting = true;
        // mensaje de "preparando X oleada  Wave+1;"
        Debug.Log("im waiting");
        yield return new WaitForSeconds(10);
        waiting = false;
        yield return new WaitForSeconds(1);
        NextWave();
    }

    public void NextWave()
    {
        wave++;
        StartCoroutine(WaveGenerator());
    }

}

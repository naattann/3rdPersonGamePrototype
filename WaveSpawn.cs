using System.Collections;
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING , COUNTING };

    [System.Serializable]
    public class WavesParameters
    {

        public Transform enemy;


        public string WaveName;
        public int AmountOfEnemies;
        public float TimeBetweenSpawns;

    }

    public WavesParameters[] waves;
    private int nextWave = 0;


    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    private float WaveStateCheck = 1f;

    private SpawnState state = SpawnState.COUNTING;


    // Start is called before the first frame update
    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {

        if (state == SpawnState.WAITING)
        {
            //Check if enemies are alive

        if(!EnemyIsAlive())
            {

                WaveCompleted();

            }

            else
            {

                return;
            }
        }


        if(waveCountdown <=0)
        { 

           if(state != SpawnState.SPAWNING)

            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
            
        }
          else
        {
            waveCountdown -= Time.deltaTime;
        }

    }

    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length -1)

        {
            nextWave = 0;
            //ALL COMPLETED
        }

        nextWave++;
    }


    bool EnemyIsAlive()
    {
        WaveStateCheck -= Time.deltaTime;

        if (WaveStateCheck <= 0f)
        {
            WaveStateCheck = 1f;

            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 1) 
            {
                return false;
            }           
        }
        return true;
    }



    IEnumerator SpawnWave(WavesParameters _wave)
    {

        state = SpawnState.SPAWNING;

        //Spawn

        for (int i=0; i < _wave.AmountOfEnemies; i++)

        {
            SpawnEnemy(_wave.enemy);

            yield return new WaitForSeconds(_wave.TimeBetweenSpawns);
        }

        state = SpawnState.WAITING;


        yield break;
    }


    void SpawnEnemy(Transform _enemy)
    {

        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(_enemy, _sp.position, _sp.rotation);

    }


}


using System.Collections;
using UnityEngine.SceneManagement;

using UnityEngine;

public class WaveSpawnerFinalLevel : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }


    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    public GameObject collider;

    public GameObject cone_1;
    public GameObject cone_2;
    public int index;


    private AudioSource win;



    public void Start()
    {

        // Instantiate(collider, new Vector3(19, -16, 17), Quaternion.identity);

        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenced");
        }
        waveCountdown = timeBetweenWaves;

        win = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }
        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
                //Start spawning wave
            }

        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;


        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 10;
            Debug.Log("All Waves Complete! Looping.");


            Destroy(collider);
            win.Play();
            Destroy(cone_1);
            Destroy(cone_2);
            
            SceneManager.LoadScene(index);

        }
        else
        {
            Debug.Log("Not over yet");
            nextWave++;
        }

    }





    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f) ;
        {
            searchCountdown = 2f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {

                return false;
            }
        }

        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave" + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning Enemy" + _enemy.name);

        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);

    }

}


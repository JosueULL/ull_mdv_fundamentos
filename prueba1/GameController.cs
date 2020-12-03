using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public GameObject Player;
    public ObjectPool EnemyPool;
    public ObjectPool CatPool;

    public List<Transform> SpawnPoints;

    public int StepsForLife = 3;
    public float PowerForCat = 0.25f;
    public float Power;
    public int Lives;
    public int SpawnTimer = 2;

    private int mLifeStep;
    private float mCurrentTimer;

    public UnityEvent OnPlayerLivesChanged;
    public UnityEvent OnPlayerPowerChanged;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        OnPlayerLivesChanged.Invoke();
        OnPlayerPowerChanged.Invoke();

        EventManager<OnCatPickedUpEvent>.StartListening(OnCatPickedUp);
        EventManager<OnStepOnTombEvent>.StartListening(OnStepOnTomb);
        EventManager<OnEnemyContactPlayer>.StartListening(OnEnemyContactPlayer);
    }

    private void OnDestroy()
    {
        EventManager<OnCatPickedUpEvent>.StopListening(OnCatPickedUp);
        EventManager<OnStepOnTombEvent>.StopListening(OnStepOnTomb);
        EventManager<OnEnemyContactPlayer>.StopListening(OnEnemyContactPlayer);
    }

    private void OnCatPickedUp(OnCatPickedUpEvent e)
    {
        IncreasePlayerPower(PowerForCat);
    }

    private void OnStepOnTomb(OnStepOnTombEvent e)
    {
        IncreasePlayerLifeStep();
    }


    private void OnEnemyContactPlayer(OnEnemyContactPlayer e)
    {
        Lives = 0;
        Power = 0;

        OnPlayerLivesChanged.Invoke();
        OnPlayerPowerChanged.Invoke();

        Player.transform.position = Vector3.zero;
    }

    private void IncreasePlayerLifeStep()
    {
        ++mLifeStep;
        if (mLifeStep >= StepsForLife)
        {
            ++Lives;
            mLifeStep = 0;
            OnPlayerLivesChanged.Invoke();
        }
    }

    private void IncreasePlayerPower(float power)
    {
        Power += power;
        OnPlayerPowerChanged.Invoke();
    }

    private void Update()
    {
        mCurrentTimer += Time.deltaTime;
        if (mCurrentTimer > SpawnTimer)
        {
            Spawn();
            mCurrentTimer = 0;
        }
    }

    private void Spawn()
    {
        GameObject obj;
        if (Random.value > 0.25)
            obj = EnemyPool.Get();
        else
            obj = CatPool.Get();

        Transform spawnPoint = GetRandomSpawnPoint();
        obj.transform.position = spawnPoint.position;
        obj.gameObject.SetActive(true);
    }

    private Transform GetRandomSpawnPoint()
    {
        int index = Random.Range(0, SpawnPoints.Count - 1);
        return SpawnPoints[index];
    }
  
}

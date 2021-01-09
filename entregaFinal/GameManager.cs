using System.Collections;
using UnityEngine;

public class CurrencyChangedEvent : BaseEvent 
{
    public int PrevCurrency;
    public int Currency;
} 

public class GameManager : Singleton<GameManager>
{
    public int Currency;

    private RespawnPoint[] RespawnPoints;
    private WaitForSeconds mRespawnWait = new WaitForSeconds(2f);
    private RespawnPoint mLastRespawnActivated;

    private CurrencyChangedEvent mChangedEvent = new CurrencyChangedEvent();

    // --------------------------------------------------------------------

    private void Awake()
    {
        RespawnPoints = FindObjectsOfType<RespawnPoint>();
        foreach(RespawnPoint rp in RespawnPoints)
        {
            rp.OnActivated.AddListener(OnRespawnPointActivated);
        }
    }

    // --------------------------------------------------------------------

    private void OnRespawnPointActivated(RespawnPoint point)
    {
        mLastRespawnActivated = point;
    }

    // --------------------------------------------------------------------

    public void AddCurrency(int amount)
    {
        mChangedEvent.PrevCurrency = Currency;
        Currency += amount;
        mChangedEvent.Currency = Currency;
        EventManager<CurrencyChangedEvent>.TriggerEvent(mChangedEvent);
    }

    // --------------------------------------------------------------------

    public void RemoveCurrency(int amount)
    {
        mChangedEvent.PrevCurrency = Currency;
        Currency -= amount;
        Currency = Mathf.Max(Currency, 0);
        mChangedEvent.Currency = Currency;
        EventManager<CurrencyChangedEvent>.TriggerEvent(mChangedEvent);
    }

    // --------------------------------------------------------------------

    private RespawnPoint GetClosesRespawnPoint(Vector3 worldPos)
    {
        RespawnPoint closest = null;
        float minDist = float.MaxValue;

        foreach(RespawnPoint rp in RespawnPoints)
        {
            float dist = Vector3.Distance(rp.transform.position, worldPos);
            if (dist < minDist)
            {
                minDist = dist;
                closest = rp;
            }
        }

        Debug.Assert(closest != null, "Couldn't find a valid respawn point");

        return closest;
    }

    // --------------------------------------------------------------------

    public void RespawnPlayer(Transform player)
    {
        StartCoroutine(SpawnRoutine(player));
    }

    // --------------------------------------------------------------------

    private IEnumerator SpawnRoutine(Transform player)
    {
        yield return mRespawnWait;
        RespawnPoint respawnP = mLastRespawnActivated ? mLastRespawnActivated : GetClosesRespawnPoint(player.position);
        player.position = respawnP.transform.position;
        player.gameObject.SetActive(true);
    }
}

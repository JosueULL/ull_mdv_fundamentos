using System.Collections.Generic;
using UnityEngine;

public class OnScoreUpdatedEvent : BaseEvent
{
    public float Score;
}

public class PowerUpCollector : MonoBehaviour
{
    private List<PowerUp> mPowerUps = new List<PowerUp>();

    private OnScoreUpdatedEvent mScoreUpdateEvent = new OnScoreUpdatedEvent();
    private float mScore;

    // --------------------------------------------------------------------

    public void OnTriggerEnter(Collider col)
    {
        PowerUp powerUp = col.GetComponent<PowerUp>();
        if (powerUp)
            mPowerUps.Add(powerUp);

        enabled = true;
    }

    // --------------------------------------------------------------------

    public void OnTriggerExit(Collider col)
    {
        PowerUp powerUp = col.GetComponent<PowerUp>();
        if (powerUp)
            mPowerUps.Remove(powerUp);
    }

    // --------------------------------------------------------------------

    public void Update()
    {
        float prevScore = mScore;

        for (int i = mPowerUps.Count - 1; i >= 0; --i)
        {
            PowerUp powerUp = mPowerUps[i];
            powerUp.Consume(out bool consumed);
            if (consumed)
            {
                powerUp.gameObject.SetActive(false);
                mPowerUps.Remove(powerUp);
            }

            mScore += powerUp.ScorePerSecond * Time.deltaTime;
        }

        if (prevScore != mScore)
        {
            mScoreUpdateEvent.Score = mScore;
            EventManager<OnScoreUpdatedEvent>.TriggerEvent(mScoreUpdateEvent);
        }

        if (mPowerUps.Count == 0)
            enabled = false; // Stop calling Update
    }
}
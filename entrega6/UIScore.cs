using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    public Text ScoreText;

    // --------------------------------------------------------------------

    private void Start()
    {
        EventManager<OnScoreUpdatedEvent>.StartListening(OnScoreUpdated);
    }

    // --------------------------------------------------------------------

    private void OnDestroy()
    {
        EventManager<OnScoreUpdatedEvent>.StopListening(OnScoreUpdated);
    }

    // --------------------------------------------------------------------

    private void OnScoreUpdated(OnScoreUpdatedEvent ev)
    {
        ScoreText.text = string.Format("{0:0000}", (int)ev.Score);
    }
}
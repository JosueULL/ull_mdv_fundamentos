using UnityEngine;
using UnityEngine.UI;

public class ParallaxUI : MonoBehaviour
{
    public Text Score;

    public void UpdateScore()
    {
        Score.text = string.Format("{0:00}", GameManager.Instance.Score);
    }
}

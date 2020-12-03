using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Image Power;
    public Text Lives;

    public void UpdateLives()
    {
        Lives.text = GameController.Instance.Lives.ToString();
    }

    public void UpdatePower()
    {
        Power.fillAmount = GameController.Instance.Power;
    }
}

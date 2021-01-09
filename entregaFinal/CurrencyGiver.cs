using UnityEngine;

public class CurrencyGiver : MonoBehaviour
{
    public void Give(int amount)
    {
        GameManager.Instance.AddCurrency(amount);
    }

}

using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int MaxAmount;

    public UnityEvent OnHealthChanged;
    public UnityEvent OnHealthDepleted;

    private int mAmount;

    // --------------------------------------------------------------------

    private void OnEnable()
    {
        RefillHealth(MaxAmount);
    }

    // --------------------------------------------------------------------

    public void ReduceHealth(int amount)
    {
        mAmount = Mathf.Clamp(mAmount - amount,0,MaxAmount);

        OnHealthChanged.Invoke();
        if (mAmount <= 0)
            OnHealthDepleted.Invoke();
    }

    // --------------------------------------------------------------------

    public void RefillHealth(int amount)
    {
        mAmount = Mathf.Clamp(mAmount + amount, 0, MaxAmount);
        OnHealthChanged.Invoke();
    }
}

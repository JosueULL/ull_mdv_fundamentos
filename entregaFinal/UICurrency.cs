using UnityEngine;
using TMPro;

public class UICurrency : MonoBehaviour
{
    private static readonly int sAddedStateHash = Animator.StringToHash("UIPickableAdded");
    private static readonly int sRemovedStateHash = Animator.StringToHash("UIPickableLoss");
    public TMP_Text Currency;

    private Animator mAnimator;

    // --------------------------------------------------------------------

    private void Awake()
    {
        mAnimator = GetComponent<Animator>();
        EventManager<CurrencyChangedEvent>.StartListening(OnCurrencyChanged);
    }

    // --------------------------------------------------------------------

    private void OnDestroy()
    {
        EventManager<CurrencyChangedEvent>.StopListening(OnCurrencyChanged);
    }

    // --------------------------------------------------------------------

    private void OnCurrencyChanged(CurrencyChangedEvent ev)
    {
        Currency.text = string.Format("{0:00}", ev.Currency);
        if (ev.PrevCurrency < ev.Currency)
        {
            mAnimator.Play(sAddedStateHash);
        }
        else if (ev.PrevCurrency > ev.Currency)
        {
            mAnimator.Play(sRemovedStateHash);
        }
    }
}

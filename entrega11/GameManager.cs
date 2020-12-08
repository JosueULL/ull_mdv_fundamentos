using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Score;

    public static GameManager Instance;

    public UnityEvent OnGameStart;
    public UnityEvent OnScoreChanged;

    private bool mGameStarted;

    void Awake()
    {
        Debug.Assert(Instance == null, "There is more than one GameManager in the scene");
        Instance = this;
    }

    public void Update()
    {
        if (!mGameStarted && Input.GetButton("Jump"))
        {
            OnGameStart.Invoke();
            mGameStarted = true;
        }
    }

    public void IncreaseScore()
    {
        ++Score;
        OnScoreChanged.Invoke();
    }


    public void ResetGame()
    {
        SceneManager.LoadScene("ParallaxScene");
    }
}

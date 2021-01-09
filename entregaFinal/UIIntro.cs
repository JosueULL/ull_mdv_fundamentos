using UnityEngine;
using UnityEngine.SceneManagement;

public class UIIntro : MonoBehaviour
{
    public AppearingText Text;
    public GameObject Logo;
    public GameObject Intro;
    public GameObject PressKeyHint;
    public GameObject LoadingHint;

    void Update()
    {
        if (Input.anyKey) {
            if (Logo.activeSelf)
            {
                Logo.SetActive(false);
                Intro.SetActive(true);
                PressKeyHint.gameObject.SetActive(false);
            }
            else if (Text.HasShownAll)
            {
                PressKeyHint.gameObject.SetActive(false);
                LoadingHint.gameObject.SetActive(true);
                SceneManager.LoadScene("Level1");
            }
        }
    }
}

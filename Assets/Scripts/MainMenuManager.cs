using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void OnContinueButtonClicked()
    {

    }

    public void OnExitGameClicked()
    {
        Application.Quit();
    }
}

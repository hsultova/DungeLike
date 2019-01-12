using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenuManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBackToMainMenuClicked()
    {
        SceneManager.LoadScene(2);
    }
}

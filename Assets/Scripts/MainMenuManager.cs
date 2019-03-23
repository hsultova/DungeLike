using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Text KillsText;
    public Text DeathsText;
    public Text FloorsText;
    public Text TotalGoldText;

    public Button Continue;
    
    public static bool CanContinue = false;
    public static bool IsContinue = false;

    // Use this for initialization
    void Start()
    {
        var dungeLikeData = BinarySaver.LoadStatisticData();

        KillsText.text = dungeLikeData.TotalMonsterKilled.ToString();
        DeathsText.text = dungeLikeData.DeathCount.ToString();
        FloorsText.text = dungeLikeData.HighestLevelReached.ToString();
        TotalGoldText.text = dungeLikeData.TotalGold.ToString();

        Continue.interactable = CanContinue;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnNewGameButtonClicked()
    {
        IsContinue = false;
        SceneManager.LoadScene("Main");
    }

    public void OnContinueButtonClicked()
    {
        IsContinue = true;
        //GameManager.Instance.DungeLikeCurrentGameData = BinarySaver.LoadCurrentGameData();
        SceneManager.LoadScene("Main");
    }

    public void OnExitGameClicked()
    {
        Application.Quit();
    }
}

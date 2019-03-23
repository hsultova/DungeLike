using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameMenuManager : MonoBehaviour
{
    public Text LevelReached;
    public Text MonstersKilled;
    public Text CellsOpened;

    // Use this for initialization
    void Start()
    {
        var dungeLikeData = BinarySaver.LoadStatisticData();

        LevelReached.text = dungeLikeData.CurrentLevelReached.ToString();
        MonstersKilled.text = dungeLikeData.CurrentMonsterKilled.ToString();
        CellsOpened.text = dungeLikeData.CellsOpened.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBackToMainMenuClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

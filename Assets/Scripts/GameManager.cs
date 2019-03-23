using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public Board Board;
        public Player Player;
        public List<Sprite> MonsterImages;
        public List<DungeLikeHelper.ImageValuePair> GoldImages;
        public List<DungeLikeHelper.ImageValuePair> WeaponImages;
        public Text LevelText;

        public static GameManager Instance { get; private set; }

        public DungeLikeStatisticData DungeLikeStatisticData { get; set; }
        public DungeLikeCurrentGameData DungeLikeCurrentGameData { get; set; }

        public int Level = 1;
        public System.Random Random = new System.Random();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        // Use this for initialization
        void Start()
        {
            if(MainMenuManager.IsContinue)
            {
                DungeLikeCurrentGameData = BinarySaver.LoadCurrentGameData();
                Level = DungeLikeCurrentGameData.Level;
            }

            Initialize();
        }

        public void Initialize()
        {
            LevelText.text = "Level: " + Level;
            Board.InitializeBoard();

            DungeLikeStatisticData = BinarySaver.LoadStatisticData();
        }

        internal void SaveStatisticData()
        {
            DungeLikeStatisticData.DeathCount++;
            DungeLikeStatisticData.CurrentLevelReached = Level;
            if (Level > DungeLikeStatisticData.HighestLevelReached)
                DungeLikeStatisticData.HighestLevelReached = Level;

            BinarySaver.SaveData(DungeLikeStatisticData);
        }

        internal void SaveCurrentGameData()
        {
            DungeLikeCurrentGameData = new DungeLikeCurrentGameData();
            DungeLikeCurrentGameData.PlayerHealth = Player.Health.Value;
            DungeLikeCurrentGameData.PlayerMana = Player.Mana.Value;
            DungeLikeCurrentGameData.PlayerAttack = Player.Attack.Value;
            DungeLikeCurrentGameData.Level = Level;
            DungeLikeCurrentGameData.Gold = Player.Gold.Value;

            BinarySaver.SaveData(DungeLikeCurrentGameData);
        }

        public void OnExit()
        {
            //TODO ConfirmationBox
            MainMenuManager.CanContinue = true;
            SaveCurrentGameData();
            SceneManager.LoadScene("MainMenu");
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public Board Board;
        public Player Player;
        public List<Sprite> MonsterImages;
        public List<DungeLikeHelper.ImageValuePair> MoneyImages;
        public Text LevelText;

        public static GameManager Instance { get; private set; }

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
            Initialize();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Initialize()
        {
            LevelText.text = "Level: " + Level;
            Board.InitializeBoard();
        }
    }
}

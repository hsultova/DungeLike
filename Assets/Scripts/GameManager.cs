using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public Board Board;

        public Player Player;

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
            Board.InitializeBoard();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

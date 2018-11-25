using UnityEngine;

namespace Assets.Scripts
{
    public class Cell : MonoBehaviour
    {
        public SpriteRenderer Content;

        public GameObject Foreground;

        public enum CellType
        {
            Enter,
            Back,
            Empty,
            Monster,
            Key,
            HealthPotion,
            ManaPotion,
            Money,
            Item,
            Spell,
            Shop,
            Weapon,
            IncreaseAttack
        }

        public CellType Type { get; set; }


        private void OnMouseDown()
        {
            Foreground.SetActive(false);
        }

        internal void SetCellType()
        {
            if (HasChance(60, GameManager.Instance.Random))
            {
                Type = CellType.Empty;
                return;
            }
            if (HasChance(40, GameManager.Instance.Random))
            {
                Type = CellType.Monster;
                return;
            }
            if (HasChance(20, GameManager.Instance.Random))
            {
                Type = CellType.HealthPotion;
                return;
            }
            if (HasChance(10, GameManager.Instance.Random))
            {
                Type = CellType.IncreaseAttack;
                return;
            }
            if (HasChance(40, GameManager.Instance.Random))
            {
                Type = CellType.Item;
                return;
            }
            if (HasChance(20, GameManager.Instance.Random))
            {
                Type = CellType.ManaPotion;
                return;
            }
            if (HasChance(30, GameManager.Instance.Random))
            {
                Type = CellType.Weapon;
            }
            if (HasChance(30, GameManager.Instance.Random))
            {
                Type = CellType.Spell;
            }
            if (HasChance(10, GameManager.Instance.Random))
            {
                Type = CellType.Shop;
            }
            else
            {
                Type = CellType.Money;
            }
        }

        private bool HasChance(int percent, System.Random random)
        {
            int randomNumber = random.Next(1, 1000);
            return randomNumber <= percent * 10;
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

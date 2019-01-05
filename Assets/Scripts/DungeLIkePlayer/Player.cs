using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public Sprite Visual;

        public Text HealthText;
        public Text AttackText;
        public Text ManaText;
        public Text MoneyText;
        public SpriteRenderer Weapon;
        public SpriteRenderer Item;

        public Status Health { get; set; }
        public Status Attack { get; set; }
        public Status Mana { get; set; }
        public Status Money { get; set; }

        // Use this for initialization
        void Start()
        {
            //TODO: Gets from charachter selection menu
            Health = new Status(100, 200, 0);
            Attack = new Status(3, 30, 0);
            Mana = new Status(20, 30, 0);
            Money = new Status(50, 1000, 0);

            HealthText.text = Health.Value.ToString();
            AttackText.text = Attack.Value.ToString();
            ManaText.text = Mana.Value.ToString();
            MoneyText.text = Money.Value.ToString();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

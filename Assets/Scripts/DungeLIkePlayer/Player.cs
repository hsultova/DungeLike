using System;
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
        public Text GoldText;
        public SpriteRenderer Weapon;
        public SpriteRenderer Item;

        public Status Health { get; set; }
        public Status Attack { get; set; }
        public Status Mana { get; set; }
        public Status Gold { get; set; }

        private int _lastWeaponAttack = 0;
        public int LastWeaponAttack
        {
            get { return _lastWeaponAttack; }
            set { _lastWeaponAttack = value; }
        }

        // Use this for initialization
        void Start()
        {

            if (MainMenuManager.IsContinue)
            {
                GameManager.Instance.DungeLikeCurrentGameData = BinarySaver.LoadCurrentGameData();
                //TODO:Refactor  Gets from charachter selection menu

                Gold = new Status(GameManager.Instance.DungeLikeCurrentGameData.Gold, 1000, 0);
                Health = new Status(GameManager.Instance.DungeLikeCurrentGameData.PlayerHealth, 200, 0);
                Mana = new Status(GameManager.Instance.DungeLikeCurrentGameData.PlayerMana, 30, 0);
                Attack = new Status(GameManager.Instance.DungeLikeCurrentGameData.PlayerAttack, 30, 0);
            }
            else
            {
                //TODO: Gets from charachter selection menu
                Health = new Status(100, 200, 0);
                Attack = new Status(3, 30, 0);
                Mana = new Status(20, 30, 0);
                Gold = new Status(50, 1000, 0);
            }

            HealthText.text = Health.Value.ToString();
            AttackText.text = Attack.Value.ToString();
            ManaText.text = Mana.Value.ToString();
            GoldText.text = Gold.Value.ToString();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void UpdateAttackText()
        {
            AttackText.text = Attack.Value.ToString();
        }

        public bool IsPlayerDead()
        {
            return Health.Value <= Health.Minimum;
        }
    }
}

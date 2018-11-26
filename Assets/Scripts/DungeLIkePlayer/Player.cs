﻿using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public Sprite Visual;

        public Text HealthText;
        public Text AttackText;
        public Text ManaText;

        public Health Health { get; set; }
        public Attack Attack { get; set; }
        public Mana Mana { get; set; }

        // Use this for initialization
        void Start()
        {
            //TODO: Gets from charachter selection menu
            Health = new Health {Value = 200};
            Attack = new Attack { Value = 1 };
            Mana = new Mana { Value = 20 };

            HealthText.text = Health.Value.ToString();
            AttackText.text = Attack.Value.ToString();
            ManaText.text = Mana.Value.ToString();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
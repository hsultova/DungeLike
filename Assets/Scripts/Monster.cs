using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class Monster
    {
        public TextMesh HealthTextMesh;
        public TextMesh AttackTextMesh;

        public Sprite Visual { get; private set; }
        public Status Health { get; private set; }
        public Status Attack { get; private set; }

        public Monster()
        {
            int randomImageIndex = Random.Range(0, GameManager.Instance.MonsterImages.Count);
            Visual = GameManager.Instance.MonsterImages.ElementAt(randomImageIndex);

            int randomHealth = Random.Range(2 + 2 * GameManager.Instance.Level, 10 + 2 * GameManager.Instance.Level);
            Health = new Status(randomHealth, randomHealth, 0);

            int randomAttack = Random.Range(1 + 2 * GameManager.Instance.Level, 5 + 2 * GameManager.Instance.Level);
            Attack = new Status(randomAttack, randomAttack, 0);
        }
    }
}

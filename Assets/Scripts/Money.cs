using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class Money
    {
        public Sprite Visual { get; private set; }
        public int Value { get; private set; }

        public Money()
        {
            int randomImageIndex = Random.Range(0, GameManager.Instance.MonsterImages.Count);
            var pair = GameManager.Instance.MoneyImages.ElementAt(randomImageIndex);
            Visual = pair.Image;
            Value = pair.Value;
        }
    }
}

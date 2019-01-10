using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class Weapon
    {
        public Sprite Visual { get; private set; }
        public int Value { get; private set; }

        public Weapon()
        {
            int randomImageIndex = Random.Range(0, GameManager.Instance.WeaponImages.Count);
            var pair = GameManager.Instance.WeaponImages.ElementAt(randomImageIndex);
            Visual = pair.Image;
            Value = pair.Value;
        }
    }
}

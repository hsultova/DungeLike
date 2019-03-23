using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class Gold
    {
        public Sprite Visual { get; private set; }
        public int Value { get; private set; }

        public Gold()
        {
            int randomImageIndex = Random.Range(0, GameManager.Instance.GoldImages.Count);
            var pair = GameManager.Instance.GoldImages.ElementAt(randomImageIndex);
            Visual = pair.Image;
            Value = pair.Value;
        }
    }
}

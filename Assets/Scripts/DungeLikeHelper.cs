using UnityEngine;

namespace Assets.Scripts
{
    public static class DungeLikeHelper
    {
        [System.Serializable]
        public class ImageDictionary
        {
            public CellType CellType;
            public Sprite Image;
        }

        [System.Serializable]
        public class ImageValuePair
        {
            public int Value;
            public Sprite Image;
        }
    }
}

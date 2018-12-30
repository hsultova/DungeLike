using System.Collections;
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

        /// <summary>
        /// Shows GameObject for seconds
        /// </summary>
        public static IEnumerator ShowForSeconds(GameObject gameObject)
        {
            gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            gameObject.SetActive(false);
        }
    }
}

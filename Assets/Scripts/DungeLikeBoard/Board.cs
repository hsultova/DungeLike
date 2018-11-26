using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    public class Board : MonoBehaviour
    {
        public List<DungeLikeHelper.ImageDictionary> Images;

        public Tile[] Tiles;

        public void InitializeBoard()
        {
            var index = 0;
            Tiles = new Tile[transform.childCount];
            foreach (Transform child in transform)
            {
                var cell = child.GetComponent<Tile>();
                Tiles[index] = cell;
                index++;
            }

            Tile firstTile = Tiles[0];
            firstTile.SetEnterType();
            firstTile.Content.sprite = Images.Find(pair => pair.CellType.Equals(firstTile.GetCellType())).Image;
            firstTile.Foreground.SetActive(false);

            int keyIndex = Random.Range(0, transform.childCount);
            Tile keyTile = Tiles[keyIndex];
            keyTile.SetKeyType();
            keyTile.Content.sprite = Images.Find(pair => pair.CellType.Equals(keyTile.GetCellType())).Image;

            for (int i = 1; i < Tiles.Length; i++)
            {
                if (i == keyIndex)
                    continue;

                var tile = Tiles[i];
                tile.SetCellType();
                tile.Content.sprite = Images.Find(pair => pair.CellType.Equals(tile.GetCellType())).Image;
            }
        }
    }
}

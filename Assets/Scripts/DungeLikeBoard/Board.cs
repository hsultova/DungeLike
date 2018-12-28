using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Board : MonoBehaviour
    {
        public List<DungeLikeHelper.ImageDictionary> Images;

        /// <summary>
        /// Tiles which are UI representation of the cells
        /// </summary>
        public Tile[] Tiles;

        /// <summary>
        /// Initializes board of tiles. Fill tiles structure.
        /// Generates enter, key and other tiles. Sets corresponding images.
        /// </summary>
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
            keyTile.OpenCell += OnOpenCell;

            for (int i = 1; i < Tiles.Length; i++)
            {
                if (i == keyIndex)
                    continue;

                var tile = Tiles[i];
                tile.SetCellType();
                tile.Content.sprite = Images.Find(pair => pair.CellType.Equals(tile.GetCellType())).Image;
                tile.OpenCell += OnOpenCell;
            }
        }

        private void OnOpenCell()
        {
            SetSelectableCells();
        }

        /// <summary>
        /// Sets cells to be selectable if they are neighbours to enter cell or open cell
        /// </summary>
        public void SetSelectableCells()
        {
            foreach (var tile in Tiles)
            {
                if (tile.GetCellType() == CellType.Enter || tile.IsOpen)
                {
                    SetSelectableCell(tile.transform.position, Vector3.up);
                    SetSelectableCell(tile.transform.position, Vector3.down);
                    SetSelectableCell(tile.transform.position, Vector3.right);
                    SetSelectableCell(tile.transform.position, Vector3.left);
                }
            }
        }

        private void SetSelectableCell(Vector3 position, Vector3 direction)
        {
            RaycastHit hit;
            Physics.Raycast(position, direction, out hit, 2);

            if (hit.collider != null)
            {
                Tile tile = hit.collider.gameObject.GetComponent<Tile>();

                if (tile == null)
                    return;

                tile.IsSelectable = true;
                tile.Foreground.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
}

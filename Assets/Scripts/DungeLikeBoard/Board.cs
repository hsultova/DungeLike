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
            Clear();

            var index = 0;
            Tiles = new Tile[transform.childCount];
            foreach (Transform child in transform)
            {
                var cell = child.GetComponent<Tile>();
                Tiles[index] = cell;
                index++;
            }

            //TODO: Generate first tile on random position ana rename it to enter tile
            Tile firstTile = Tiles[0];
            firstTile.SetEnterType();
            firstTile.Content.sprite = Images.Find(pair => pair.CellType.Equals(firstTile.GetCellType())).Image;
            firstTile.Foreground.SetActive(false);
            SetSelectableCells(firstTile);

            //TODO: Check keyIndex to be different of first tile index
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
                tile.MonsterKilled += OnMonsterKilled;
            }
        }

        /// <summary>
        /// Clears the board. Sets it to initial state
        /// </summary>
        public void Clear()
        {
            foreach (var tile in Tiles)
            {
                tile.Content.sprite = null;
                tile.Foreground.SetActive(true);
                tile.Foreground.GetComponent<SpriteRenderer>().color = Color.grey;
                tile.Locked.SetActive(false);

                tile.HealthStatusText.gameObject.SetActive(false);
                tile.AttackStatusText.gameObject.SetActive(false);

                tile.IsOpen = false;
                tile.IsSelectable = false;
                tile.IsLocked = false;
            }
        }

        /// <summary>
        /// Validate board
        /// </summary>
        public void Validate()
        {
            foreach (var tile in Tiles)
            {
                //Lock cells around open monsters
                if (tile.GetCellType() == CellType.Monster && tile.IsOpen)
                {
                    LockCell(tile.transform.position, Vector3.up);
                    LockCell(tile.transform.position, Vector3.down);
                    LockCell(tile.transform.position, Vector3.right);
                    LockCell(tile.transform.position, Vector3.left);
                    LockCell(tile.transform.position, Vector3.left + Vector3.down);
                    LockCell(tile.transform.position, Vector3.left + Vector3.up);
                    LockCell(tile.transform.position, Vector3.right + Vector3.down);
                    LockCell(tile.transform.position, Vector3.right + Vector3.up);
                }
            }
        }

        private void OnOpenCell(Tile tile)
        {
            SetSelectableCells(tile);
        }

        /// <summary>
        /// Callback when a monster is killed. Unlock all cells around the monster.
        /// </summary>
        /// <param name="tile">Tile with killed monster</param>
        private void OnMonsterKilled(Tile tile)
        {
            if (tile.GetCellType() != CellType.Monster)
                return;
            UnlockCell(tile.transform.position, Vector3.up);
            UnlockCell(tile.transform.position, Vector3.down);
            UnlockCell(tile.transform.position, Vector3.right);
            UnlockCell(tile.transform.position, Vector3.left);
            UnlockCell(tile.transform.position, Vector3.left + Vector3.down);
            UnlockCell(tile.transform.position, Vector3.left + Vector3.up);
            UnlockCell(tile.transform.position, Vector3.right + Vector3.down);
            UnlockCell(tile.transform.position, Vector3.right + Vector3.up);
        }

        /// <summary>
        /// Sets cells to be selectable if they are neighbours to enter cell or open cell
        /// </summary>
        private void SetSelectableCells(Tile tile)
        {
            SetSelectableCell(tile.transform.position, Vector3.up);
            SetSelectableCell(tile.transform.position, Vector3.down);
            SetSelectableCell(tile.transform.position, Vector3.right);
            SetSelectableCell(tile.transform.position, Vector3.left);
        }

        /// <summary>
        /// Sets cell to be possible for selection. Change foreground color.
        /// </summary>
        private void SetSelectableCell(Vector3 position, Vector3 direction)
        {
            Tile tile = GetNeighbourTile(position, direction);

            if (tile == null)
                return;

            if (!tile.IsLocked)
            {
                tile.IsSelectable = true;
                tile.Foreground.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }

        /// <summary>
        /// Locks cell by given direction
        /// </summary>
        /// <param name="position">Tile position around which tiles should be locked</param>
        /// <param name="direction">Direction to the tile to be locked</param>
        private void LockCell(Vector3 position, Vector3 direction)
        {
            Tile tile = GetNeighbourTile(position, direction);
            if (tile == null || tile.IsOpen)
                return;

            tile.IsLocked = true;
            if (tile.GetCellType() != CellType.Enter)
                tile.Locked.SetActive(true);
        }

        /// <summary>
        /// Unlocks cell by given direction
        /// </summary>
        /// <param name="position">Tile position around which tiles should be unlocked</param>
        /// <param name="direction">Direction to the tile to be unlocked</param>
        private void UnlockCell(Vector3 position, Vector3 direction)
        {
            Tile tile = GetNeighbourTile(position, direction);
            if (tile == null || tile.IsOpen)
                return;

            tile.IsLocked = false;
            if (tile.GetCellType() != CellType.Enter)
                tile.Locked.SetActive(false);
        }

        /// <summary>
        /// Gets neighbour tile by direction
        /// </summary>
        /// <param name="position">Tile position</param>
        /// <param name="direction">Direction to get tile</param>
        /// <returns>Neighbour tile if found otherwise null</returns>
        private Tile GetNeighbourTile(Vector3 position, Vector3 direction)
        {
            RaycastHit hit;
            Physics.Raycast(position, direction, out hit, 2);

            Tile tile = null;
            if (hit.collider != null)
            {
                tile = hit.collider.gameObject.GetComponent<Tile>();
            }
            return tile;
        }
    }
}

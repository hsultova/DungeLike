using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Board : MonoBehaviour
    {
        [System.Serializable]
        public class ImageDictionary
        {
            public Cell.CellType CellType;
            public Sprite Image;
        }

        public List<ImageDictionary> Images;

        public Cell[] Cells;

        public void InitializeBoard()
        {
            var index = 0;
            Cells = new Cell[transform.childCount];
            foreach (Transform child in transform)
            {
                var cell = child.GetComponent<Cell>();
                Cells[index] = cell;
                index++;
            }

            Cell firstCell = Cells[0];
            firstCell.Type = Cell.CellType.Enter;
            firstCell.Content.sprite = Images.Find(pair => pair.CellType.Equals(firstCell.Type)).Image;

            int keyIndex = Random.Range(0, transform.childCount);
            Cell keyCell = Cells[keyIndex];
            keyCell.Type = Cell.CellType.Key;
            keyCell.Content.sprite = Images.Find(pair => pair.CellType.Equals(keyCell.Type)).Image;

            for (int i = 1; i < Cells.Length; i++)
            {
                if (i == keyIndex)
                    continue;

                var cell = Cells[i];
                cell.SetCellType();
                cell.Content.sprite = Images.Find(pair => pair.CellType.Equals(cell.Type)).Image;
            }
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

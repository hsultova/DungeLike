using System;
using Assets.Scripts.DungeLikeBoard;
using UnityEngine;

namespace Assets.Scripts
{
    public enum CellType
    {
        Enter,
        Back,
        Empty,
        Monster,
        Key,
        HealthPotion,
        ManaPotion,
        Money,
        Item,
        Spell,
        Shop,
        Weapon,
        IncreaseAttack
    }

    public class Tile : MonoBehaviour
    {
        public SpriteRenderer Content;
        public GameObject Foreground;
        public GameObject Locked;
        public TextMesh HealthStatusText;
        public TextMesh AttackStatusText;
        public TextMesh MoneyToAddText;
        public TextMesh HealthToAddText;
        public TextMesh ManaToAddText;

        private CellBase _baseCell;

        public bool IsOpen { get; set; }
        public bool IsSelectable { get; set; }
        public bool IsLocked { get; set; }

        /// <summary>
        /// Callback invoked when a cell is selected
        /// </summary>
        public Action<Tile> OpenCell;
        public Action<Tile> MonsterKilled;

        private void OnMouseDown()
        {
            if (!IsSelectable || IsLocked)
                return;

            if (Foreground.activeSelf)
            {
                Foreground.SetActive(false);
                IsOpen = true;

                if (OpenCell != null)
                {
                    OpenCell.Invoke(this);
                }

                _baseCell.UpdateStatusText();
            }
            else if (GetCellType() != CellType.Enter)
            {
                _baseCell.DoAction();
                if (_baseCell.CanRemoveContent())
                {
                    if (GetCellType() == CellType.Monster)
                    {
                        if (MonsterKilled != null)
                        {
                            MonsterKilled.Invoke(this);
                        }
                    }
                    Content.sprite = null;
                    HealthStatusText.gameObject.SetActive(false);
                    AttackStatusText.gameObject.SetActive(false);
                    _baseCell = new CellBase();
                }
            }

            GameManager.Instance.Board.Validate();
        }

        /// <summary>
        /// Sets the cell type. Each cell type is determined by chance.
        /// </summary>
        internal void SetCellType()
        {
            if (HasChance(60, GameManager.Instance.Random))
            {
                _baseCell = new CellBase();
                return;
            }
            if (HasChance(40, GameManager.Instance.Random))
            {
                var monsterCell = new MonsterCell(this);
                _baseCell = monsterCell;
                monsterCell.UpdateStatusText();
                return;
            }
            if (HasChance(20, GameManager.Instance.Random))
            {
                _baseCell = new MoneyCell(this);
                return;
            }
            if (HasChance(10, GameManager.Instance.Random))
            {
                _baseCell = new IncreaseAttackCell();
                return;
            }
            if (HasChance(40, GameManager.Instance.Random))
            {
                _baseCell = new ItemCell(this);
                return;
            }
            if (HasChance(20, GameManager.Instance.Random))
            {
                _baseCell = new ManaPotionCell(this);
                return;
            }
            if (HasChance(30, GameManager.Instance.Random))
            {
                _baseCell = new WeaponCell(this);
                return;
            }
            if (HasChance(30, GameManager.Instance.Random))
            {
                _baseCell = new SpellCell();
                return;
            }
            if (HasChance(10, GameManager.Instance.Random))
            {
                _baseCell = new ShopCell();
            }
            else
            {
                _baseCell = new HealthPotionCell(this);
            }
        }

        /// <summary>
        /// Gets type of the cell
        /// </summary>
        /// <returns></returns>
        internal CellType GetCellType()
        {
            return _baseCell.Type;
        }

        internal void SetEnterType()
        {
            _baseCell = new EnterCell();
        }

        internal void SetKeyType()
        {
            _baseCell = new KeyCell();
        }

        private bool HasChance(int percent, System.Random random)
        {
            int randomNumber = random.Next(1, 1000);
            return randomNumber <= percent * 10;
        }
    }
}

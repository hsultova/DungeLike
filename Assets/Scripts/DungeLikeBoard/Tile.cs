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

        private CellBase _baseCell;

        private void OnMouseDown()
        {
            if (Foreground.activeSelf)
            {
                Foreground.SetActive(false);
            }
            else if(GetCellType() != CellType.Enter)
            {
                _baseCell.DoAction();
                Content.sprite = null;
            }
        }

        internal void SetCellType()
        {
            if (HasChance(60, GameManager.Instance.Random))
            {
                _baseCell = new CellBase();
                return;
            }
            if (HasChance(40, GameManager.Instance.Random))
            {
                _baseCell = new MonsterCell();
                return;
            }
            if (HasChance(20, GameManager.Instance.Random))
            {
                _baseCell = new HealthPotionCell();
                return;
            }
            if (HasChance(10, GameManager.Instance.Random))
            {
                _baseCell = new IncreaseAttackCell();
                return;
            }
            if (HasChance(40, GameManager.Instance.Random))
            {
                _baseCell = new ItemCell();
                return;
            }
            if (HasChance(20, GameManager.Instance.Random))
            {
                _baseCell = new ManaPotionCell();
                return;
            }
            if (HasChance(30, GameManager.Instance.Random))
            {
                _baseCell = new WeaponCell();
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
                _baseCell = new MoneyCell();
            }
        }

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

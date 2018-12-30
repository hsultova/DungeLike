using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class ManaPotionCell : CellBase
    {
        private readonly Player _player = GameManager.Instance.Player;
        private readonly Tile _tile;

        public ManaPotionCell(Tile tile)
        {
            _tile = tile;
            Type = CellType.ManaPotion;
        }

        public override void DoAction()
        {
            base.DoAction();

            //Restore player mana
            //Value to restore depends on the level
            int manaToRestore = Random.Range(1, Math.Max(2, 10 - 2 * GameManager.Instance.Level));
            _player.Mana.AddValue(manaToRestore);
            _player.ManaText.text = _player.Mana.Value.ToString();
            _tile.ManaToAddText.text = "Mana + " + manaToRestore;
            _tile.StartCoroutine(DungeLikeHelper.ShowForSeconds(_tile.ManaToAddText.gameObject));
        }
    }
}

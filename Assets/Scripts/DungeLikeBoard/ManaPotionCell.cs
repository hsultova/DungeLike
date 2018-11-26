using System;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class ManaPotionCell : CellBase
    {
        private readonly Player _player = GameManager.Instance.Player;

        public ManaPotionCell()
        {
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
        }
    }
}

using System;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class HealthPotionCell : CellBase
    {
        private readonly Player _player = GameManager.Instance.Player;
        public HealthPotionCell()
        {
            Type = CellType.HealthPotion;
        }

        public override void DoAction()
        {
            base.DoAction();

            //Restore player health
            //Value to restore depends on the level
            int helathToRestore = Random.Range(3, Math.Max(5, 20 - 2* GameManager.Instance.Level));
            _player.Health.AddValue(helathToRestore);
            _player.HealthText.text = _player.Health.Value.ToString();
        }
    }
}

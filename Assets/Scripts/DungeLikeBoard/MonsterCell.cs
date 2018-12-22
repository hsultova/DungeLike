using UnityEngine;

namespace Assets.Scripts
{
    public class MonsterCell : CellBase
    {
        private readonly Player _player = GameManager.Instance.Player;
        private readonly Monster _monster;

        public TextMesh StatusText { get; set; }

        public MonsterCell()
        {
            _monster = new Monster();
            Type = CellType.Monster;
            GameManager.Instance.Board.Images.Find(pair => pair.CellType.Equals(Type)).Image = _monster.Visual;
        }

        /// <summary>
        /// Updates the text of all statuses
        /// </summary>
        public void UpdateStatusText()
        {
            StatusText.text = _monster.Health.Value.ToString();
        }

        public override void DoAction()
        {
            base.DoAction();
            //Battle
            _monster.Health.RemoveValue(_player.Attack.Value);
            UpdateStatusText();
            _player.Health.RemoveValue(_monster.Attack.Value);
            _player.HealthText.text = _player.Health.Value.ToString();
        }

        public override bool CanRemoveContent()
        {
            return IsMonsterDead();
        }

        private bool IsMonsterDead()
        {
            return _monster.Health.Value <= _monster.Health.Minimum;
        }
    }
}

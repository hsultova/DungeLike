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
            // TODO: Restore player health
            _player.Health.Value += 10;
            _player.HealthText.text = _player.Health.Value.ToString();
        }
    }
}

namespace Assets.Scripts
{
    public class IncreaseAttackCell : CellBase
    {
        private readonly Player _player = GameManager.Instance.Player;

        public IncreaseAttackCell()
        {
            Type = CellType.IncreaseAttack;
        }

        public override void DoAction()
        {
            base.DoAction();
            //Increase player attack
            int attackForIncrease = 1;
            _player.Attack.AddValue(attackForIncrease);
            _player.UpdateAttackText();
        }
    }
}

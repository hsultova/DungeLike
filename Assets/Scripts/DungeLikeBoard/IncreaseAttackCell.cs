namespace Assets.Scripts
{
    public class IncreaseAttackCell : CellBase
    {
        public IncreaseAttackCell()
        {
            Type = CellType.IncreaseAttack;
        }

        public override void DoAction()
        {
            base.DoAction();
            // TODO: Increase player attack
        }
    }
}

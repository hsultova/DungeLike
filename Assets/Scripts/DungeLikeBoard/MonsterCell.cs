namespace Assets.Scripts
{
    public class MonsterCell : CellBase
    {
        public MonsterCell()
        {
            Type = CellType.Monster;
        }

        public override void DoAction()
        {
            base.DoAction();
            // TODO: Battle
        }
    }
}

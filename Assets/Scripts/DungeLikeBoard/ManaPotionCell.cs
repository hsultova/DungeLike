namespace Assets.Scripts
{
    public class ManaPotionCell : CellBase
    {
        public ManaPotionCell()
        {
            Type = CellType.ManaPotion;
        }

        public override void DoAction()
        {
            base.DoAction();
            // TODO: Restore player mana
        }
    }
}

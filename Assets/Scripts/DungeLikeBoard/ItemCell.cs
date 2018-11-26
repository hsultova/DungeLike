namespace Assets.Scripts
{
    public class ItemCell : CellBase
    {
        public ItemCell()
        {
            Type = CellType.Item;
        }

        public override void DoAction()
        {
            base.DoAction();
            // TODO: Add item to the equip
        }
    }
}

namespace Assets.Scripts
{
    public class ItemCell : CellBase
    {
        private readonly Player _player = GameManager.Instance.Player;
        private readonly Tile _tile;

        public ItemCell(Tile tile)
        {
            _tile = tile;
            Type = CellType.Item;
        }

        public override void DoAction()
        {
            base.DoAction();
            //Add item to the equip

            _player.Item.sprite = _tile.Content.sprite;
        }
    }
}

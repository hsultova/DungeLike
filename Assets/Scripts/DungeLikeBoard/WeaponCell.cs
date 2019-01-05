namespace Assets.Scripts
{
    public class WeaponCell : CellBase
    {
        private readonly Player _player = GameManager.Instance.Player;
        private readonly Tile _tile;

        public WeaponCell(Tile tile)
        {
            _tile = tile;
            Type = CellType.Weapon;
        }

        public override void DoAction()
        {
            base.DoAction();
            //Add weapon to the equip

            _player.Weapon.sprite = _tile.Content.sprite;
        }
    }
}

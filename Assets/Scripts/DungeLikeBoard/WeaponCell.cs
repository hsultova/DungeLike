namespace Assets.Scripts
{
    public class WeaponCell : CellBase
    {
        private readonly Player _player = GameManager.Instance.Player;
        private readonly Tile _tile;
        private readonly Weapon _weapon;

        public WeaponCell(Tile tile)
        {
            _tile = tile;
            _weapon = new Weapon();
            Type = CellType.Weapon;
            GameManager.Instance.Board.Images.Find(pair => pair.CellType.Equals(Type)).Image = _weapon.Visual;
        }

        public override void DoAction()
        {
            base.DoAction();
            //Add weapon to the equip

            _player.Attack.RemoveValue(_player.LastWeaponAttack);
            _player.LastWeaponAttack = _weapon.Value;
            _player.Attack.AddValue(_weapon.Value);
            _player.UpdateAttackText();
            _player.Weapon.sprite = _tile.Content.sprite;
        }
    }
}

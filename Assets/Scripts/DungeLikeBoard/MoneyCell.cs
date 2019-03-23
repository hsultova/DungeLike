namespace Assets.Scripts
{
    public class GoldCell : CellBase
    {
        private readonly Player _player = GameManager.Instance.Player;
        private readonly Gold _gold;
        private readonly Tile _tile;

        public GoldCell(Tile tile)
        {
            _tile = tile;
            _gold = new Gold();
            Type = CellType.Gold;
            GameManager.Instance.Board.Images.Find(pair => pair.CellType.Equals(Type)).Image = _gold.Visual;
        }

        public override void DoAction()
        {
            base.DoAction();

            int goldToAdd = _gold.Value;
            _player.Gold.AddValue(goldToAdd);
            _player.GoldText.text = _player.Gold.Value.ToString();
            _tile.GoldToAddText.text = "Coins + " + goldToAdd;
            _tile.StartCoroutine(DungeLikeHelper.ShowForSeconds(_tile.GoldToAddText.gameObject));
        }
    }
}

namespace Assets.Scripts
{
    public class MoneyCell : CellBase
    {
        private readonly Player _player = GameManager.Instance.Player;
        private readonly Money _money;

        public MoneyCell()
        {
            _money = new Money();
            Type = CellType.Money;
            GameManager.Instance.Board.Images.Find(pair => pair.CellType.Equals(Type)).Image = _money.Visual;
        }

        public override void DoAction()
        {
            base.DoAction();

            int moneyToAdd = _money.Value;
            _player.Money.AddValue(moneyToAdd);
            _player.MoneyText.text = _player.Money.Value.ToString();
        }
    }
}

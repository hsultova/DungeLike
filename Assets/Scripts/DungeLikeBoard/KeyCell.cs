namespace Assets.Scripts.DungeLikeBoard
{
    public class KeyCell :CellBase
    {
        public KeyCell()
        {
            Type = CellType.Key;
        }

        public override void DoAction()
        {
            base.DoAction();

            GameManager.Instance.Level++;
            GameManager.Instance.Initialize();
        }
    }
}

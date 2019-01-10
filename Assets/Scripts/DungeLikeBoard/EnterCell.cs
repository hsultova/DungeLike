namespace Assets.Scripts
{
    public class EnterCell : CellBase
    {
        public EnterCell()
        {
            Type = CellType.Enter;
        }

        public override void DoAction()
        {
            base.DoAction();
            //Load next level
            GameManager.Instance.Level++;
            GameManager.Instance.Initialize();
        }
    }
}

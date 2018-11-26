namespace Assets.Scripts
{ 
    public class CellBase
    {
        public CellBase()
        {
            Type = CellType.Empty;
        }
      
        public CellType Type { get; set; }

        public virtual void DoAction()
        {

        }
    }
}

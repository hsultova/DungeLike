namespace Assets.Scripts
{ 
    public class CellBase
    {
        public CellBase()
        {
            Type = CellType.Empty;
        }
      
        public CellType Type { get; set; }

        /// <summary>
        /// </summary>
        public virtual void DoAction()
        {

        }

        /// <summary>
        /// Determines if the cell content can be removed such as sprite, text...
        /// Default state is that the content can be removed.
        /// </summary>
        /// <returns>True if the content can be removed, otherwise false</returns>
        public virtual bool CanRemoveContent()
        {
            return true;
        }
    }
}

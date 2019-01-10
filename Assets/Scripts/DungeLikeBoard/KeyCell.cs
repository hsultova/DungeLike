using System.Linq;

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
            var enterTile = GameManager.Instance.Board.Tiles.SingleOrDefault(tile => tile.GetCellType() == CellType.Enter);
            if(enterTile != null)
            {
                enterTile.Content.sprite = GameManager.Instance.Board.UnlockedDoor;
                enterTile.IsOpen = true;
            }
        }
    }
}

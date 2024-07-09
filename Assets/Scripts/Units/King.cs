using System.Collections.Generic;
using UnityEngine;

public class King : BaseUnit
{
    public override List<Vector2> AttackRange()
    {
        throw new System.NotImplementedException();
    }

    public override List<Vector2> MoveRange()
    {
        var moveList = new List<Vector2>();
        var fromPos = new Vector2(this.transform.position.x, this.transform.position.y);
        if (fromPos.x - 1 >= 0 && GridManager.Instance.GetTileAtPosotion(new Vector2(fromPos.x - 1, fromPos.y)).OccupiedUnit == null)
        {
            moveList.Add(new Vector2(fromPos.x - 1, fromPos.y));
        }
        if (fromPos.x + 1 < 8 && GridManager.Instance.GetTileAtPosotion(new Vector2(fromPos.x + 1, fromPos.y)).OccupiedUnit == null)
        {
            moveList.Add(new Vector2(fromPos.x + 1, fromPos.y));
        }
        if (fromPos.y - 1 >= 0 && GridManager.Instance.GetTileAtPosotion(new Vector2(fromPos.x, fromPos.y - 1)).OccupiedUnit == null)
        {
            moveList.Add(new Vector2(fromPos.x, fromPos.y - 1));
        }
        if (fromPos.y + 1 < 8 && GridManager.Instance.GetTileAtPosotion(new Vector2(fromPos.x, fromPos.y + 1)).OccupiedUnit == null)
        {
            moveList.Add(new Vector2(fromPos.x, fromPos.y + 1));
        }

        if (fromPos.x - 1 >= 0 && fromPos.y - 1 >= 0 && GridManager.Instance.GetTileAtPosotion(new Vector2(fromPos.x - 1, fromPos.y - 1)).OccupiedUnit == null)
        {
            moveList.Add(new Vector2(fromPos.x - 1, fromPos.y - 1));
        }
        if (fromPos.x + 1 < 8 && fromPos.y + 1 < 8 && GridManager.Instance.GetTileAtPosotion(new Vector2(fromPos.x + 1, fromPos.y + 1)).OccupiedUnit == null)
        {
            moveList.Add(new Vector2(fromPos.x + 1, fromPos.y + 1));
        }
        if (fromPos.y - 1 >= 0 && fromPos.x + 1 < 8 && GridManager.Instance.GetTileAtPosotion(new Vector2(fromPos.x + 1, fromPos.y - 1)).OccupiedUnit == null)
        {
            moveList.Add(new Vector2(fromPos.x + 1, fromPos.y - 1));
        }
        if (fromPos.y + 1 < 8 && fromPos.x - 1 >= 0 && GridManager.Instance.GetTileAtPosotion(new Vector2(fromPos.x - 1, fromPos.y + 1)).OccupiedUnit == null)
        {
            moveList.Add(new Vector2(fromPos.x - 1, fromPos.y + 1));
        }
        return moveList;
    }
}

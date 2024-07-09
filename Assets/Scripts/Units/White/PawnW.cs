using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class PawnW : BaseWhite, MoveInterface
{
    public override List<Vector2> MoveRange()
    {
        var moveList = new List<Vector2>();
        var fromPos = this.transform.position;
        if (this.transform.position.y == 1)
        {
            if (GridManager.Instance.GetTileAtPosotion(new Vector2(fromPos.x, fromPos.y + 1)).OccupiedUnit == null)
            {
                moveList.Add(new Vector2(fromPos.x, fromPos.y + 1));
                if (GridManager.Instance.GetTileAtPosotion(new Vector2(fromPos.x, fromPos.y + 2)).OccupiedUnit == null)
                {
                    moveList.Add(new Vector2(fromPos.x, fromPos.y + 2));

                }
            }
            return moveList;
        }
        else
        {
            if (GridManager.Instance.GetTileAtPosotion(new Vector2(fromPos.x, fromPos.y + 1)).OccupiedUnit == null)
            {
                moveList.Add(new Vector2(fromPos.x, fromPos.y + 1));

            }
            return moveList;
        }

    }

    public override List<Vector2> AttackRange()
    {
        var attackList = new List<Vector2>();
        var fromPos = this.transform.position;
        if (fromPos.x + 1 < 8 && fromPos.y + 1 < 8 && GridManager.Instance.GetTileAtPosotion(new Vector2(fromPos.x + 1, fromPos.y + 1)).OccupiedUnit != null && GridManager.Instance.GetTileAtPosotion(new Vector2(fromPos.x + 1, fromPos.y + 1)).OccupiedUnit.Faction != this.Faction)
        {
            attackList.Add(new Vector2(fromPos.x + 1, fromPos.y + 1));
        }
        if (fromPos.x - 1 >= 0 && fromPos.y + 1 < 8 && GridManager.Instance.GetTileAtPosotion(new Vector2(fromPos.x - 1, fromPos.y + 1)).OccupiedUnit != null && GridManager.Instance.GetTileAtPosotion(new Vector2(fromPos.x - 1, fromPos.y + 1)).OccupiedUnit.Faction != this.Faction)
        {
            attackList.Add(new Vector2(fromPos.x - 1, fromPos.y + 1));
        }
        return attackList;
    }
}
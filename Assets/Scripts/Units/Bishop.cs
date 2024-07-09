using System.Collections.Generic;
using UnityEngine;

internal class Bishop : BaseUnit
{
    public override List<Vector2> AttackRange()
    {
        throw new System.NotImplementedException();
    }

    public override List<Vector2> MoveRange()
    {
        var moveList = new List<Vector2>();
        var fromPos = new Vector2(this.transform.position.x, this.transform.position.y);
        for (var i = 1; i < 8; i++)
        {
            if (fromPos.x - i >= 0 && fromPos.y - i >= 0 && GridManager.Instance.GetTileAtPosotion(new Vector2(fromPos.x - i, fromPos.y - i)).OccupiedUnit == null)
            {
                moveList.Add(new Vector2(fromPos.x - i, fromPos.y - i));
            }
            else
            {
                break;
            }
        }
        for (var i = 1; i < 8; i++)
        {
            if (fromPos.x + i < 8 && fromPos.y + i < 8 && GridManager.Instance.GetTileAtPosotion(new Vector2(fromPos.x + i, fromPos.y + i)).OccupiedUnit == null)
            {
                moveList.Add(new Vector2(fromPos.x + i, fromPos.y + i));
            }
            else
            {
                break;
            }
        }
        for (var i = 1; i < 8; i++)
        {
            if (fromPos.y - i >= 0 && fromPos.x + i < 8 && GridManager.Instance.GetTileAtPosotion(new Vector2(fromPos.x + i, fromPos.y - i)).OccupiedUnit == null)
            {
                moveList.Add(new Vector2(fromPos.x + i, fromPos.y - i));
            }
            else
            {
                break;
            }
        }
        for (var i = 1; i < 8; i++)
        {
            if (fromPos.y + i < 8 && fromPos.x - i >= 0 && GridManager.Instance.GetTileAtPosotion(new Vector2(fromPos.x - i, fromPos.y + i)).OccupiedUnit == null)
            {
                moveList.Add(new Vector2(fromPos.x - i, fromPos.y + i));
            }
            else
            {
                break;
            }
        }
        return moveList;
    }
}


using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWhite : BaseUnit, MoveInterface
{
    public abstract override List<Vector2> MoveRange();
    public abstract override List<Vector2> AttackRange();
}
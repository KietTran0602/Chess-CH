using UnityEngine;

[CreateAssetMenu(fileName = "New unit", menuName = "Scriptable unit")]
public class ScriptableUnit : ScriptableObject
{
    public Faction Faction;
    public PieceName PieceName;
    public BaseUnit unitPrefab;
}

public enum Faction
{
    white = 0,
    black = 1
}
public enum PieceName
{
    Pawn,
    Rook,
    Bishop,
    Knight,
    Queen,
    King
}

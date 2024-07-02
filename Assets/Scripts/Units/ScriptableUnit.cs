using UnityEngine;

[CreateAssetMenu(fileName = "New unit", menuName = "Scriptable unit")]
public class ScriptableUnit : ScriptableObject
{
    public Faction Faction;
    public BaseUnit unitPrefab;
}

public enum Faction
{
    white = 0,
    black = 1
}

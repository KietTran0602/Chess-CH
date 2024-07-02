using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;

    [SerializeField] private Transform _cam;
    private Dictionary<Vector2, Tile> _tiles;
    private void Awake()
    {
        Instance = this;
    }
    public void GenerateGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();
        for (var x = 0; x < _width; x++)
        {
            for (var y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);

                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
        _cam.transform.position = new Vector3(_width / 2 - 0.5f, _height / 2 - 0.5f, -10);

        GameManager.Instance.updateGameState(GameState.GenetatePiece);

    }

    public Dictionary<Vector2, Tile> GetWhiteSpawnedTile()
    {
        var filteredTiles = _tiles.Where(t => (t.Key.y == 0 || t.Key.y == 1));
        Dictionary<Vector2, Tile> whiteSpawnTiles = new Dictionary<Vector2, Tile>();
        foreach (var tileEntry in filteredTiles)
        {
            whiteSpawnTiles.Add(tileEntry.Key, tileEntry.Value);
        }
        return whiteSpawnTiles;
    }
    public Dictionary<Vector2, Tile> GetBlackSpawnedTile()
    {
        var filteredTiles = _tiles.Where(t => (t.Key.y == 6 || t.Key.y == 7));
        Dictionary<Vector2, Tile> blackSpawnTiles = new Dictionary<Vector2, Tile>();
        foreach (var tileEntry in filteredTiles)
        {
            blackSpawnTiles.Add(tileEntry.Key, tileEntry.Value);
        }
        return blackSpawnTiles;
    }

    public Dictionary<Vector2, Tile> GetAllTile()
    {
        return _tiles;
    }
    public Tile GetTileAtPosotion(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile)) return tile;

        return null;
    }
}

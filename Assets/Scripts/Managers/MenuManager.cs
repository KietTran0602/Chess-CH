using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _selectedobj, _tileobj, _tileUnitobj, _gameStateobj;
    public static MenuManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void showSelected(BaseWhite white)
    {
        if (white == null)
        {
            _selectedobj.SetActive(false);
            return;
        }
        _selectedobj.GetComponentInChildren<TextMeshProUGUI>().text = white.UnitName;
        _selectedobj.SetActive(true);
    }

    public void ShowTileInfo(Tile tile)
    {
        if (tile == null)
        {
            _tileobj.SetActive(false);
            _tileUnitobj.SetActive(false);
            return;
        }
        else
        {
            _tileobj.GetComponentInChildren<TextMeshProUGUI>().text = tile.TileName;
            _tileobj.SetActive(true);
        }


        if (tile.OccupiedUnit)
        {
            _tileobj.GetComponentInChildren<TextMeshProUGUI>().text = tile.OccupiedUnit.UnitName;
            _tileobj.SetActive(true);
        }
    }

    public void showGamestateinfo(GameState state)
    {
        if (state == null)
        {
            _gameStateobj.SetActive(false);
        }
        _gameStateobj.GetComponentInChildren<TextMeshProUGUI>().text = state.ToString();
        _gameStateobj.SetActive(true);
    }
}

using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnStateChange;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        updateGameState(GameState.GenerateGrid);
    }
    public void updateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case GameState.GenetatePiece:
                UnitManager.Instance.SpawnWhite();
                UnitManager.Instance.SpawnBlack();
                break;
            case GameState.WhiteTurn:
                break;
            case GameState.BlackTurn:
                break;
            case GameState.EndGame:
                break;
        }
        MenuManager.Instance.showGamestateinfo();
        OnStateChange?.Invoke(newState);
    }


}

public enum GameState
{
    GenerateGrid = 0,
    GenetatePiece = 1,
    WhiteTurn = 2,
    BlackTurn = 3,
    EndGame = 4
}
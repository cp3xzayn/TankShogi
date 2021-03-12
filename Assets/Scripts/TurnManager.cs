using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;
    private GameState nowState;

    public GameState NowState
    {
        get { return nowState; }
    }

    void Awake()
    {
        Instance = this;
        SetNoState(GameState.BeginMyTurn);
    }

    public void SetNoState(GameState state)
    {
        nowState = state;
        OnGameStateChanged(nowState);
    }

    void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.BeginMyTurn:
                Debug.Log("GameState.BeginMyTurn");
                break;
            case GameState.EndMyTurn:
                Debug.Log("GameState.EndMyTurn");
                SetNoState(GameState.BeginEneTurn);
                break;
            case GameState.BeginEneTurn:
                Debug.Log("GameState.BeginEneTurn");
                break;
            case GameState.EndEneTurn:
                Debug.Log("GameState.EndEneTurn");
                SetNoState(GameState.BeginMyTurn);
                break;
            default:
                break;
        }
    }
}

public enum GameState
{
    BeginMyTurn,
    EndMyTurn,
    BeginEneTurn,
    EndEneTurn
}

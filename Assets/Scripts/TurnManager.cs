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
        SetNowState(GameState.BeginMyTurn);
    }

    public void SetNowState(GameState state)
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
                OnBeginMyTurn();
                break;
            case GameState.SelectMyPiece:
                Debug.Log("GameState.SelectMyPiece");
                break;
            case GameState.MoveMyPiece:
                Debug.Log("GameState.MoveMyPiece");
                break;
            case GameState.EndMyTurn:
                Debug.Log("GameState.EndMyTurn");
                OnEndMyTurn();
                break;
            case GameState.BeginEneTurn:
                Debug.Log("GameState.BeginEneTurn");
                OnBeginEneTurn();
                break;
            case GameState.SelectEnePiece:
                Debug.Log("GameState.SelectEnePiece");
                break;
            case GameState.MoveEnePiece:
                Debug.Log("GameState.MoveEnePiece");
                break;
            case GameState.EndEneTurn:
                Debug.Log("GameState.EndEneTurn");
                OnEndEneTurn();
                break;
        }
    }

    void OnBeginMyTurn()
    {
        SetNowState(GameState.SelectMyPiece);
    }

    void OnEndMyTurn()
    {
        SetNowState(GameState.BeginEneTurn);
    }

    void OnBeginEneTurn()
    {
        SetNowState(GameState.SelectEnePiece);
    }

    void OnEndEneTurn()
    {
        SetNowState(GameState.BeginMyTurn);
    }
}

public enum GameState
{
    BeginMyTurn,
    SelectMyPiece,
    MoveMyPiece,
    EndMyTurn,
    BeginEneTurn,
    SelectEnePiece,
    MoveEnePiece,
    EndEneTurn
}

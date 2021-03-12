﻿using System.Collections;
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
                SetNowState(GameState.BeginEneTurn);
                break;
            case GameState.BeginEneTurn:
                Debug.Log("GameState.BeginEneTurn");
                break;
            case GameState.SelectEnePiece:
                Debug.Log("GameState.SelectEnePiece");
                break;
            case GameState.MoveEnePiece:
                Debug.Log("GameState.MoveEnePiece");
                break;
            case GameState.EndEneTurn:
                Debug.Log("GameState.EndEneTurn");
                SetNowState(GameState.BeginMyTurn);
                break;
            default:
                break;
        }
    }

    void OnBeginMyTurn()
    {
        SetNowState(GameState.SelectMyPiece);
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

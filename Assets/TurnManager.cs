using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TurnManager : MonoBehaviour
{
    [HideInInspector] public MainGame MainGame;

    private int _turnCount = 1;

    [SerializeField] private TextMeshProUGUI _turnText;


    void Start()
    {
        ChangeTurnText();
    }

    void Update()
    {
        
    }


    public void NextTurn()
    {
        _turnCount++;
        ChangeTurnText();
        MainGame.ActionManager.ResetAction();
    }


    private void ChangeTurnText()
    {
        _turnText.text = "Turn : " + _turnCount;
    }
}

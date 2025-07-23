using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel_Menu : MovePanel
{
    [SerializeField] private Button buttonLeaderboard;

    [SerializeField] private Button buttonChecked;
    [SerializeField] private Button buttonChess;
    [SerializeField] private Button buttonDominoes;
    [SerializeField] private Button buttonSolitaire;
    [SerializeField] private Button buttonLudo;
    [SerializeField] private Button buttonLotto;
    [SerializeField] private Button buttonRoulette;

    public override void Initialize()
    {
        base.Initialize();

        buttonLeaderboard.onClick.AddListener(() => OnClickToLeaderboard?.Invoke());

        buttonChecked.onClick.AddListener(() => OnClickToChecked?.Invoke());
        buttonChess.onClick.AddListener(() => OnClickToChess?.Invoke());
        buttonDominoes.onClick.AddListener(() => OnClickToDominoes?.Invoke());
        buttonSolitaire.onClick.AddListener(() => OnClickToSolitaire?.Invoke());
        buttonLudo.onClick.AddListener(() => OnClickToLudo?.Invoke());
        buttonLotto.onClick.AddListener(() => OnClickToLotto?.Invoke());
        buttonRoulette.onClick.AddListener(() => OnClickToRoulette?.Invoke());
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonLeaderboard.onClick.RemoveListener(() => OnClickToLeaderboard?.Invoke());

        buttonChecked.onClick.RemoveListener(() => OnClickToChecked?.Invoke());
        buttonChess.onClick.RemoveListener(() => OnClickToChess?.Invoke());
        buttonDominoes.onClick.RemoveListener(() => OnClickToDominoes?.Invoke());
        buttonSolitaire.onClick.RemoveListener(() => OnClickToSolitaire?.Invoke());
        buttonLudo.onClick.RemoveListener(() => OnClickToLudo?.Invoke());
        buttonLotto.onClick.RemoveListener(() => OnClickToLotto?.Invoke());
        buttonRoulette.onClick.RemoveListener(() => OnClickToRoulette?.Invoke());
    }

    #region Output

    public event Action OnClickToLeaderboard;

    public event Action OnClickToChecked;
    public event Action OnClickToChess;
    public event Action OnClickToDominoes;
    public event Action OnClickToSolitaire;
    public event Action OnClickToLudo;
    public event Action OnClickToLotto;
    public event Action OnClickToRoulette;

    #endregion
}

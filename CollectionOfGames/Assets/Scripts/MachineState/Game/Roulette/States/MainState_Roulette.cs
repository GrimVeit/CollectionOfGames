using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainState_Roulette : IState
{
    private readonly IGlobalStateMachineProvider _stateProvider;
    private readonly UIGameRoot_Roulette _sceneRoot;
    private readonly BetPresenter _betPresenter;
    private readonly IBetCellActivatorProvider _cellActivatorProvider;
    private readonly IPseudoChipActivatorProvider _pseudoChipActivatorProvider;

    public MainState_Roulette(IGlobalStateMachineProvider stateProvider, UIGameRoot_Roulette sceneRoot, BetPresenter betPresenter, IBetCellActivatorProvider cellActivatorProvider, IPseudoChipActivatorProvider pseudoChipActivatorProvider)
    {
        _sceneRoot = sceneRoot;
        _stateProvider = stateProvider;
        _betPresenter = betPresenter;
        _cellActivatorProvider = cellActivatorProvider;
        _pseudoChipActivatorProvider = pseudoChipActivatorProvider;
    }

    public void EnterState()
    {
        Debug.Log("ACTIVATE STATE - MAIN");

        _sceneRoot.OnClickToSpin_MainPanel += ChangeStateToRoulette;

        _sceneRoot.OpenMainPanel();

        _betPresenter.ClearTable();

        _pseudoChipActivatorProvider.Activate();
        _cellActivatorProvider.Activate();
    }

    public void ExitState()
    {
        Debug.Log("DEACTIVATE STATE - MAIN");

        _sceneRoot.OnClickToSpin_MainPanel -= ChangeStateToRoulette;

        _pseudoChipActivatorProvider.Deactivate();
        _cellActivatorProvider.Deactivate();
    }

    private void ChangeStateToRoulette()
    {
        _stateProvider.SetState(_stateProvider.GetState<RouletteState_Roulette>());
    }
}

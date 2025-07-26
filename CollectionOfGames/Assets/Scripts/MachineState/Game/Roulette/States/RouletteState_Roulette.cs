using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteState_Roulette : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIGameRoot_Roulette _sceneRoot;
    private readonly RoulettePresenter _roulettePresenter;
    private readonly RouletteBallPresenter _rouletteBallPresenter;

    public RouletteState_Roulette(IGlobalStateMachineProvider machineProvider, UIGameRoot_Roulette sceneRoot, RoulettePresenter roulettePresenter, RouletteBallPresenter rouletteBallPresenter)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
        _roulettePresenter = roulettePresenter;
        _rouletteBallPresenter = rouletteBallPresenter;
    }

    public void EnterState()
    {
        Debug.Log("ACTIVATE STATE - ROULETTE");

        _rouletteBallPresenter.OnBallStopped += _roulettePresenter.RollBallToSlot;
        _roulettePresenter.OnStopSpin += ChangeStateToResult;

        _sceneRoot.OpenRoulettePanel();
        _roulettePresenter.StartSpin();
        _rouletteBallPresenter.StartSpin();
    }

    public void ExitState()
    {
        Debug.Log("DEACTIVATE STATE - ROULETTE");

        _rouletteBallPresenter.OnBallStopped -= _roulettePresenter.RollBallToSlot;
        _roulettePresenter.OnStopSpin -= ChangeStateToResult;
    }

    private void ChangeStateToResult()
    {
        _machineProvider.SetState(_machineProvider.GetState<ResultState_Euro>());
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine_Roulette : IGlobalStateMachineProvider
{
    private readonly Dictionary<Type, IState> states = new();

    private IState _currentState;

    public StateMachine_Roulette
        (UIGameRoot_Roulette sceneRoot,
        RouletteBallPresenter rouletteBallPresenter,
        RoulettePresenter roulettePresenter,
        BetPresenter betPresenter,
        IBetCellActivatorProvider betCellActivatorProvider,
        IPseudoChipActivatorProvider pseudoChipActivatorProvider,
        ISoundProvider soundProvider)
    {
        states[typeof(MainState_Roulette)] = new MainState_Roulette(this, sceneRoot, betPresenter, betCellActivatorProvider, pseudoChipActivatorProvider);
        states[typeof(RouletteState_Roulette)] = new RouletteState_Roulette(this, sceneRoot, roulettePresenter, rouletteBallPresenter);
    }

    public void Initialize()
    {
        SetState(GetState<MainState_Roulette>());
    }

    public void Dispose()
    {

    }

    public IState GetState<T>() where T : IState
    {
        return states[typeof(T)];
    }

    public void SetState(IState state)
    {
        _currentState?.ExitState();

        _currentState = state;
        _currentState.EnterState();
    }
}

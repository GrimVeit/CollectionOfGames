using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckResultState_Roulette : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly IRouletteGameProvider _rouletteGameProvider;

    public CheckResultState_Roulette(IGlobalStateMachineProvider machineProvider, IRouletteGameProvider rouletteGameProvider)
    {
        _machineProvider = machineProvider;
        _rouletteGameProvider = rouletteGameProvider;
    }

    public void EnterState()
    {
        _rouletteGameProvider.OnWin += ChangeStateToWin;
        _rouletteGameProvider.OnLose += ChangeStateToLose;

        _rouletteGameProvider.SearchWin();
    }

    public void ExitState()
    {
        _rouletteGameProvider.OnWin -= ChangeStateToWin;
        _rouletteGameProvider.OnLose -= ChangeStateToLose;
    }

    private void ChangeStateToWin()
    {
        _machineProvider.SetState(_machineProvider.GetState<WinState_Roulette>());
    }

    private void ChangeStateToLose()
    {
        _machineProvider.SetState(_machineProvider.GetState<LoseState_Roulette>());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState_Roulette : IState
{
    private IGlobalStateMachineProvider _machineProvider;
    private UIGameRoot_Roulette _sceneRoot;

    private IEnumerator timer;

    public WinState_Roulette(IGlobalStateMachineProvider machineProvider, UIGameRoot_Roulette sceneRoot)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.OnClickToContinue_Win += ChangeStateToMain;

        if(timer != null) Coroutines.Stop(timer);

        timer = Timer(15);
        Coroutines.Start(timer);

        _sceneRoot.OpenWinPanel();
        _sceneRoot.OpenRouletteHeaderPanel();
    }

    public void ExitState()
    {
        _sceneRoot.OnClickToContinue_Win -= ChangeStateToMain;

        if (timer != null) Coroutines.Stop(timer);

        _sceneRoot.CloseWinPanel();
        _sceneRoot.CloseRouletteHeaderPanel();
    }

    private IEnumerator Timer(float sec)
    {
        yield return new WaitForSeconds(sec);

        ChangeStateToMain();
    }

    private void ChangeStateToMain()
    {
        _machineProvider.SetState(_machineProvider.GetState<MainState_Roulette>());
    }
}

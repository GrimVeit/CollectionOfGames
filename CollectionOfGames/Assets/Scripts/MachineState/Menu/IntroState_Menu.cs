using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroState_Menu : IState
{
    private readonly IGlobalStateMachineProvider _globalStateMachineProvider;

    private readonly UIMainMenuRoot _sceneRoot;

    public IntroState_Menu(IGlobalStateMachineProvider globalStateMachineProvider, UIMainMenuRoot sceneRoot)
    {
        _globalStateMachineProvider = globalStateMachineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.OnClickToPlay_Intro += ChangeStateToCheckAuthorization;

        _sceneRoot.OpenIntroPanel();
    }

    public void ExitState()
    {
        _sceneRoot.OnClickToPlay_Intro -= ChangeStateToCheckAuthorization;

        _sceneRoot.CloseIntroPanel();
    }

    private void ChangeStateToCheckAuthorization()
    {
        _globalStateMachineProvider.SetState(_globalStateMachineProvider.GetState<CheckAuthorizationState_Menu>());
    }
}

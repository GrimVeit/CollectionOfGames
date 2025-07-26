using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel_Roulette : MovePanel
{
    [SerializeField] private Button buttonContinue;

    public override void Initialize()
    {
        base.Initialize();

        buttonContinue.onClick.AddListener(() => OnClickToContinue?.Invoke());
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonContinue.onClick.RemoveListener(() => OnClickToContinue?.Invoke());
    }

    #region Output

    public event Action OnClickToContinue;

    #endregion
}

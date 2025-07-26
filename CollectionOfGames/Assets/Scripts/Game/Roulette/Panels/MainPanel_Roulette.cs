using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel_Roulette : MovePanel
{
    [SerializeField] private Button buttonBack;
    [SerializeField] private Button buttonSpin;

    public override void Initialize()
    {
        base.Initialize();

        buttonBack.onClick.AddListener(() => OnClickToBack?.Invoke());
        buttonSpin.onClick.AddListener(() => OnClickToSpin?.Invoke());
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonBack.onClick.RemoveListener(() => OnClickToBack?.Invoke());
        buttonSpin.onClick.RemoveListener(() => OnClickToSpin?.Invoke());
    }

    #region Output

    public event Action OnClickToBack;
    public event Action OnClickToSpin;

    #endregion
}

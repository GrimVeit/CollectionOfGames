using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegistrationPanel_Menu : MovePanel
{
    [SerializeField] private Button buttonRegistrate;

    public override void Initialize()
    {
        base.Initialize();

        buttonRegistrate.onClick.AddListener(() => OnClickToRegistrate?.Invoke());
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonRegistrate.onClick.RemoveListener(() => OnClickToRegistrate?.Invoke());
    }

    #region Output

    public event Action OnClickToRegistrate;

    #endregion
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameRoot_Checkers : UIRoot
{
    [SerializeField] private MainPanel_Checkers mainPanel;

    private ISoundProvider _soundProvider;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        _soundProvider = soundProvider;
    }

    public void Initialize()
    {
        mainPanel.Initialize();
    }

    public void Activate()
    {
        mainPanel.OnClickToBack += HandleClickToBack;
    }


    public void Deactivate()
    {
        mainPanel.OnClickToBack -= HandleClickToBack;

        if (currentPanel != null)
            CloseOtherPanel(currentPanel);
    }

    public void Dispose()
    {
        mainPanel.Dispose();
    }


    #region Input
    public void OpenMainPanel()
    {
        OpenPanel(mainPanel);
    }
    #endregion



    #region Output
    public event Action OnClickToBack;

    private void HandleClickToBack()
    {
        OnClickToBack?.Invoke();
    }
    #endregion
}

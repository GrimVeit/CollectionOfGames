using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameRoot_Roulette : UIRoot
{
    [SerializeField] private MainPanel_Roulette mainPanel;
    [SerializeField] private RoulettePanel_Roulette roulettePanel;

    private ISoundProvider _soundProvider;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        _soundProvider = soundProvider;
    }

    public void Initialize()
    {
        mainPanel.Initialize();
        roulettePanel.Initialize();
    }

    public void Activate()
    {
        mainPanel.OnClickToBack += HandleClickToBack;
        mainPanel.OnClickToSpin += HandleClickToSpin;
    }


    public void Deactivate()
    {
        mainPanel.OnClickToBack -= HandleClickToBack;
        mainPanel.OnClickToSpin -= HandleClickToSpin;

        if (currentPanel != null)
            CloseOtherPanel(currentPanel);
    }

    public void Dispose()
    {
        mainPanel.Dispose();
        roulettePanel.Dispose();
    }


    #region Input
    public void OpenMainPanel()
    {
        OpenPanel(mainPanel);
    }

    public void OpenRoulettePanel()
    {
        OpenPanel(roulettePanel);
    }
    #endregion



    #region Output
    public event Action OnClickToBack;
    public event Action OnClickToSpin;

    private void HandleClickToBack()
    {
        OnClickToBack?.Invoke();
    }

    private void HandleClickToSpin()
    {
        OnClickToSpin?.Invoke();
    }
    #endregion
}

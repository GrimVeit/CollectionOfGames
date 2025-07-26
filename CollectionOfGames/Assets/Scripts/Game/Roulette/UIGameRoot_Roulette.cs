using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameRoot_Roulette : UIRoot
{
    [SerializeField] private MainPanel_Roulette mainPanel;
    [Space]
    [SerializeField] private RoulettePanel_Roulette roulettePanel;
    [SerializeField] private RouletteHeaderPanel_Roulette rouletteHeaderPanel;
    [SerializeField] private WinPanel_Roulette winPanel;
    [SerializeField] private LosePanel_Roulette losePanel;

    private ISoundProvider _soundProvider;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        _soundProvider = soundProvider;
    }

    public void Initialize()
    {
        mainPanel.Initialize();
        roulettePanel.Initialize();
        rouletteHeaderPanel.Initialize();
        winPanel.Initialize();
        losePanel.Initialize();
    }

    public void Activate()
    {
        mainPanel.OnClickToBack += HandleClickToBack;
        rouletteHeaderPanel.OnClickToExit += HandleClickToBack;

        mainPanel.OnClickToSpin += HandleClickToSpin;

        winPanel.OnClickToContinue += HandleClickToContinue_Win;
        losePanel.OnClickToContinue += HandleClickToContinue_Lose;
    }


    public void Deactivate()
    {
        mainPanel.OnClickToBack -= HandleClickToBack;
        rouletteHeaderPanel.OnClickToExit -= HandleClickToBack;

        mainPanel.OnClickToSpin -= HandleClickToSpin;

        winPanel.OnClickToContinue -= HandleClickToContinue_Win;
        losePanel.OnClickToContinue -= HandleClickToContinue_Lose;

        if (currentPanel != null)
            CloseOtherPanel(currentPanel);
    }

    public void Dispose()
    {
        mainPanel.Dispose();
        roulettePanel.Dispose();
        rouletteHeaderPanel.Dispose();
        winPanel.Dispose();
        losePanel.Dispose();
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




    public void OpenRouletteHeaderPanel()
    {
        OpenOtherPanel(rouletteHeaderPanel);
    }

    public void CloseRouletteHeaderPanel()
    {
        CloseOtherPanel(rouletteHeaderPanel);
    }


    public void OpenWinPanel()
    {
        OpenOtherPanel(winPanel);
    }

    public void CloseWinPanel()
    {
        CloseOtherPanel(winPanel);
    }


    public void OpenLosePanel()
    {
        OpenOtherPanel(losePanel);
    }

    public void CloseLosePanel()
    {
        CloseOtherPanel(losePanel);
    }

    #endregion



    #region Output

    public event Action OnClickToBack_MainPanel;
    public event Action OnClickToSpin_MainPanel;

    private void HandleClickToBack()
    {
        OnClickToBack_MainPanel?.Invoke();
    }

    private void HandleClickToSpin()
    {
        OnClickToSpin_MainPanel?.Invoke();
    }

    //--------------------||---------------------\\

    public event Action OnClickToContinue_Lose;
    
    private void HandleClickToContinue_Lose()
    {
        OnClickToContinue_Lose?.Invoke();
    }

    //--------------------||---------------------\\

    public event Action OnClickToContinue_Win;

    private void HandleClickToContinue_Win()
    {
        OnClickToContinue_Win?.Invoke();
    }

    #endregion
}

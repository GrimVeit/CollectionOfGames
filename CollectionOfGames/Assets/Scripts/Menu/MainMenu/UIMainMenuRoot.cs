using System;
using UnityEngine;

public class UIMainMenuRoot : UIRoot
{
    [SerializeField] private IntroPanel_Menu introPanel;
    [SerializeField] private MainPanel_Menu mainPanel;
    [SerializeField] private LeaderboardPanel_Menu leaderboardPanel;

    [Header("Others")]
    [SerializeField] private NicknamePanel_Menu nicknamePanel;
    [SerializeField] private RegistrationPanel_Menu registrationPanel;
    [SerializeField] private LoadingPanel_Menu loadRegistrationPanel;

    private ISoundProvider _soundProvider;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        _soundProvider = soundProvider;
    }

    public void Initialize()
    {
        introPanel.Initialize();
        mainPanel.Initialize();
        leaderboardPanel.Initialize();

        nicknamePanel.Initialize();
        registrationPanel.Initialize();
        loadRegistrationPanel.Initialize();
    }

    public void Activate()
    {
        registrationPanel.OnClickToRegistrate += HandleClickToRegistrate_Registration;

        leaderboardPanel.OnClickToBack += HandleClickToBack_Leaderboard;

        introPanel.OnClickToPlay += HandleClickToPlay_Intro;

        mainPanel.OnClickToLeaderboard += HandleClickToLeaderboard_Main;

        mainPanel.OnClickToChecked += HandleClickToChecked;
        mainPanel.OnClickToChess += HandleClickToChess;
        mainPanel.OnClickToDominoes += HandleClickToDominoes;
        mainPanel.OnClickToSolitaire += HandleClickToSolitaire;
        mainPanel.OnClickToLudo += HandleClickToLudo;
        mainPanel.OnClickToLotto += HandleClickToLotto;
        mainPanel.OnClickToRoulette += HandleClickToRoulette;
    }


    public void Deactivate()
    {
        registrationPanel.OnClickToRegistrate -= HandleClickToRegistrate_Registration;

        leaderboardPanel.OnClickToBack -= HandleClickToBack_Leaderboard;

        introPanel.OnClickToPlay -= HandleClickToPlay_Intro;

        mainPanel.OnClickToLeaderboard -= HandleClickToLeaderboard_Main;

        mainPanel.OnClickToChecked -= HandleClickToChecked;
        mainPanel.OnClickToChess -= HandleClickToChess;
        mainPanel.OnClickToDominoes -= HandleClickToDominoes;
        mainPanel.OnClickToSolitaire -= HandleClickToSolitaire;
        mainPanel.OnClickToLudo -= HandleClickToLudo;
        mainPanel.OnClickToLotto -= HandleClickToLotto;
        mainPanel.OnClickToRoulette -= HandleClickToRoulette;

        if (currentPanel != null)
            CloseOtherPanel(currentPanel);
    }

    public void Dispose()
    {
        introPanel.Dispose();
        mainPanel.Dispose();
        leaderboardPanel.Dispose();

        nicknamePanel.Dispose();
        registrationPanel.Dispose();
        loadRegistrationPanel.Dispose();
    }


    public void OpenMainPanel()
    {
        OpenPanel(mainPanel);
    }

    public void OpenLeaderboardPanel()
    {
        OpenPanel(leaderboardPanel);
    }

    #region OTHERS

    public void OpenNicknamePanel()
    {
        OpenOtherPanel(nicknamePanel);
    }

    public void CloseNicknamePanel()
    {
        CloseOtherPanel(nicknamePanel);
    }



    public void OpenRegistrationPanel()
    {
        OpenOtherPanel(registrationPanel);
    }

    public void CloseRegistrationPanel()
    {
        CloseOtherPanel(registrationPanel);
    }


    public void OpenLoadRegistrationPanel()
    {
        OpenOtherPanel(loadRegistrationPanel);
    }

    public void CloseLoadRegistrationPanel()
    {
        CloseOtherPanel(loadRegistrationPanel);
    }



    public void OpenIntroPanel()
    {
        OpenOtherPanel(introPanel);
    }

    public void CloseIntroPanel()
    {
        CloseOtherPanel(introPanel);
    }

    #endregion


    #region Output

    #region OTHER

    public event Action OnClickToRegistrate_Registration;

    private void HandleClickToRegistrate_Registration()
    {
        OnClickToRegistrate_Registration?.Invoke();
    }

    #endregion

    #region MainPanel

    public event Action OnClickToLeaderboard;

    private void HandleClickToLeaderboard_Main()
    {
        _soundProvider.PlayOneShot("Click");

        OnClickToLeaderboard?.Invoke();
    }






    public event Action OnClickToChecked;
    public event Action OnClickToChess;
    public event Action OnClickToDominoes;
    public event Action OnClickToSolitaire;
    public event Action OnClickToLudo;
    public event Action OnClickToLotto;
    public event Action OnClickToRoulette;

    private void HandleClickToChecked()
    {
        _soundProvider.PlayOneShot("Click");

        OnClickToChecked?.Invoke();
    }

    private void HandleClickToChess()
    {
        _soundProvider.PlayOneShot("Click");

        OnClickToChess?.Invoke();
    }

    private void HandleClickToDominoes()
    {
        _soundProvider.PlayOneShot("Click");

        OnClickToDominoes?.Invoke();
    }

    private void HandleClickToSolitaire()
    {
        _soundProvider.PlayOneShot("Click");

        OnClickToSolitaire?.Invoke();
    }

    private void HandleClickToLudo()
    {
        _soundProvider.PlayOneShot("Click");

        OnClickToLudo?.Invoke();
    }

    private void HandleClickToLotto()
    {
        _soundProvider.PlayOneShot("Click");

        OnClickToLotto?.Invoke();
    }

    private void HandleClickToRoulette()
    {
        _soundProvider.PlayOneShot("Click");

        OnClickToRoulette?.Invoke();
    }

    #endregion

    #region LeaderboardPanel

    public event Action OnClickToBack_Leaderboard;

    private void HandleClickToBack_Leaderboard()
    {
        _soundProvider.PlayOneShot("Click");

        OnClickToBack_Leaderboard?.Invoke();
    }

    #endregion

    #region IntroPanel

    public event Action OnClickToPlay_Intro;

    private void HandleClickToPlay_Intro()
    {
        _soundProvider.PlayOneShot("Click");

        OnClickToPlay_Intro?.Invoke();
    }

    #endregion

    #endregion

}

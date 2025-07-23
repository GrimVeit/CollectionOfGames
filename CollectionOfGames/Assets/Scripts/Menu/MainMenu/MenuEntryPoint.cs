using System;
using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

public class MenuEntryPoint : MonoBehaviour
{
    [SerializeField] private Sounds sounds;
    [SerializeField] private UIMainMenuRoot menuRootPrefab;

    private UIMainMenuRoot sceneRoot;
    private ViewContainer viewContainer;

    private BankPresenter bankPresenter;
    private ParticleEffectPresenter particleEffectPresenter;
    private SoundPresenter soundPresenter;

    private NicknamePresenter nicknamePresenter;
    private AvatarPresenter avatarPresenter;
    private FirebaseAuthenticationPresenter firebaseAuthenticationPresenter;
    private FirebaseDatabasePresenter firebaseDatabasePresenter;
    private LeaderboardPresenter leaderboardPresenter;

    private StateMachine_Menu stateMachine;

    public void Run(UIRootView uIRootView)
    {
        sceneRoot = menuRootPrefab;

        uIRootView.AttachSceneUI(sceneRoot.gameObject, Camera.main);

        viewContainer = sceneRoot.GetComponent<ViewContainer>();
        viewContainer.Initialize();

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            var dependencyStatus = task.Result;

            if (dependencyStatus == DependencyStatus.Available)
            {
                FirebaseDatabase.DefaultInstance.SetPersistenceEnabled(false);
                FirebaseAuth firebaseAuth = FirebaseAuth.DefaultInstance;
                DatabaseReference databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

                soundPresenter = new SoundPresenter
                    (new SoundModel(sounds.sounds, PlayerPrefsKeys.IS_MUTE_SOUNDS),
                    viewContainer.GetView<SoundView>());

                particleEffectPresenter = new ParticleEffectPresenter
                    (new ParticleEffectModel(),
                    viewContainer.GetView<ParticleEffectView>());

                bankPresenter = new BankPresenter(new BankModel(), viewContainer.GetView<BankView>());

                nicknamePresenter = new NicknamePresenter(new NicknameModel(PlayerPrefsKeys.NICKNAME, soundPresenter), viewContainer.GetView<NicknameView>());
                avatarPresenter = new AvatarPresenter(new AvatarModel(PlayerPrefsKeys.AVATAR), viewContainer.GetView<AvatarView>());
                firebaseAuthenticationPresenter = new FirebaseAuthenticationPresenter(new FirebaseAuthenticationModel(firebaseAuth, soundPresenter), viewContainer.GetView<FirebaseAuthenticationView>());
                firebaseDatabasePresenter = new FirebaseDatabasePresenter(new FirebaseDatabaseModel(firebaseAuth, databaseReference, soundPresenter));
                leaderboardPresenter = new LeaderboardPresenter(new LeaderboardModel(firebaseDatabasePresenter), viewContainer.GetView<LeaderboardView>());

                stateMachine = new StateMachine_Menu
                (sceneRoot,
                nicknamePresenter,
                avatarPresenter,
                firebaseAuthenticationPresenter,
                firebaseDatabasePresenter);

                sceneRoot.SetSoundProvider(soundPresenter);
                sceneRoot.Activate();

                ActivateEvents();

                soundPresenter.Initialize();
                particleEffectPresenter.Initialize();
                sceneRoot.Initialize();
                bankPresenter.Initialize();

                nicknamePresenter.Initialize();
                avatarPresenter.Initialize();
                leaderboardPresenter.Initialize();
                firebaseAuthenticationPresenter.Initialize();
                firebaseDatabasePresenter.Initialize();

                stateMachine.Initialize();
            }
            else
            {
                Debug.LogError(string.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    private void ActivateEvents()
    {
        ActivateTransitions();
    }

    private void DeactivateEvents()
    {
        DeactivateTransitions();
    }

    private void ActivateTransitions()
    {
        sceneRoot.OnClickToChecked += HandleGoToGame_Checkers;
        sceneRoot.OnClickToChess += HandleGoToGame_Chess;
        sceneRoot.OnClickToDominoes += HandleGoToGame_Dominoes;
        sceneRoot.OnClickToSolitaire += HandleGoToGame_Solitaire;
        sceneRoot.OnClickToLudo += HandleGoToGame_Ludo;
        sceneRoot.OnClickToLotto += HandleGoToGame_Lotto;
        sceneRoot.OnClickToRoulette += HandleGoToGame_Roulette;
    }

    private void DeactivateTransitions()
    {
        sceneRoot.OnClickToChecked -= HandleGoToGame_Checkers;
        sceneRoot.OnClickToChess -= HandleGoToGame_Chess;
        sceneRoot.OnClickToDominoes -= HandleGoToGame_Dominoes;
        sceneRoot.OnClickToSolitaire -= HandleGoToGame_Solitaire;
        sceneRoot.OnClickToLudo -= HandleGoToGame_Ludo;
        sceneRoot.OnClickToLotto -= HandleGoToGame_Lotto;
        sceneRoot.OnClickToRoulette -= HandleGoToGame_Roulette;
    }

    private void Deactivate()
    {
        sceneRoot.Deactivate();
        soundPresenter?.Dispose();
    }

    private void Dispose()
    {
        DeactivateEvents();

        soundPresenter?.Dispose();
        sceneRoot?.Dispose();
        particleEffectPresenter?.Dispose();
        bankPresenter?.Dispose();

        nicknamePresenter?.Dispose();
        avatarPresenter?.Dispose();
        leaderboardPresenter?.Dispose();
        firebaseAuthenticationPresenter?.Dispose();
        firebaseDatabasePresenter?.Dispose();

        stateMachine?.Dispose();
    }

    private void OnDestroy()
    {
        Dispose();
    }

    #region Output

    public event Action OnGoToGame_Checkers;
    public event Action OnGoToGame_Chess;
    public event Action OnGoToGame_Dominoes;
    public event Action OnGoToGame_Solitaire;
    public event Action OnGoToGame_Ludo;
    public event Action OnGoToGame_Lotto;
    public event Action OnGoToGame_Roulette;

    private void HandleGoToGame_Checkers()
    {
        Deactivate();
        OnGoToGame_Checkers?.Invoke();
    }

    private void HandleGoToGame_Chess()
    {
        Deactivate();
        OnGoToGame_Chess?.Invoke();
    }

    private void HandleGoToGame_Dominoes()
    {
        Deactivate();
        OnGoToGame_Dominoes?.Invoke();
    }

    private void HandleGoToGame_Solitaire()
    {
        Deactivate();
        OnGoToGame_Solitaire?.Invoke();
    }

    private void HandleGoToGame_Ludo()
    {
        Deactivate();
        OnGoToGame_Ludo?.Invoke();
    }

    private void HandleGoToGame_Lotto()
    {
        Deactivate();
        OnGoToGame_Lotto?.Invoke();
    }
    
    private void HandleGoToGame_Roulette()
    {
        Deactivate();
        OnGoToGame_Roulette?.Invoke();
    }

    #endregion
}

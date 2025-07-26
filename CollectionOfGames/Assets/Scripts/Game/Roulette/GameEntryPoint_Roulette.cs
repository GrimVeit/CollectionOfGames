using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEntryPoint_Roulette : MonoBehaviour
{
    [SerializeField] private Sounds sounds;
    [SerializeField] private Bets bets;
    [SerializeField] private UIGameRoot_Roulette menuRootPrefab;

    private UIGameRoot_Roulette sceneRoot;
    private ViewContainer viewContainer;

    private BankPresenter bankPresenter;
    private ParticleEffectPresenter particleEffectPresenter;
    private SoundPresenter soundPresenter;

    private RoulettePresenter roulettePresenter;
    private RouletteBallPresenter rouletteBallPresenter;

    private PseudoChipPresenter pseudoChipPresenter;

    private BetPresenter betPresenter;
    private BetCellPresenter betCellPresenter;
    private ChipGameVisualPresenter chipGameVisualPresenter;

    private StateMachine_Roulette stateMachine;

    public void Run(UIRootView uIRootView)
    {
        sceneRoot = menuRootPrefab;

        uIRootView.AttachSceneUI(sceneRoot.gameObject, Camera.main);

        viewContainer = sceneRoot.GetComponent<ViewContainer>();
        viewContainer.Initialize();

        soundPresenter = new SoundPresenter
            (new SoundModel(sounds.sounds, PlayerPrefsKeys.IS_MUTE_SOUNDS),
            viewContainer.GetView<SoundView>());

        particleEffectPresenter = new ParticleEffectPresenter
            (new ParticleEffectModel(),
            viewContainer.GetView<ParticleEffectView>());

        bankPresenter = new BankPresenter(new BankModel(), viewContainer.GetView<BankView>());

        roulettePresenter = new RoulettePresenter(new RouletteModel(soundPresenter), viewContainer.GetView<RouletteView>());
        rouletteBallPresenter = new RouletteBallPresenter(new RouletteBallModel(soundPresenter), viewContainer.GetView<RouletteBallView>());

        pseudoChipPresenter = new PseudoChipPresenter(new PseudoChipModel(soundPresenter), viewContainer.GetView<PseudoChipView>());

        betPresenter = new BetPresenter(new BetModel(bets, new List<IRouletteValueProvider>() { roulettePresenter }, bankPresenter, soundPresenter), viewContainer.GetView<BetView>());
        betCellPresenter = new BetCellPresenter(new BetCellModel(betPresenter), viewContainer.GetView<BetCellView>());

        chipGameVisualPresenter = new ChipGameVisualPresenter(new ChipGameVisualModel(betPresenter), viewContainer.GetView<ChipGameVisualView>());

        stateMachine = new StateMachine_Roulette(sceneRoot, rouletteBallPresenter, roulettePresenter, betPresenter, betCellPresenter, pseudoChipPresenter, soundPresenter);

        ActivateEvents();

        sceneRoot.Activate();

        soundPresenter.Initialize();
        particleEffectPresenter.Initialize();
        sceneRoot.Initialize();
        bankPresenter.Initialize();

        roulettePresenter.Initialize();
        rouletteBallPresenter.Initialize();

        pseudoChipPresenter.Initialize();

        betPresenter.Initialize();
        betCellPresenter.Initialize();

        chipGameVisualPresenter.Initialize();

        stateMachine.Initialize();
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
        sceneRoot.OnClickToBack += HandleGoToMenu;
    }

    private void DeactivateTransitions()
    {
        sceneRoot.OnClickToBack -= HandleGoToMenu;
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

        roulettePresenter?.Dispose();
        rouletteBallPresenter?.Dispose();

        pseudoChipPresenter?.Dispose();

        chipGameVisualPresenter?.Dispose();

        betPresenter?.Dispose();
        betCellPresenter?.Dispose();
    }

    private void OnDestroy()
    {
        Dispose();
    }

    #region Output

    public event Action OnGoToMenu;

    private void HandleGoToMenu()
    {
        Deactivate();
        OnGoToMenu?.Invoke();
    }

    #endregion
}

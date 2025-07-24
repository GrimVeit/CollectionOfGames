using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEntryPoint
{
    private static GameEntryPoint instance;
    private UIRootView rootView;
    private Coroutines coroutines;
    public GameEntryPoint()
    {
        coroutines = new GameObject("[Coroutines]").AddComponent<Coroutines>();
        Object.DontDestroyOnLoad(coroutines.gameObject);

        var prefabUIRoot = Resources.Load<UIRootView>("UIRootView");
        rootView = Object.Instantiate(prefabUIRoot);
        Object.DontDestroyOnLoad(rootView.gameObject);

    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Autorun()
    {
        GlobalGameSettings();

        instance = new GameEntryPoint();
        instance.Run();

    }

    private static void GlobalGameSettings()
    {
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Run()  
    {
        coroutines.StartCoroutine(LoadAndStartMainMenu());
    }

    private IEnumerator LoadAndStartMainMenu()
    {
        yield return rootView.ShowLoadingScreen(0);

        yield return LoadScene(Scenes.BOOT);
        yield return LoadScene(Scenes.MAIN_MENU);

        yield return new WaitForEndOfFrame();

        var sceneEntryPoint = Object.FindObjectOfType<MenuEntryPoint>();

        sceneEntryPoint.Run(rootView);

        sceneEntryPoint.OnGoToGame_Checkers += () => coroutines.StartCoroutine(LoadAndStartGameScene_Checkers());
        sceneEntryPoint.OnGoToGame_Chess += () => coroutines.StartCoroutine(LoadAndStartGameScene_Chess());
        sceneEntryPoint.OnGoToGame_Dominoes += () => coroutines.StartCoroutine(LoadAndStartGameScene_Dominoes());
        sceneEntryPoint.OnGoToGame_Solitaire += () => coroutines.StartCoroutine(LoadAndStartGameScene_Solitaire());

        //sceneEntryPoint.OnGoToRoulette_Mini += () => coroutines.StartCoroutine(LoadAndStartGameScene_1_Mini());
        //sceneEntryPoint.OnGoToRoulette_Euro += () => coroutines.StartCoroutine(LoadAndStartGameScene_2_Euro());
        //sceneEntryPoint.OnGoToRoulette_America += () => coroutines.StartCoroutine(LoadAndStartGameScene_3_America());
        //sceneEntryPoint.OnGoToRoulette_AmericaMulti += () => coroutines.StartCoroutine(LoadAndStartGameScene_4_AmericaMulti());
        //sceneEntryPoint.OnGoToRoulette_French += () => coroutines.StartCoroutine(LoadAndStartGameScene_5_French());
        //sceneEntryPoint.OnGoToRoulette_AmericaTracker += () => coroutines.StartCoroutine(LoadAndStartGameScene_6_AmericaTracker());

        yield return rootView.HideLoadingScreen(0);
    }

    private IEnumerator LoadAndStartGameScene_Checkers()
    {
        yield return rootView.ShowLoadingScreen(1);

        yield return new WaitForSeconds(0.6f);

        yield return LoadScene(Scenes.BOOT);
        yield return LoadScene(Scenes.GAME_CHECKERS);

        yield return new WaitForEndOfFrame();

        var sceneEntryPoint = Object.FindObjectOfType<GameEntryPoint_Checkers>();
        sceneEntryPoint.Run(rootView);

        sceneEntryPoint.OnGoToMenu += () => coroutines.StartCoroutine(LoadAndStartMainMenu());

        yield return rootView.HideLoadingScreen(1);
    }

    private IEnumerator LoadAndStartGameScene_Chess()
    {
        yield return rootView.ShowLoadingScreen(2);

        yield return new WaitForSeconds(0.6f);

        yield return LoadScene(Scenes.BOOT);
        yield return LoadScene(Scenes.GAME_CHESS);

        yield return new WaitForEndOfFrame();

        var sceneEntryPoint = Object.FindObjectOfType<GameEntryPoint_Chess>();
        sceneEntryPoint.Run(rootView);

        sceneEntryPoint.OnGoToMenu += () => coroutines.StartCoroutine(LoadAndStartMainMenu());

        yield return rootView.HideLoadingScreen(2);
    }

    private IEnumerator LoadAndStartGameScene_Dominoes()
    {
        yield return rootView.ShowLoadingScreen(3);

        yield return new WaitForSeconds(0.6f);

        yield return LoadScene(Scenes.BOOT);
        yield return LoadScene(Scenes.GAME_DOMINOES);

        yield return new WaitForEndOfFrame();

        var sceneEntryPoint = Object.FindObjectOfType<GameEntryPoint_Dominoes>();
        sceneEntryPoint.Run(rootView);

        sceneEntryPoint.OnGoToMenu += () => coroutines.StartCoroutine(LoadAndStartMainMenu());

        yield return rootView.HideLoadingScreen(3);
    }

    private IEnumerator LoadAndStartGameScene_Solitaire()
    {
        yield return rootView.ShowLoadingScreen(4);

        yield return new WaitForSeconds(0.6f);

        yield return LoadScene(Scenes.BOOT);
        yield return LoadScene(Scenes.GAME_SOLITAIRE);

        yield return new WaitForEndOfFrame();

        var sceneEntryPoint = Object.FindObjectOfType<GameEntryPoint_Solitaire>();
        sceneEntryPoint.Run(rootView);

        sceneEntryPoint.OnGoToMenu += () => coroutines.StartCoroutine(LoadAndStartMainMenu());

        yield return rootView.HideLoadingScreen(4);
    }

    private IEnumerator LoadScene(string scene)
    {
        Debug.Log("Загрузка сцены - " + scene);
        yield return SceneManager.LoadSceneAsync(scene);
    }
}

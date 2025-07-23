using System;
using UnityEngine;
using UnityEngine.UI;

public class IntroPanel_Menu : MovePanel
{
    [SerializeField] private Button buttonPlay;

    public override void Initialize()
    {
        base.Initialize();

        buttonPlay.onClick.AddListener(() => OnClickToPlay?.Invoke());
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonPlay.onClick.RemoveListener(() => OnClickToPlay?.Invoke());
    }

    #region Output

    public event Action OnClickToPlay;

    #endregion
}

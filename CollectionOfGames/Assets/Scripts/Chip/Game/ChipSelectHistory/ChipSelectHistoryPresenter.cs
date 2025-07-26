using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipSelectHistoryPresenter : IChipSelectHistoryProvider
{
    private readonly ChipSelectHistoryView _view;

    public ChipSelectHistoryPresenter(ChipSelectHistoryView view)
    {
        _view = view;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {

    }

    #region Input

    public void Activate(int number)
    {
        _view.Activate(number);
    }

    public void Deactivate()
    {
        _view.Deactivate();
    } 

    #endregion
}

public interface IChipSelectHistoryProvider
{
    void Activate(int number);
    void Deactivate();
}

using System;
using UnityEngine;

public class BetCell : MonoBehaviour, IBetCell
{
    public Bet Bet => bet;
    [SerializeField] private Bet bet;

    public event Action<BetCell, Chip, Bet> OnChooseCell;
    public event Action<BetCell, Chip, Bet> OnResetCell;

    public void ChooseBet(Chip chip)
    {
        OnChooseCell?.Invoke(this, chip, bet);
    }

    public void ResetBet(Chip chip)
    {
        OnResetCell?.Invoke(this, chip, bet);
    }
}

public interface IBetCell
{
    void ChooseBet(Chip chipData);
    void ResetBet(Chip chipData);
}

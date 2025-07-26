using System;
using System.Numerics;

public class ChipGameVisualModel
{
    public event Action<int, Chip, int, TypeCell, Vector3> OnAddChip;
    public event Action<int, int, Action> OnReturnChip;
    public event Action<int, int> OnFallenChip;

    private readonly IBetChipEventsProvider _betChipEventsProvider;
    private readonly IPseudoChipVisualProvider _pseudoChipVisualProvider;
    private readonly IChipSelectHistoryProvider _chipSelectHistoryProvider;

    public ChipGameVisualModel(IBetChipEventsProvider betChipEventsProvider, IPseudoChipVisualProvider pseudoChipVisualProvider, IChipSelectHistoryProvider chipSelectHistoryProvider)
    {
        _betChipEventsProvider = betChipEventsProvider;
        _pseudoChipVisualProvider = pseudoChipVisualProvider;
        _chipSelectHistoryProvider = chipSelectHistoryProvider;
    }

    public void Initialize()
    {
        _betChipEventsProvider.OnAddChip += AddChip;
        _betChipEventsProvider.OnReturnChip += ReturnChip;
        _betChipEventsProvider.OnFallenChip += FallenChip;
    }

    public void Dispose()
    {
        _betChipEventsProvider.OnAddChip -= AddChip;
        _betChipEventsProvider.OnReturnChip -= ReturnChip;
        _betChipEventsProvider.OnFallenChip -= FallenChip;
    }

    private void AddChip(int id, Chip chip, int positionIndex, TypeCell typeCell, Vector3 vectorPosition)
    {
        _pseudoChipVisualProvider.Hide();
        _chipSelectHistoryProvider.Activate(positionIndex);

        OnAddChip?.Invoke(id, chip, positionIndex, typeCell, vectorPosition);
    }


    private void ReturnChip(int idChipGroup, int indexPosition)
    {
        _chipSelectHistoryProvider.Deactivate();

        OnReturnChip?.Invoke(idChipGroup, indexPosition, _pseudoChipVisualProvider.Show);
    }

    private void FallenChip(int chipId, int indexPositions)
    {
        _pseudoChipVisualProvider.Show();
        _chipSelectHistoryProvider.Deactivate();

        OnFallenChip?.Invoke(chipId, indexPositions);
    }

}

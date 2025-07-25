using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PseudoChipView : View
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private List<PseudoChip> pseudoChips = new List<PseudoChip>();

    [SerializeField] private PseudoChip currentPseudoChip;

    public void Initialize()
    {
        for (int i = 0; i < pseudoChips.Count; i++)
        {
            pseudoChips[i].OnGrabbing += OnGrabPseudoChip;
            pseudoChips[i].Initialize();
        }
    }

    public void Dispose()
    {
        for (int i = 0; i < pseudoChips.Count; i++)
        {
            pseudoChips[i].OnGrabbing -= OnGrabPseudoChip;
            pseudoChips[i].Dispose();
        }
    }

    public void Show()
    {
        pseudoChips.ForEach(data => data.Show());
    }

    public void Hide()
    {
        pseudoChips.ForEach(data => data.Hide());
    }

    public void GrabPseudoChip(PseudoChip chip)
    {
        UngrabCurrentPseudoChip();

        currentPseudoChip = chip;

        currentPseudoChip.OnStartMove += OnStartMove;
        currentPseudoChip.OnMove += OnMove;
        currentPseudoChip.OnEndMove += OnEndMove;
    }

    public void UngrabCurrentPseudoChip()
    {
        if (currentPseudoChip != null)
        {
            currentPseudoChip.OnStartMove -= OnStartMove;
            currentPseudoChip.OnMove -= OnMove;
            currentPseudoChip.OnEndMove -= OnEndMove;

            Teleport();
        }
    }

    public void Teleport()
    {
        currentPseudoChip.Teleport();
    }

    public void StartMove()
    {
        currentPseudoChip.StartMove();
    }

    public void EndMove()
    {
        currentPseudoChip.EndMove();
    }

    public void Move(Vector2 vector)
    {
        currentPseudoChip.Move(vector);
    }

    #region Input

    public void OnGrabPseudoChip(PseudoChip pseudoChip)
    {
        OnGrabPseudoChip_Action?.Invoke(pseudoChip);
    }

    private void OnMove(Vector2 vector)
    {
        OnMove_Action?.Invoke(vector / canvas.scaleFactor);
    }

    private void OnStartMove()
    {
        OnStartMove_Action?.Invoke();
    }

    private void OnEndMove(int id, Chip chip, Transform transform)
    {
        OnEndMove_Action?.Invoke(id, chip, transform);
    }

    public event Action<PseudoChip> OnGrabPseudoChip_Action;

    public event Action<Vector2> OnMove_Action;

    public event Action OnStartMove_Action;

    public event Action<int, Chip, Transform> OnEndMove_Action;

    #endregion
}

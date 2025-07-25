using System;
using UnityEngine;

public class PseudoChipModel
{
    public event Action OnUngrabCurrentPseudoChip;
    public event Action<PseudoChip> OnGrabPseudoChip;
    //public event Action<ChipData, ICell, Vector2> OnSpawnChip;

    public event Action OnStartMove;
    public event Action<Vector2> OnMove;
    public event Action OnEndMove;
    public event Action OnTeleporting;

    private bool isActive = true;

    private ISoundProvider _soundProvider;

    public PseudoChipModel(ISoundProvider soundProvider)
    {
        _soundProvider = soundProvider;
    }

    public void GrabPseudoChip(PseudoChip pseudoChip)
    {
        OnUngrabCurrentPseudoChip?.Invoke();

        //soundProvider.PlayOneShot("ChipGrab");

        OnGrabPseudoChip?.Invoke(pseudoChip);
    }

    public void StartMove()
    {
        if (!isActive) return;

        OnStartMove?.Invoke();
    }

    public void Move(Vector2 vector)
    {
        if (!isActive) return;

        OnMove?.Invoke(vector);
    }

    public void EndMove(int id, Chip chip, Transform transform)
    {
        if (!isActive) return;

        Collider2D collider = Physics2D.OverlapPoint(transform.position);

        if(collider != null)
        {
            Debug.Log(collider.gameObject.name);

            if(collider.gameObject.TryGetComponent(out ICell cell))
            {
                Debug.Log(collider.gameObject.name);

                cell.AddChip(id, chip, transform.position);
                Teleport();
                return;
            }
        }

        //_soundProvider.PlayOneShot("Whoosh");
        OnEndMove?.Invoke();
    }

    public void Teleport()
    {
        OnTeleporting?.Invoke();
    }

    public void Activate()
    {
        isActive = true;
    }


    public void Deactivate()
    {
        isActive = false;
    }
}

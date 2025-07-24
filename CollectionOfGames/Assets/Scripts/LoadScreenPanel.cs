using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreenPanel : MovePanel
{
    [SerializeField] private List<AnimationElement> animationElementIcons;
    [SerializeField] private float timeWait;

    private IEnumerator timer;

    private void Awake()
    {
        animationElementIcons.ForEach(data => OnDeactivatePanel += data.Deactivate);

        Initialize();
    }

    private void OnDestroy()
    {
        if (timer != null) Coroutines.Stop(timer);

        animationElementIcons.ForEach(data => OnDeactivatePanel -= data.Deactivate);

        Dispose();
    }

    public override void ActivatePanel()
    {
        base.ActivatePanel();

        if (timer != null) Coroutines.Stop(timer);

        timer = Timer();
        Coroutines.Start(timer);
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(timeWait);

        animationElementIcons.ForEach(data => data.Activate(1));
    }
}

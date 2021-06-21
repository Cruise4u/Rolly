using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public int gateID;
    Sequence movementSequence;

    public IEnumerator WaitForSecondsToStartAnimaton(float time)
    {
        yield return new WaitForSeconds(time);
        AnimateGateMovementUpwards();
    }
        
     public void AnimateGateMovementUpwards()
    {
        movementSequence = DOTween.Sequence();
        movementSequence.Append(transform.DOMove(new Vector3(transform.position.x, 5, transform.position.z), 1.25f, false).SetEase(Ease.Linear));
    }

}
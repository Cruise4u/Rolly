using DG.Tweening;
using UnityEngine;

public class GoalTweenAnimation : MonoBehaviour
{
    public float[] starYPositions;

    Sequence movementSequence;

    public void CreateStarAnimationSequence()
    {
        movementSequence = DOTween.Sequence();
        var initialPosition = transform.position;
        movementSequence.Append(transform.DOMove(new Vector3(transform.position.x, initialPosition.y - 0.5f, transform.position.z), 1.25f, false).SetEase(Ease.Linear));
        movementSequence.Append(transform.DOMove(new Vector3(transform.position.x, initialPosition.y + 0.5f, transform.position.z), 1.25f, false).SetEase(Ease.Linear));
        movementSequence.Append(transform.DOMove(new Vector3(transform.position.x, initialPosition.y, transform.position.z), 1.25f, false).SetEase(Ease.Linear));
        movementSequence.OnComplete(RestartStarAnimationSequence);
    }

    public void RestartStarAnimationSequence()
    {
        movementSequence.Restart(true, 0.5f);
    }

    public void Start()
    {
        CreateStarAnimationSequence();
    }

}

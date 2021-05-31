using DG.Tweening;
using UnityEngine;

public class StarGoalTween : MonoBehaviour
{
    public float[] starYPositions;

    Sequence movementSequence;

    public void CreateStarAnimationSequence()
    {
        movementSequence = DOTween.Sequence();
        movementSequence.Append(transform.DOMove(new Vector3(transform.position.x, starYPositions[0],transform.position.z), 1.25f, false).SetEase(Ease.Linear));
        movementSequence.Append(transform.DOMove(new Vector3(transform.position.x, starYPositions[1], transform.position.z), 1.25f, false).SetEase(Ease.Linear));
        movementSequence.Append(transform.DOMove(new Vector3(transform.position.x, starYPositions[2], transform.position.z), 1.25f, false).SetEase(Ease.Linear));
    }

    public void RestartStarAnimationSequence()
    {
        movementSequence.Restart(true, 0.5f);
    }

    public void PlayStarAnimationSequence()
    {
        movementSequence.Play().OnComplete(RestartStarAnimationSequence);
    }

    public void Start()
    {
        CreateStarAnimationSequence();
        PlayStarAnimationSequence();
    }

    public void Awake()
    {
        CreateStarAnimationSequence();
    }


}

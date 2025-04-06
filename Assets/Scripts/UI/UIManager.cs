using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Animator _alienAnimator;

    private WaitForSeconds _waitForOneSecond = new WaitForSeconds(1);

    private void Awake()
    {
        HitDetection.OnCarHitCharacter += AnimateAlienToDance;
    }

    private void OnDestroy()
    {
        HitDetection.OnCarHitCharacter -= AnimateAlienToDance;
    }

    private void AnimateAlienToDance()
    {
        StartCoroutine(AnimateDanceThenStop());
    }

    private IEnumerator AnimateDanceThenStop()
    {
        _alienAnimator.SetBool("IsHit", true);
        yield return _waitForOneSecond;
        _alienAnimator.SetBool("IsHit", false);
    }
}
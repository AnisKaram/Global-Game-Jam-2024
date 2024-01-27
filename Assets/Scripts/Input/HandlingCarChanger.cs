using System.Collections;
using UnityEngine;

public class HandlingCarChanger : MonoBehaviour
{
    [SerializeField] private HandlingCarChangerPresenter _handlingCarChangerPresenter;
    [SerializeField] private Handling _handling;

    private void Awake()
    {
        _handling = Handling.AD;
    }

    private void Start()
    {
        StartCoroutine(ChangeBinding());
    }

    private IEnumerator ChangeBinding()
    {
        yield return new WaitForSeconds(Random.Range(3, 6));

        int randomEnumValue = Random.Range(0, 4);
        _handling = (Handling)randomEnumValue;

        InputManager.Instance.Handling = _handling;

        _handlingCarChangerPresenter.ChangeKeybindingsOnUI(_handling);

        StartCoroutine(ChangeBinding());
    }
}

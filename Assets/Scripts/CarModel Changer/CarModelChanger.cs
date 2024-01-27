using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarModelChanger : MonoBehaviour
{
    [SerializeField] private CarPickerSO _carPickerSO;
    [SerializeField] private List<GameObject> _listOfCarModels;
    [SerializeField] private CameraFollowController _cameraFollowController;

    [SerializeField] private Transform _carInstantiationPosition;

    private GameObject _carInstance;
    private int _carInstanceValue;

    private void Awake()
    {
        _carInstanceValue = _carPickerSO.carInstanceValue;

        _carInstance = Instantiate(_listOfCarModels[_carInstanceValue], _carInstantiationPosition);
        Transform cameraParentInCar = _carInstance.transform.GetChild(5);
        _cameraFollowController.CameraPosition = cameraParentInCar.GetChild(0);
        _cameraFollowController.LookAtTargetPosition = cameraParentInCar.GetChild(1);
    }
}
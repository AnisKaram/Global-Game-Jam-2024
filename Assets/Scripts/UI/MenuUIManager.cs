using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private CarPickerSO _carPickerSO;
    [SerializeField] private Button _sedanCarButton;
    [SerializeField] private Button _truckCarButton;
    [SerializeField] private Button _ambulanceCarButton;
    [SerializeField] private Button _playButton;

    [SerializeField] private List<GameObject> _listOfPickedImages;

    private void Awake()
    {
        _sedanCarButton.onClick.AddListener(new UnityAction(() => { OnCarButtonClicked(0); }));
        _truckCarButton.onClick.AddListener(new UnityAction(() => { OnCarButtonClicked(1); }));
        _ambulanceCarButton.onClick.AddListener(new UnityAction(() => { OnCarButtonClicked(2); }));
        _playButton.onClick.AddListener(new UnityAction(OnPlayButtonClicked));

        _carPickerSO.carInstanceValue = LoadCarPicked();

        UpdatePickedImages(_carPickerSO.carInstanceValue);
    }

    private void OnPlayButtonClicked()
    {
        SceneManager.LoadSceneAsync(1);
    }

    private void OnCarButtonClicked(int carIndex)
    {
        _carPickerSO.carInstanceValue = carIndex;
        SaveCarPicked(carIndex);
        UpdatePickedImages(carIndex);
    }

    private void UpdatePickedImages(int carIndex)
    {
        for (int i = 0; i < _listOfPickedImages.Count; i++)
        {
            if (i == carIndex)
            {
                _listOfPickedImages[i].SetActive(true);
            }
            else
            {
                _listOfPickedImages[i].SetActive(false);
            }
        }
    }

    private void SaveCarPicked(int carIndex)
    {
        PlayerPrefs.SetInt("car_picked", carIndex);
        PlayerPrefs.Save();
    }

    private int LoadCarPicked()
    {
        if (PlayerPrefs.HasKey("car_picked"))
        {
            return PlayerPrefs.GetInt("car_picked");
        }
        return 0;
    }
}

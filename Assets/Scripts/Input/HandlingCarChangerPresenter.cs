using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandlingCarChangerPresenter : MonoBehaviour
{
    [SerializeField] private List<Image> _listOfLeftRightBindings;

    [SerializeField] private List<Sprite> _adKeybindings;
    [SerializeField] private List<Sprite> _qeKeybindings;
    [SerializeField] private List<Sprite> _zcKeybindings;
    [SerializeField] private List<Sprite> _13Keybindings;

    public void ChangeKeybindingsOnUI(Handling handling)
    {
        switch (handling)
        {
            case Handling.AD:
                for (int i = 0; i < _listOfLeftRightBindings.Count; i++)
                {
                    _listOfLeftRightBindings[i].sprite = _adKeybindings[i];
                }
                break;
            case Handling.QE:
                for (int i = 0; i < _listOfLeftRightBindings.Count; i++)
                {
                    _listOfLeftRightBindings[i].sprite = _qeKeybindings[i];
                }
                break;
            case Handling.ZC:
                for (int i = 0; i < _listOfLeftRightBindings.Count; i++)
                {
                    _listOfLeftRightBindings[i].sprite = _zcKeybindings[i];
                }
                break;
            case Handling.OneThree:
                for (int i = 0; i < _listOfLeftRightBindings.Count; i++)
                {
                    _listOfLeftRightBindings[i].sprite = _13Keybindings[i];
                }
                break;
            default:
                break;
        }
    }
}

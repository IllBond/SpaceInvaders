using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    [SerializeField] private GameObject _buttonPause;
    [SerializeField] private GameObject _fieldMenu;

    public void OpenMenu() {
        Time.timeScale = 0;
        _buttonPause.SetActive(false);
        _fieldMenu.SetActive(true);
    }    
    
    public void CloseMenu() {
        Time.timeScale = 1;
        _buttonPause.SetActive(true);
        _fieldMenu.SetActive(false);
    }
}

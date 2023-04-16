using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_UIManager : MonoBehaviour
{
    [SerializeField] SO_Object so_Object;
    [SerializeField] SO_Player so_player;
    [SerializeField] GameObject UI_MenuPanel;
    [SerializeField] GameObject FadePanel;
    [SerializeField] Text UI_SpeedText;
    [SerializeField] Text UI_MoneyText;
    [SerializeField] Slider UI_HappySlider;
    S_SceneManager _sceneManagaer;

    public bool Menuactive;

    int _tempMoney = 0;
    int _tempHappy = 0;

    private void Start()
    {
        _sceneManagaer = GameObject.Find("GameManager").GetComponent<S_SceneManager>();
        S_SoundManager.Instance.PlayBGMSound();

        UI_HappySlider.maxValue = 100;

        UI_MoneyText.text = so_player.Money.ToString();
        UI_HappySlider.value = so_player.HappyCount;
    }
    private void Update()
    {
        if(_tempMoney != so_player.Money)
        {
            UI_MoneyText.text = so_player.Money.ToString();
            _tempMoney = so_player.Money;
        }
        if(_tempHappy != so_player.HappyCount)
        {
            UI_HappySlider.value = so_player.HappyCount;
            _tempHappy = so_player.HappyCount;
        }
    }
    public void MenuPanel(bool _isOpen)
    {
        if(_isOpen)
        {
            UI_MenuPanel.SetActive(true);
            so_Object.setEnabled(true);
            so_player.setMove(false);
        }
        else
        {
            UI_MenuPanel.SetActive(false);
            so_Object.setEnabled(false);
        }
        Menuactive = _isOpen;
    }

    public void SpeedText(float _speed)
    {
        UI_SpeedText.text = _speed.ToString();
    }

    public void MainPanel()
    {
        StartCoroutine(gotoMain());
    }

    IEnumerator gotoMain()
    {
        so_Object.setEnabled(true);
        so_player.setMove(false);
        FadePanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        StartCoroutine(_sceneManagaer.LoadScene("00_MainScene"));
    }
}

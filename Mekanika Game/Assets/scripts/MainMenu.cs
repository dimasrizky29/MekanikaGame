using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject ShopPanel;
    public GameObject CreditPanel;
    public GameObject CoinValue;
    // Start is called before the first frame update
    void Start()
    {
        MenuPanel.SetActive(true);
        ShopPanel.SetActive(false);
        CreditPanel.SetActive(false);
        CoinValue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButtonClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ShopButtonClicked()
    {
        MenuPanel.SetActive(false);
        ShopPanel.SetActive(true);
        CreditPanel.SetActive(false);
        CoinValue.SetActive(false);
    }
    public void CreditButtonClicked()
    {
        MenuPanel.SetActive(false);
        ShopPanel.SetActive(false);
        CreditPanel.SetActive(true);
        CoinValue.SetActive(false);
    }
    public void Quit_Clicked()
    {
        Application.Quit();
    }
    public void BackButtonClicked()
    {
        MenuPanel.SetActive(true);
        ShopPanel.SetActive(false);
        CreditPanel.SetActive(false);
        CoinValue.SetActive(false);
    }

    public void UpgradeButtonClicked()
    {
        if (PlayerMove.saveCoin >= 10)
        {
            PlayerMove.saveCoin -= 10;
            PlayerMove.upgrade += 4f;
            CoinValue.SetActive(false);
        }
        else
        {
            CoinValue.SetActive(true);
        }
    }
}

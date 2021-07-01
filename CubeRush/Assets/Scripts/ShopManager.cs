using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    public GameObject[] hats; 
    public GameObject[] skins;

    public Button[] buttons;

    public MeshRenderer heroMR;

    public GameObject AllItemsPurchasedPanel;

    private void Start() 
    {
        LoadItems();
    }

    public void BuyItem()
    {
        if (PlayerPrefs.GetInt("item1") == 0 ||
            PlayerPrefs.GetInt("item2") == 0 ||
            PlayerPrefs.GetInt("item3") == 0 ||
            PlayerPrefs.GetInt("item4") == 0 ||
            PlayerPrefs.GetInt("item5") == 0 ||
            PlayerPrefs.GetInt("item6") == 0 ||
            PlayerPrefs.GetInt("item7") == 0 ||
            PlayerPrefs.GetInt("item8") == 0 ||
            PlayerPrefs.GetInt("item9") == 0 ||
            PlayerPrefs.GetInt("item10") == 0 ||
            PlayerPrefs.GetInt("item11") == 0 ||
            PlayerPrefs.GetInt("item12") == 0)
        {
            int randomNumber;
            randomNumber = Random.Range(0, buttons.Length);

            if (buttons[randomNumber].interactable == false)
            {
                buttons[randomNumber].interactable = true;
                SaveItems();
            }
            else
            {
                BuyItem();
            }
        }
        else
        {
            AllItemsPurchasedPanel.SetActive(true);
        }
    }

    public void SaveItems()
    {
        if (buttons[0].interactable == true)
        {
            PlayerPrefs.SetInt("item1", 1);
        }
        if (buttons[1].interactable == true)
        {
            PlayerPrefs.SetInt("item2", 1);
        }
        if (buttons[2].interactable == true)
        {
            PlayerPrefs.SetInt("item3", 1);
        }
        if (buttons[3].interactable == true)
        {
            PlayerPrefs.SetInt("item4", 1);
        }
        if (buttons[4].interactable == true)
        {
            PlayerPrefs.SetInt("item5", 1);
        }
        if (buttons[5].interactable == true)
        {
            PlayerPrefs.SetInt("item6", 1);
        }
        if (buttons[6].interactable == true)
        {
            PlayerPrefs.SetInt("item7", 1);
        }
        if (buttons[7].interactable == true)
        {
            PlayerPrefs.SetInt("item8", 1);
        }
        if (buttons[8].interactable == true)
        {
            PlayerPrefs.SetInt("item9", 1);
        }
        if (buttons[9].interactable == true)
        {
            PlayerPrefs.SetInt("item10", 1);
        }
        if (buttons[10].interactable == true)
        {
            PlayerPrefs.SetInt("item11", 1);
        }
        if (buttons[11].interactable == true)
        {
            PlayerPrefs.SetInt("item12", 1);
        }
    }
    public void LoadItems()
    {
        if (PlayerPrefs.GetInt("item1") == 1)
        {
            buttons[0].interactable = true;
        }
        if (PlayerPrefs.GetInt("item2") == 1)
        {
            buttons[1].interactable = true;
        }
        if (PlayerPrefs.GetInt("item3") == 1)
        {
            buttons[2].interactable = true;
        }
        if (PlayerPrefs.GetInt("item4") == 1)
        {
            buttons[3].interactable = true;
        }
        if (PlayerPrefs.GetInt("item5") == 1)
        {
            buttons[4].interactable = true;
        }
        if (PlayerPrefs.GetInt("item6") == 1)
        {
            buttons[5].interactable = true;
        }
        if (PlayerPrefs.GetInt("item7") == 1)
        {
            buttons[6].interactable = true;
        }
        if (PlayerPrefs.GetInt("item8") == 1)
        {
            buttons[7].interactable = true;
        }
        if (PlayerPrefs.GetInt("item9") == 1)
        {
            buttons[8].interactable = true;
        }
        if (PlayerPrefs.GetInt("item10") == 1)
        {
            buttons[9].interactable = true;
        }
        if (PlayerPrefs.GetInt("item11") == 1)
        {
            buttons[10].interactable = true;
        }
        if (PlayerPrefs.GetInt("item12") == 1)
        {
            buttons[11].interactable = true;
        }
    }
    
    #region ItemsInShop
    public void Hat0()
    {
        hats[0].SetActive(false);
        hats[1].SetActive(false);
        hats[2].SetActive(false);
        hats[3].SetActive(false);
        hats[4].SetActive(false);
        hats[5].SetActive(false);
    }

    public void Hat1()
    {
        for (int i = 0; i < hats.Length; i++)
        {
            hats[0].SetActive(true);
            hats[1].SetActive(false);
            hats[2].SetActive(false);
            hats[3].SetActive(false);
            hats[4].SetActive(false);
            hats[5].SetActive(false);
        }
    }
    public void Hat2()
    {
        for (int i = 0; i < hats.Length; i++)
        {
            hats[0].SetActive(false);
            hats[1].SetActive(true);
            hats[2].SetActive(false);
            hats[3].SetActive(false);
            hats[4].SetActive(false);
            hats[5].SetActive(false);
        }
    }
    public void Hat3()
    {
        for (int i = 0; i < hats.Length; i++)
        {
            hats[0].SetActive(false);
            hats[1].SetActive(false);
            hats[2].SetActive(true);
            hats[3].SetActive(false);
            hats[4].SetActive(false);
            hats[5].SetActive(false);
        }
    }
    public void Hat4()
    {
        for (int i = 0; i < hats.Length; i++)
        {
            hats[0].SetActive(false);
            hats[1].SetActive(false);
            hats[2].SetActive(false);
            hats[3].SetActive(true);
            hats[4].SetActive(false);
            hats[5].SetActive(false);
        }
    }
    public void Hat5()
    {
        for (int i = 0; i < hats.Length; i++)
        {
            hats[0].SetActive(false);
            hats[1].SetActive(false);
            hats[2].SetActive(false);
            hats[3].SetActive(false);
            hats[4].SetActive(true);
            hats[5].SetActive(false);
        }
    }
    public void Hat6()
    {
        for (int i = 0; i < hats.Length; i++)
        {
            hats[0].SetActive(false);
            hats[1].SetActive(false);
            hats[2].SetActive(false);
            hats[3].SetActive(false);
            hats[4].SetActive(false);
            hats[5].SetActive(true);
        }
    }

    public void Skin1()
    {
        for (int i = 0; i < hats.Length; i++)
        {
            heroMR.enabled = true;
            skins[1].SetActive(false);
            skins[2].SetActive(false);
            skins[3].SetActive(false);
            skins[4].SetActive(false);
            skins[5].SetActive(false);
        }
    }
    public void Skin2()
    {
        for (int i = 0; i < hats.Length; i++)
        {
            heroMR.enabled = false;
            skins[1].SetActive(true);
            skins[2].SetActive(false);
            skins[3].SetActive(false);
            skins[4].SetActive(false);
            skins[5].SetActive(false);
        }
    }
    public void Skin3()
    {
        for (int i = 0; i < hats.Length; i++)
        {
            heroMR.enabled = false;
            skins[1].SetActive(false);
            skins[2].SetActive(true);
            skins[3].SetActive(false);
            skins[4].SetActive(false);
            skins[5].SetActive(false);
        }
    }
    public void Skin4()
    {
        for (int i = 0; i < hats.Length; i++)
        {
            heroMR.enabled = false;
            skins[1].SetActive(false);
            skins[2].SetActive(false);
            skins[3].SetActive(true);
            skins[4].SetActive(false);
            skins[5].SetActive(false);
        }
    }
    public void Skin5()
    {
        for (int i = 0; i < hats.Length; i++)
        {
            heroMR.enabled = false;
            skins[1].SetActive(false);
            skins[2].SetActive(false);
            skins[3].SetActive(false);
            skins[4].SetActive(true);
            skins[5].SetActive(false);
        }
    }
    public void Skin6()
    {
        for (int i = 0; i < hats.Length; i++)
        {
            heroMR.enabled = false;
            skins[1].SetActive(false);
            skins[2].SetActive(false);
            skins[3].SetActive(false);
            skins[4].SetActive(false);
            skins[5].SetActive(true);
        }
    }
    #endregion
}

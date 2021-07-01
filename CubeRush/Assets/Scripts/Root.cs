using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Root : MonoBehaviour
{

    public ShopManager shpMng;

    GameObject hero;

    public GameObject quitMenu;
    public GameObject restartMenu;

    [HideInInspector]
    public int stage;
    [HideInInspector]
    public int unlockedStages;
    [HideInInspector]
    public int remainingAds = 3;

    public GameObject imgSound1;
    public GameObject imgSound2;

    public GameObject imgMusic1;
    public GameObject imgMusic2;

    public GameObject infoPanel;
    public GameObject scoreHint;
    public GameObject skipLevel;
    public GameObject rewardCoins;

    public AudioSource backgroundMusic;
    public AudioSource jumpSound;
    public AudioSource restartSound;

    bool music = true;
    bool sound = true;

    public Button[] button;

    public GameObject[] rotate3;
    public GameObject[] rotate4;

    public GameObject stageUI;
    public GameObject highscoreUI;

    public GameObject stagePanel;
    public GameObject highscorePanel;

    float timer;

    private string storeId = "3472918";
    private string banner = "banner";

    public Text txtStage;
    public Text txtCoins;
    public Text txtRemainingAds;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        hero = GameObject.Find("Hero");
        stage = PlayerPrefs.GetInt("stage");
        GameObject.Find("Hero").GetComponent<Hero>().coins = PlayerPrefs.GetInt("coins");

        unlockedStages = PlayerPrefs.GetInt("unlockedStages");
    }

    private void Start()
    {

        Advertisement.Initialize(storeId, false);

        StartCoroutine(ShowBannerWhenReady());
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);

        remainingAds = 2;

        if (hero.GetComponent<Hero>().coins >= 100)
        {
            scoreHint.SetActive(true);
        }
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(banner))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(banner);
    }

    private void PurchaseManager_OnPurchaseNonConsumable(UnityEngine.Purchasing.PurchaseEventArgs args)
    {
        PlayerPrefs.SetInt("noAds", 1);
    }

    private void Update()
    {
        txtRemainingAds.text = remainingAds.ToString();
        txtStage.text = stage.ToString();
        txtCoins.text = GameObject.Find("Hero").GetComponent<Hero>().coins.ToString();

        Vector3 direction = hero.transform.position - this.transform.position;
        this.transform.Translate(0, 0, direction.z * 0.05f);

        GameObject.Find("hat").transform.position = hero.transform.position;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitMenu.SetActive(true);
        }

        for (int i = 0; i < button.Length; i++)
        {
            if (unlockedStages >= i)
            {
                button[i].interactable = true;
            }
        }
        if (unlockedStages >= 11)
        {
            button[11].interactable = true;
        }

        if (hero.transform.position.z > 720)
        {
            stageUI.SetActive(false);
            highscoreUI.SetActive(true);

            stagePanel.SetActive(false);
            highscorePanel.SetActive(true);
        }
        else
        {
            stageUI.SetActive(true);
            highscoreUI.SetActive(false);

            stagePanel.SetActive(true);
            highscorePanel.SetActive(false);
        }

        if (PlayerPrefs.GetInt("noAds") == 1)
        {
            Destroy(GameObject.Find("DisableAdsPanel"));
            Destroy(GameObject.Find("ads"));
        }

        if (music == true)
        {
            imgMusic1.SetActive(true);
            imgMusic2.SetActive(false);

            backgroundMusic.mute = false;
        }
        if (music == false)
        {
            imgMusic1.SetActive(false);
            imgMusic2.SetActive(true);

            backgroundMusic.mute = true;
        }

        if (sound == true)
        {
            imgSound1.SetActive(true);
            imgSound2.SetActive(false);
        }
        if (sound == false)
        {
            imgSound1.SetActive(false);
            imgSound2.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < rotate3.Length; i++)
        {
            rotate3[i].transform.Rotate(0, 0, 1.5f);
        }
        for (int i = 0; i < rotate4.Length; i++)
        {
            rotate4[i].transform.Rotate(0, 0, -2.75f);
        }
    }

    public void ShowVideoAd()
    {
        if (PlayerPrefs.GetInt("noAds") != 1)
        {
            if (Advertisement.IsReady("video"))
            {
                Advertisement.Show("video");
            }
        }
    }

    public void QuitTheGame()
    {
        PlayerPrefs.SetInt("coins", GameObject.Find("Hero").GetComponent<Hero>().coins);
        PlayerPrefs.SetInt("unlockedStages", unlockedStages);
        Application.Quit();
    }

    public void ClosePanel(GameObject toCancel)
    {
        toCancel.SetActive(false);
    }

    public void OpenPanel(GameObject toOpen)
    {
        toOpen.SetActive(true);
        scoreHint.SetActive(false);
    }

    public void Restart()
    {
        PlayerPrefs.SetInt("stage", 0);
        GameObject.Find("Hero").transform.position = new Vector3(0, -0.5f, 0);
        GameObject.Find("RestartPanel").SetActive(false);
    }

    public void SetStage(int set_stage)
    {
        stage = set_stage;
        hero.GetComponent<Hero>().Death();
    }

    public void BuyForCoins()
    {
        if (GameObject.Find("Hero").GetComponent<Hero>().coins >= 100)
        {
            GameObject.Find("Hero").GetComponent<Hero>().coins -= 100;
             
            shpMng.BuyItem();
        }
    }

    public void BuyForAds()
    {
        if (hero.GetComponent<Hero>().hsm.score < 1)
        {
            if (remainingAds > 0)
            {
                if (Advertisement.IsReady("rewardedVideo"))
                {
                    Advertisement.Show("rewardedVideo");
                    remainingAds--;
                }
            }
        }
        if (remainingAds == 0)
        {
            remainingAds = 2;

            shpMng.BuyItem();
        }
    }

    public void ButtonMusic()
    {
        if (music == true)
        {
            music = false;
        }
        else
        {
            music = true;
        }
    }
    public void ButtonSound()
    {
        if (sound == true)
        {
            sound = false;
        }
        else
        {
            sound = true;
        }
    }

    public void PlaySoundJump()
    {
        if (sound == true)
        {
            jumpSound.Play();
        }
    }
    public void PlaySoundRestart()
    {
        if (sound == true)
        {
            restartSound.Play();
        }
    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }

    public void WatchAdd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            Advertisement.Show("rewardedVideo");

            skipLevel.SetActive(false);

            stage++;

            hero.GetComponent<Hero>().Death();

            hero.GetComponent<Hero>().diesCountVideo = 0;
        }
    }

    public void UpdateUnlockedStages()
    {
        PlayerPrefs.SetInt("unlockedStages", unlockedStages);
    }
}
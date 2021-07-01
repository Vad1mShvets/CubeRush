using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    Root root;

    Rigidbody rb;
    Animator anim;
    public Animator camAnim;

    public HighscoreMode hsm;

    public GameObject firstSpawnTrigger;

    int moveForce = 22500;
    int rightleftForce = 16500;
    int jumpForce = 1000;

    public int diesCountVideo;
    int diesCountRewardedVideo;

    [HideInInspector]
    public int coins;

    public Image imgProgression;

    bool isGrounded = true;

    public GameObject pfbParticle;
    public GameObject menuPanel;
    public GameObject savingPanel;
    public GameObject savingPanelHighscore;

    public BoxCollider boxColl;
    public SphereCollider sphColl;

    float target;

    float timer;
    float timer2;
    float timer3;
    bool onTimer;

    bool clearLevels = false;

    private void Awake()
    {
        root = GameObject.Find("cam").GetComponent<Root>();
        rb = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
    }

    private void Start()
    {
        Death();
        SwipeController.SwipeEvent += CheckInput;
        target = 730;
        this.transform.Translate(0, 0, 2);
    }

    private void Update()
    {
        Progression(target);

        #region MovementForKeyboard
        if (Input.GetKeyDown("w"))
        {
            Forward();
        }
        if (Input.GetKeyDown("a"))
        {
            Left();
        }
        if (Input.GetKeyDown("s"))
        {
            Backward();
        }
        if (Input.GetKeyDown("d"))
        {
            Right();
        }
        #endregion

        if (this.transform.position.y <= -20 || this.transform.position.y >= 3)
        {
            Death();
        }

        if (this.transform.position.y <= -0.75f)
        {
            Physics.gravity = new Vector3(0, -300, 0);
        }
        else
        {
            Physics.gravity = new Vector3(0, -15, 0);
        }

        if (diesCountVideo == 10)
        {
            root.ShowVideoAd();
            diesCountVideo = 0;
        }

        if (diesCountRewardedVideo == 6)
        {
            root.skipLevel.SetActive(true);
            diesCountRewardedVideo = 0;
        }

        if (root.stage == 1 || root.stage == 2 || root.stage == 3 || root.stage == 4 || root.stage == 8 || root.stage == 9 || root.stage == 11)
        {
            moveForce = 22500;
            boxColl.enabled = false;
            sphColl.enabled = true;
            rb.freezeRotation = false;
        }
        else if (root.stage == 7)
        {
            moveForce = 16500;
            boxColl.enabled = false;
            sphColl.enabled = true;
            rb.freezeRotation = true;
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0f);
        }
        else
        {
            moveForce = 22500;
            boxColl.enabled = true;
            sphColl.enabled = false;
            rb.freezeRotation = true;
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0f);
        }

        if (onTimer == true)
        {
            savingPanel.SetActive(true);

            timer += Time.deltaTime;
            if (timer > 1.5f)
            {
                savingPanel.SetActive(false);
                onTimer = false;
                timer = 0;
            }
        }

        if (clearLevels == true)
        {
            Destroy(GameObject.Find("stageHighScore(Clone)"));
            timer2 += Time.deltaTime;
            if (timer2 > 1)
            {
                clearLevels = false;
                timer2 = 0;
            }
        }

        if (savingPanelHighscore.activeSelf == true)
        {
            timer3 += Time.deltaTime;
            if (timer3 > Random.Range(3,5))
            {
                timer3 = 0;
                savingPanelHighscore.SetActive(false);
            }
        }
    }

    void CheckInput(SwipeController.SwipeType type)
    {

        if (type == SwipeController.SwipeType.LEFT)
            Left();
        else if (type == SwipeController.SwipeType.RIGHT)
            Right();
        else if (type == SwipeController.SwipeType.UP)
            Forward();
        else if (type == SwipeController.SwipeType.DOWN)
            Backward();
        else
            return;
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;

        if (collision.gameObject.name == "torus")
        {
            Death();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.name == "spawnTrigger")
        {
            hsm.SpawnLevel();
            other.gameObject.SetActive(false);
            hsm.ScoreTrigger();
        }

        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            coins++;
            hsm.score += Random.Range(5, 15);
        }

        if (other.name.Contains("Finish"))
        {
            diesCountRewardedVideo = 0;
            onTimer = true;
        }

        #region Finish
        if (other.name == "Finish1")
        {
            root.stage = 1;
            PlayerPrefs.SetInt("stage", 1);
            if (root.unlockedStages <= 1)
            {
                root.unlockedStages = 1;
            }
        }
        if (other.name == "Finish2")
        {
            root.stage = 2;
            PlayerPrefs.SetInt("stage", 2);
            if (root.unlockedStages <= 2)
            {
                root.unlockedStages = 2;
            }
        }
        if (other.name == "Finish3")
        {
            root.stage = 3;
            PlayerPrefs.SetInt("stage", 3);
            if (root.unlockedStages <= 3)
            {
                root.unlockedStages = 3;
            }
        }
        if (other.name == "Finish4")
        {
            root.stage = 4;
            PlayerPrefs.SetInt("stage", 4);
            if (root.unlockedStages <= 4)
            {
                root.unlockedStages = 4;
            }
        }
        if (other.name == "Finish5")
        {
            root.stage = 5;
            PlayerPrefs.SetInt("stage", 5);
            if (root.unlockedStages <= 5)
            {
                root.unlockedStages = 5;
            }
        }
        if (other.name == "Finish6")
        {
            root.stage = 6;
            PlayerPrefs.SetInt("stage", 6);
            if (root.unlockedStages <= 6)
            {
                root.unlockedStages = 6;
            }
        }
        if (other.name == "Finish7")
        {
            root.stage = 7;
            PlayerPrefs.SetInt("stage", 7);
            if (root.unlockedStages <= 7)
            {
                root.unlockedStages = 7;
            }
        }
        if (other.name == "Finish8")
        {
            root.stage = 8;
            PlayerPrefs.SetInt("stage", 8);
            if (root.unlockedStages <= 8)
            {
                root.unlockedStages = 8;
            }
        }
        if (other.name == "Finish9")
        {
            root.stage = 9;
            PlayerPrefs.SetInt("stage", 9);
            if (root.unlockedStages <= 9)
            {
                root.unlockedStages = 9;
            }
        }
        if (other.name == "Finish10")
        {
            root.stage = 10;
            PlayerPrefs.SetInt("stage", 10);
            if (root.unlockedStages <= 10)
            {
                root.unlockedStages = 10;
            }
        }
        if (other.name == "Finish11")
        {
            root.stage = 11;
            PlayerPrefs.SetInt("stage", 11);
            if (root.unlockedStages <= 11)
            {
                root.unlockedStages = 11;
            }
        }
        #endregion

        if (other.name == "falling")
        {
            other.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    void Progression(float targetPosition)
    {
        float heroPosition = this.transform.position.z;

        float progression = (heroPosition / targetPosition) * 1;

        imgProgression.fillAmount = progression;
    }

    #region MovementFunctions

    void JumpMovement()
    {
        root.PlaySoundJump();
        isGrounded = false;
        GameObject c = Instantiate(pfbParticle);
        c.transform.position = this.transform.position;
        Destroy(c, 1);
    }

    public void Forward()
    {
        if (isGrounded == true && savingPanelHighscore.activeSelf == false)
        {
            if (root.stage != 7)
            {
                rb.AddForce(new Vector3(0, jumpForce, moveForce));
            }
            else
            {
                this.transform.Translate(0, 0, 2f);
            }

            anim.Play("moveForwBackw");
            JumpMovement();
        }
    }
    public void Backward()
    {
        if (isGrounded == true && savingPanelHighscore.activeSelf == false)
        {
            if (root.stage != 7)
            {
                rb.AddForce(new Vector3(0, jumpForce, -moveForce));
            }
            else
            {
                this.transform.Translate(0, 0, -2f);
            }

            anim.Play("moveForwBackw");
            JumpMovement();
        }
    }
    public void Left()
    {
        if (isGrounded == true && savingPanelHighscore.activeSelf == false)
        {
            if (root.stage != 7)
            {
                rb.AddForce(new Vector3(-rightleftForce, jumpForce, 0));
            }
            else
            {
                this.transform.Translate(-2, 0, 0);
            }

            anim.Play("moveLeftRight");
            JumpMovement();
        }
    }
    public void Right()
    {
        if (isGrounded == true && savingPanelHighscore.activeSelf == false)
        {
            if (root.stage != 7)
            {
                rb.AddForce(new Vector3(rightleftForce, jumpForce, 0));
            }
            else
            {
                this.transform.Translate(2, 0, 0);
            }

            anim.Play("moveLeftRight");
            JumpMovement();
        }
    }
    #endregion

    public void StartGame()
    {
        camAnim.Play("startCamAnim");
        menuPanel.SetActive(false);
    }

    public void Death()
    {
        if (hsm.score >= 500)
        {
            coins += 75;
        }

        if (this.transform.position.z > 720)
        {
            savingPanelHighscore.SetActive(true);
        }

        root.UpdateUnlockedStages();

        clearLevels = true;

        hsm.score = 0;

        GameObject spawnTrigger = Instantiate(firstSpawnTrigger);
        spawnTrigger.name = "spawnTrigger";

        hsm.spawnPosition = 670;

        root.PlaySoundRestart();

        diesCountVideo += 1;
        diesCountRewardedVideo += 1;

        PlayerPrefs.SetInt("coins", GameObject.Find("Hero").GetComponent<Hero>().coins);

        #region Respawn Positions
        if (root.stage == 0)
        {
            this.transform.position = new Vector3(0, 0, 0);

        }
        if (root.stage == 1)
        {
            this.transform.position = new Vector3(0, 0, 58);

        }
        if (root.stage == 2)
        {
            this.transform.position = new Vector3(0, 0, 122);

        }
        if (root.stage == 3)
        {
            this.transform.position = new Vector3(0, 0, 179);

        }
        if (root.stage == 4)
        {
            this.transform.position = new Vector3(0, 0, 252);

        }
        if (root.stage == 5)
        {
            this.transform.position = new Vector3(0, 0, 313);

        }
        if (root.stage == 6)
        {
            this.transform.position = new Vector3(0, 0, 386);

        }
        if (root.stage == 7)
        {
            this.transform.position = new Vector3(0, 0, 454.5f);

        }
        if (root.stage == 8)
        {
            this.transform.position = new Vector3(0, 0, 530);

        }
        if (root.stage == 9)
        {
            this.transform.position = new Vector3(0, 0, 592);

        }
        if (root.stage == 10)
        {
            this.transform.position = new Vector3(0, 0, 663);

        }
        if (root.stage == 11)
        {
            this.transform.position = new Vector3(0, 0, 721);

        }
        #endregion
    }
}

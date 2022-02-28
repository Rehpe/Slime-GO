using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;


public class gameManager : MonoBehaviour

{
    public static gameManager I;

    public float maxHp = 60f;
    public float currentHp;
    public float minusHp = 1f;
    public float speed;

    public int totalScore = 0;
    public int totalCoin = 0;
    int evolveBonus = 0;
    public int itemCoin;
    public int finalScore;
    public int totalFirePoint = 0;
    public int totalWaterPoint = 0;
    public int totalElecPoint = 0;
    public float timeLimit;

    public int bestScore = 0;

    public Text coinText;
    public Text scoreText;
    public Text finalScoreText;
    public Text inGameFirePointValue;
    public Text inGameWaterPointValue;
    public Text inGameElecPointValue;
    public Text bestScoreText;

    public GameObject GameOverPanel;
    public GameObject IngameSettingPanel;

      /* < ��ȭ ���� > */

    public GameObject EvolveBonusText;
    public Text EvolveBonusValue;
    public GameObject ItemBonusText;
    public Text ItemBonusValue;

    void Awake() //�̱��� �ڵ�
    {
        if (I == null)
        {
            I = this;
        }
        /*else
        {
            Destroy(this.gameObject);
        }*/
    }

  /*  public static gameManager Instance
    {
        get
        {
            if (I == null)
            {
                return null;
            }
            return I;
        }
    }*/

    // Start is called before the first frame update
    void Start()
    {
        initGame();
    }

    // Update is called once per frame
    void Update()
    {
        intoText(); //ȹ���� ������ ���� ����Ʈ Text�� ��ȯ
        
        
        currentHp -= minusHp * Time.deltaTime; // �ð��� �帣�� ü�� ���� ��ġ�� ���� ü���� ����
        GameObject.Find("Player").GetComponent<Player>().PlayerMove(this.speed);

        if (currentHp < 0) // �ð��� �� ���� ��
        {
            Time.timeScale = 0.0f; // �ð� �帧 ����

            soundManager.I.PlayBgm("Stop");
            sfxManager.I.PlaySfx("GameOver");
            
            currentHp = 0.0f; // ü�� ���̳ʽ� �ȵǰ� 0���� ����
            addCoin(); //���� ����
            dataManager.I.SaveData(); //���� ������ ���̺�


            if (finalScore > bestScore) //���� ���� ���ھ ����Ʈ ���ھ�� ������
            {
                PlayerPrefs.SetInt("bestScore", finalScore);
            }

            bestScore = PlayerPrefs.GetInt("bestScore", 0);

            bestScoreText.text = bestScore.ToString(); //����Ʈ ���ھ� ���


            GameOverPanel.SetActive(true); //���� ���� �г� Ȱ��ȭ
            
           
            //��ȭ ����

            if (GameObject.Find("Player").GetComponent<Player>().is3rdEvolved == true) //3�� ��ȭ�� �ߴ°�?
            {
                EvolveBonusText.SetActive(true); //���ʽ� ���� �г� Ȱ��ȭ
                EvolveBonusValue.text = 650.ToString();
            }
            else if (GameObject.Find("Player").GetComponent<Player>().is2ndEvolved == true) //2�� ��ȭ�� �ߴ°�?
            {
                EvolveBonusText.SetActive(true); //���ʽ� ���� �г� Ȱ��ȭ
                EvolveBonusValue.text = 150.ToString();
            }
            else if (GameObject.Find("Player").GetComponent<Player>().is1stEvolved == true) //1�� ��ȭ�� �ߴ°�?
            {
                EvolveBonusText.SetActive(true); //���ʽ� ���� �г� Ȱ��ȭ
                EvolveBonusValue.text = 50.ToString();
            }

        }
    }

    public void initGame() //����� �� ���� �ʱ�ȭ �Լ�
    {
        Time.timeScale = 1.0f;
        this.speed = 700f;
        totalScore = 0;
        totalFirePoint = 0;
        totalWaterPoint = 0;
        totalElecPoint = 0;
        evolveBonus = 0;
        GameObject.Find("Player").GetComponent<Player>().combo = 0;
        currentHp = maxHp;
        soundManager.I.PlayBgm("PlayScene");
        bestScore = PlayerPrefs.GetInt("bestScore", 0);


        dataManager.I.LoadData(); // ���� ������ �ε�
        Debug.Log(dataManager.I.PlayerCoin);
    }

    public void addScore(int score) // ������ ����
    {
        this.totalScore += score;
    }

    public void addFirePoint(int firePoint) //�� ���� ����Ʈ�� ����
    {
        this.totalFirePoint += firePoint;
    }

    public void addWaterPoint(int waterPoint) // �� ���� ����Ʈ�� ����
    {
        this.totalWaterPoint += waterPoint;
    }
    public void addElecPoint(int elecPoint) // ���� ���� ����Ʈ�� ����
    {
        this.totalElecPoint += elecPoint;
    }

    public void minusCurrentHp(float minusCurrentHP) //���̳ʽ� ��ġ�� ���� �� ü���� ����
    {
        this.currentHp += minusCurrentHP;
    }



    public void addCoin() //���� ����
    {
        if (GameObject.Find("Player").GetComponent<Player>().is3rdEvolved == true) //3�� ��ȭ��
        {
            evolveBonus = 650; //50(1�� ���ʽ�)+100(2�� ���ʽ�)+500(3�� ���ʽ�)
        }
        else if (GameObject.Find("Player").GetComponent<Player>().is2ndEvolved == true) //2�� ��ȭ��
        {
            evolveBonus = 150; //50(1�� ���ʽ�)+100(2�� ���ʽ�)
        }
        else if (GameObject.Find("Player").GetComponent<Player>().is1stEvolved == true) //1�� ��ȭ��
        {
            evolveBonus = 50;
        }
        finalScore = totalScore + evolveBonus;
        totalCoin = finalScore + itemCoin; //�� ���� = �� ���� + ��ȭ���ʽ�
        coinText.text = totalCoin.ToString();
        if (itemCoin > 0) //������ ������ �� ���̶� �Ծ��ٸ�
        {
            ItemBonusText.SetActive(true);
            ItemBonusValue.text = itemCoin.ToString();
        }

        dataManager.I.PlayerCoin += totalCoin; //�÷��̾��� ��ȭ�� ���� ������ ����
    }

    public void intoText()
    {
        inGameFirePointValue.text = totalFirePoint.ToString();//�� ���� ����Ʈ Text ��ȯ
        inGameWaterPointValue.text = totalWaterPoint.ToString(); //�� ���� ����Ʈ Text ��ȯ
        inGameElecPointValue.text = totalElecPoint.ToString();// ���� ���� ����Ʈ Text ��ȯ

        finalScoreText.text = finalScore.ToString();
    }

    public void retry()
    {
        SceneManager.LoadScene("MainScene");

        initGame();
    }

    public void toShop()
    {
        SceneManager.LoadScene("ShopScene");
    }

    public void toMain()
    {
        SceneManager.LoadScene("IntroScene");

    }

    public void openSettingPanel()
    {
        Time.timeScale = 0;
        IngameSettingPanel.SetActive(true);
    }

   
  
}



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

      /* < 진화 관련 > */

    public GameObject EvolveBonusText;
    public Text EvolveBonusValue;
    public GameObject ItemBonusText;
    public Text ItemBonusValue;

    void Awake() //싱글톤 코드
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
        intoText(); //획득한 점수와 원소 포인트 Text로 전환
        
        
        currentHp -= minusHp * Time.deltaTime; // 시간이 흐르면 체력 감소 수치에 따라 체력이 감소
        GameObject.Find("Player").GetComponent<Player>().PlayerMove(this.speed);

        if (currentHp < 0) // 시간이 다 됐을 때
        {
            Time.timeScale = 0.0f; // 시간 흐름 멈춤

            soundManager.I.PlayBgm("Stop");
            sfxManager.I.PlaySfx("GameOver");
            
            currentHp = 0.0f; // 체력 마이너스 안되고 0에서 멈춤
            addCoin(); //코인 정산
            dataManager.I.SaveData(); //게임 데이터 세이브


            if (finalScore > bestScore) //현재 최종 스코어가 베스트 스코어보다 높으면
            {
                PlayerPrefs.SetInt("bestScore", finalScore);
            }

            bestScore = PlayerPrefs.GetInt("bestScore", 0);

            bestScoreText.text = bestScore.ToString(); //베스트 스코어 출력


            GameOverPanel.SetActive(true); //게임 오버 패널 활성화
            
           
            //진화 관련

            if (GameObject.Find("Player").GetComponent<Player>().is3rdEvolved == true) //3차 진화를 했는가?
            {
                EvolveBonusText.SetActive(true); //보너스 점수 패널 활성화
                EvolveBonusValue.text = 650.ToString();
            }
            else if (GameObject.Find("Player").GetComponent<Player>().is2ndEvolved == true) //2차 진화를 했는가?
            {
                EvolveBonusText.SetActive(true); //보너스 점수 패널 활성화
                EvolveBonusValue.text = 150.ToString();
            }
            else if (GameObject.Find("Player").GetComponent<Player>().is1stEvolved == true) //1차 진화를 했는가?
            {
                EvolveBonusText.SetActive(true); //보너스 점수 패널 활성화
                EvolveBonusValue.text = 50.ToString();
            }

        }
    }

    public void initGame() //재시작 시 게임 초기화 함수
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


        dataManager.I.LoadData(); // 게임 데이터 로드
        Debug.Log(dataManager.I.PlayerCoin);
    }

    public void addScore(int score) // 점수가 오름
    {
        this.totalScore += score;
    }

    public void addFirePoint(int firePoint) //불 원소 포인트가 오름
    {
        this.totalFirePoint += firePoint;
    }

    public void addWaterPoint(int waterPoint) // 물 원소 포인트가 오름
    {
        this.totalWaterPoint += waterPoint;
    }
    public void addElecPoint(int elecPoint) // 전기 원소 포인트가 오름
    {
        this.totalElecPoint += elecPoint;
    }

    public void minusCurrentHp(float minusCurrentHP) //마이너스 수치가 있을 시 체력이 깎임
    {
        this.currentHp += minusCurrentHP;
    }



    public void addCoin() //코인 정산
    {
        if (GameObject.Find("Player").GetComponent<Player>().is3rdEvolved == true) //3차 진화시
        {
            evolveBonus = 650; //50(1단 보너스)+100(2단 보너스)+500(3단 보너스)
        }
        else if (GameObject.Find("Player").GetComponent<Player>().is2ndEvolved == true) //2차 진화시
        {
            evolveBonus = 150; //50(1단 보너스)+100(2단 보너스)
        }
        else if (GameObject.Find("Player").GetComponent<Player>().is1stEvolved == true) //1차 진화시
        {
            evolveBonus = 50;
        }
        finalScore = totalScore + evolveBonus;
        totalCoin = finalScore + itemCoin; //총 코인 = 총 점수 + 진화보너스
        coinText.text = totalCoin.ToString();
        if (itemCoin > 0) //아이템 코인을 한 번이라도 먹었다면
        {
            ItemBonusText.SetActive(true);
            ItemBonusValue.text = itemCoin.ToString();
        }

        dataManager.I.PlayerCoin += totalCoin; //플레이어의 재화에 얻은 코인을 더함
    }

    public void intoText()
    {
        inGameFirePointValue.text = totalFirePoint.ToString();//불 원소 포인트 Text 전환
        inGameWaterPointValue.text = totalWaterPoint.ToString(); //물 원소 포인트 Text 전환
        inGameElecPointValue.text = totalElecPoint.ToString();// 전기 원소 포인트 Text 전환

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



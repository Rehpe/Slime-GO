using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    /*public float speed = 4f;*/
    public float minusCurrentHp;
    public int pointAdd = 1;
    public int combo;

    public Animator PlayerAnim;
    public Animator FireEffectFrontAnim;
    public Animator FireEffectBackAnim;
    public Animator WaterEffectFrontAnim;
    public Animator WaterEffectBackAnim;
    public Animator ElecEffectFrontAnim;
    public Animator ElecEffectBackAnim;
    public Animator EvolveAnim;
    public Animator EvolveEffectAnim;
    public Animator ComboEffect;

    public bool is1stEvolved;
    public bool is2ndEvolved;
    public bool is3rdEvolved;

    public bool isFireEvolved;
    public bool isWaterEvolved;
    public bool isElecEvolved;

    public bool isItemUsing;

    public GameObject PointUI;
    public GameObject FireEvolveGageBar;
    public GameObject WaterEvolveGageBar;
    public GameObject ElecEvolveGageBar;

    public GameObject FireImg;
    public GameObject WaterImg;
    public GameObject ElecImg;

    public bool EvolveEffectOn = false;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        FireElementEvolve();
        WaterElementEvolve();
        ElecElementEvolve();
        
    }

    public void PlayerMove(float speed) //플레이어 이동 관련 함수
    {
        int zPos= 0;

        if (transform.localPosition.x > 500f) //화면의 양 끝을 만나면 반대로 향한다
        {
            gameManager.I.speed *= -1;
            transform.localPosition = new Vector3(Mathf.Min(transform.localPosition.x, 500f), -590f, 0f); //오른쪽 방향 전진시 플레이어 좌표가 2.8f 넘어가지 않게 처리
        }

        if (transform.localPosition.x < -500f)
        {
            gameManager.I.speed *= -1;
            transform.localPosition = new Vector3(Mathf.Max(transform.localPosition.x, -500f), -590f, 0f); // 왼쪽 방향 전진시 플레이어 좌표가 -2.8f 넘어가지 않게 처리
        }

        if (Input.GetMouseButtonDown(0)) //클릭하면 반대로 향한다
        {
            gameManager.I.speed *= -1;
            sfxManager.I.PlaySfx("PlayerTouch"); //터치하면 소리남
        }

        transform.localPosition += new Vector3(gameManager.I.speed * Time.deltaTime, 0, zPos);
        

    }

    void OnCollisionEnter2D(Collision2D coll)

    {

        if (coll.gameObject.tag == "elements") //원소를 먹었을 때
        {
            
            bool isfire = coll.gameObject.name.Contains("fire");
            bool iswater = coll.gameObject.name.Contains("water");
            bool iselec = coll.gameObject.name.Contains("elec");
            
           

            if (isfire) //불 원소일 경우
            {

                FireEffectFrontAnim.SetTrigger("EatFire");
                FireEffectBackAnim.SetTrigger("EatFire");

                if (isFireEvolved) // 불 진화 했을 시 스코어/점수 오름
                {
                    PlayerAnim.SetTrigger("EatElement"); //먹는 애니메이션 트리거 On
                    sfxManager.I.PlaySfx("EatElement");
                    gameManager.I.addScore(this.pointAdd); //점수 획득
                    gameManager.I.addFirePoint(this.pointAdd); //불 원소점수 획득
                    comboBonus(combo);
                    combo += 1;

                }
                else if (isWaterEvolved || isElecEvolved) // 물,전기 진화 시 점수 X, 체력 감소  
                {
                    PlayerAnim.SetTrigger("EatMinus"); //마이너스 애니메이션 트리거 On
                    sfxManager.I.PlaySfx("EatMinusElement");
                    gameManager.I.minusCurrentHp(-3);
                    combo = 0;
                }
                else //어떤 진화도 하지 않았을 경우
                {
                    PlayerAnim.SetTrigger("EatElement"); //먹는 애니메이션 트리거 On
                    sfxManager.I.PlaySfx("EatElement");
                    gameManager.I.addScore(this.pointAdd); //점수 획득
                    gameManager.I.addFirePoint(this.pointAdd); //불 원소점수 획득
                }

            }
            else if (iswater) //물 원소일 경우
            {
                WaterEffectFrontAnim.SetTrigger("EatWater"); // 물 원소 관련 이펙트 애니메이션 재생
                WaterEffectBackAnim.SetTrigger("EatWater");

                if (isWaterEvolved) // 물 진화 했을 시 스코어/점수 오름
                {
                    PlayerAnim.SetTrigger("EatElement"); //먹는 애니메이션 트리거 On
                    sfxManager.I.PlaySfx("EatElement");
                    gameManager.I.addScore(this.pointAdd); //점수 획득
                    gameManager.I.addWaterPoint(this.pointAdd); // 물 원소점수 획득
                    comboBonus(combo);
                    combo += 1;
                }
                else if (isFireEvolved || isElecEvolved) // 불,전기 진화 시 점수 X, 체력 감소  
                {
                    PlayerAnim.SetTrigger("EatMinus"); //마이너스 애니메이션 트리거 On
                    sfxManager.I.PlaySfx("EatMinusElement");
                    gameManager.I.minusCurrentHp(-3);
                    combo = 0;
                }
                else //어떤 진화도 하지 않았을 경우
                {
                    PlayerAnim.SetTrigger("EatElement"); //먹는 애니메이션 트리거 On
                    sfxManager.I.PlaySfx("EatElement");
                    gameManager.I.addScore(this.pointAdd); //점수 획득
                    gameManager.I.addWaterPoint(this.pointAdd); // 물 원소점수 획득
                }
            }
            else if (iselec) // 전기 원소일 경우
            {

                ElecEffectFrontAnim.SetTrigger("EatElec");
                ElecEffectBackAnim.SetTrigger("EatElec");

                if (isElecEvolved) // 전기 진화 했을 시 스코어/점수 오름
                {
                    PlayerAnim.SetTrigger("EatElement"); //먹는 애니메이션 트리거 On
                    sfxManager.I.PlaySfx("EatElement");
                    gameManager.I.addScore(this.pointAdd); //점수 획득
                    gameManager.I.addElecPoint(this.pointAdd); // 전기 원소점수 획득
                    comboBonus(combo);
                    combo += 1;
                }
                else if (isFireEvolved || isWaterEvolved) // 물,불 진화 시 점수 X, 체력 감소  
                {
                    PlayerAnim.SetTrigger("EatMinus"); //마이너스 애니메이션 트리거 On
                    sfxManager.I.PlaySfx("EatMinusElement");
                    gameManager.I.minusCurrentHp(-3);
                    combo = 0;
                }
                else //어떤 진화도 하지 않았을 경우
                {
                    PlayerAnim.SetTrigger("EatElement"); //먹는 애니메이션 트리거 On
                    sfxManager.I.PlaySfx("EatElement");
                    gameManager.I.addScore(this.pointAdd); //점수 획득
                    gameManager.I.addElecPoint(this.pointAdd); // 전기 원소점수 획득
                }
            }

            Destroy(coll.gameObject); //원소 오브젝트는 사라진다
        }

        if (coll.gameObject.tag == "Items") //아이템을 먹었을 때
        {
            sfxManager.I.PlaySfx("EatItem");
            /*PlayerAnim.SetTrigger("EatElement"); //먹는 애니메이션 트리거 On*/

            bool isDouble = coll.gameObject.name.Contains("Double");
            bool isTriple = coll.gameObject.name.Contains("Triple");
            bool isGetCoin = coll.gameObject.name.Contains("GetCoin");
            bool isHpUpSmall = coll.gameObject.name.Contains("HpUpSmall");
            bool isHpUpBig = coll.gameObject.name.Contains("HpUpBig");
            bool isSpeedUp = coll.gameObject.name.Contains("SpeedUp");


            if (isDouble) //더블 아이템일 경우
            {
                Debug.Log("모든 점수 2배");
                StartCoroutine(UseDoubleItem(5f));
            }
            else if (isTriple) //트리플 아이템일 경우
            {
                Debug.Log("모든 점수 3배");
                StartCoroutine(UseTripleItem(5f));
            }
            else if (isGetCoin) //재화 획득 아이템일 경우
            {
                Debug.Log("돈 100");
                gameManager.I.itemCoin += 100;
            }
            else if (isHpUpSmall) //체력 회복(소) 아이템일 경우
            {
                Debug.Log("체력 5 회복");
                gameManager.I.currentHp += 5;
            }
            else if (isHpUpBig) //체력 회복(대) 아이템일 경우
            {
                Debug.Log("체력 15 회복");
                gameManager.I.currentHp += 15;
            }
            else if (isSpeedUp) //스피드 업 아이템일 경우
            {
                Debug.Log("스피드 업!");
                StartCoroutine(UseSpeedUp(5f));
            }


            Destroy(coll.gameObject); //아이템 오브젝트는 사라진다
        }


    }

    IEnumerator UseDoubleItem(float seconds)
    {
        pointAdd *= 2;

        yield return new WaitForSecondsRealtime(seconds);

        pointAdd /= 2;
    }

    IEnumerator UseTripleItem(float seconds)
    {
        pointAdd *= 3;

        yield return new WaitForSecondsRealtime(seconds);

        pointAdd /= 3;
    }


    IEnumerator UseSpeedUp(float seconds)
    {
        gameManager.I.speed = 1000f;
        yield return new WaitForSecondsRealtime(seconds);
        gameManager.I.speed = 700f;
    }

    void FireElementEvolve() //애니메이션 컨트롤러에 불 원소 점수 넘겨줘서 진화하게끔 하는 함수
    {
        int totalFirePoint = gameManager.I.totalFirePoint;
        EvolveAnim.SetInteger("FireEvolvePoint", totalFirePoint);
        EvolveAnim.SetBool("Fire2ndisUnlocked", dataManager.I.Fire2ndisUnlocked);
        EvolveAnim.SetBool("Fire3rdisUnlocked", dataManager.I.Fire3rdisUnlocked);

    }

    void WaterElementEvolve() //애니메이션 컨트롤러에 물 원소 점수 넘겨줘서 진화하게끔 하는 함수
    {
        int totalWaterPoint = gameManager.I.totalWaterPoint;
        EvolveAnim.SetInteger("WaterEvolvePoint", totalWaterPoint);
        EvolveAnim.SetBool("Water2ndisUnlocked", dataManager.I.Water2ndisUnlocked);
        EvolveAnim.SetBool("Water3rdisUnlocked", dataManager.I.Water3rdisUnlocked);

    }

    void ElecElementEvolve()    //애니메이션 컨트롤러에 전기 원소 점수 넘겨줘서 진화하게끔 하는 함수
    {
        int totalElecPoint = gameManager.I.totalElecPoint;
        EvolveAnim.SetInteger("ElecEvolvePoint", totalElecPoint);
        EvolveAnim.SetBool("Elec2ndisUnlocked", dataManager.I.Elec2ndisUnlocked);
        EvolveAnim.SetBool("Elec3rdisUnlocked", dataManager.I.Elec3rdisUnlocked);
    }

    public void evolveCheck1st() //1차 진화를 했는가?
    {
        is1stEvolved = true;
    }

    public void evolveCheck2nd() //2차 진화를 했는가?
    {
        is2ndEvolved = true;
    }

    public void evolveCheck3rd() //3차 진화를 했는가?
    {
        is3rdEvolved = true;
    }

    public void fireEvolve1st()
    {
        isFireEvolved = true;
        PointUI.SetActive(false);
        FireEvolveGageBar.SetActive(true);
        FireImg.SetActive(true);
    }

    public void waterEvolve1st()
    {
        isWaterEvolved = true;
        PointUI.SetActive(false);
        WaterEvolveGageBar.SetActive(true);
        WaterImg.SetActive(true);
    }

    public void elecEvolve1st()
    {
        isElecEvolved = true;
        PointUI.SetActive(false);
        ElecEvolveGageBar.SetActive(true);
        ElecImg.SetActive(true);
    }

    public void comboBonus(int combo)
    {
        

        switch (combo)
            {
                case 5:
                    ComboEffect.SetTrigger("5Combo");
                    gameManager.I.currentHp += 2;
                    Debug.Log(combo);
                    sfxManager.I.PlaySfx("Combo");
                    break;
                case 10:
                    ComboEffect.SetTrigger("10Combo");
                    gameManager.I.currentHp += 3;
                    Debug.Log(combo);
                    sfxManager.I.PlaySfx("Combo");
                    break;
                case 15:
                    ComboEffect.SetTrigger("15Combo");
                    gameManager.I.currentHp += 4;
                    sfxManager.I.PlaySfx("Combo");
                    break;
                case 20:
                    ComboEffect.SetTrigger("20Combo");
                    gameManager.I.currentHp += 5;
                    sfxManager.I.PlaySfx("Combo");
                    break;
                case 25:
                    ComboEffect.SetTrigger("25Combo");
                    gameManager.I.currentHp += 5;
                    sfxManager.I.PlaySfx("Combo");
                    break;
                case 30:
                    ComboEffect.SetTrigger("30Combo");
                    gameManager.I.currentHp += 5;
                    sfxManager.I.PlaySfx("Combo");
                    break;
                case 35:
                    ComboEffect.SetTrigger("35Combo");
                    gameManager.I.currentHp += 5;
                    sfxManager.I.PlaySfx("Combo");
                    break;
                case 40:
                    ComboEffect.SetTrigger("40Combo");
                    gameManager.I.currentHp += 5;
                    sfxManager.I.PlaySfx("Combo");
                    break;
                case 45:
                    ComboEffect.SetTrigger("45Combo");
                    gameManager.I.currentHp += 5;
                    sfxManager.I.PlaySfx("Combo");
                    break;
                case 50:
                    ComboEffect.SetTrigger("50Combo");
                    gameManager.I.currentHp += 5;
                    sfxManager.I.PlaySfx("Combo");
                    break;

        }

    }






    public void evolveSFX()
    {
        sfxManager.I.PlaySfx("Evolving");
        sfxManager.I.PlaySfx("AfterEvolve");
    }




    //진화 스킬

    public void Fire1stSkill()
    {
        Debug.Log("불 스킬 실행됐는가?");
        StartCoroutine(Fire1stSkill(4f));
    }

    public void Water1stSkill()
    {
        Debug.Log("물 스킬 실행됐는가?");
        StartCoroutine(Water1stSkill(4f));
    }

    public void Elec1stSkill()
    {
        Debug.Log("전기 스킬 실행됐는가?");
        StartCoroutine(Elec1stSkill(4f));
    }


    IEnumerator Fire1stSkill(float seconds)
    {
        Debug.Log("불 스킬");
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().src = 0;
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().dst = 1;
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().spawntime = 0.4f;
        GameObject.Find("background").GetComponent<background>().fireEvolveBackground();

        yield return new WaitForSeconds(seconds);

        Debug.Log("불 스킬 실행 종료");
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().src = 0;
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().dst = 3;
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().spawntime = 0.7f;
        GameObject.Find("background").GetComponent<background>().normalBackground();
    }

    IEnumerator Water1stSkill(float seconds)
    {
        Debug.Log("워터 스킬");
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().src = 1;
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().dst = 2;
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().spawntime = 0.4f;
        GameObject.Find("background").GetComponent<background>().waterEvolveBackground();

        yield return new WaitForSeconds(seconds);

        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().src = 0;
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().dst = 3;
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().spawntime = 0.7f;
        GameObject.Find("background").GetComponent<background>().normalBackground();
    }

    IEnumerator Elec1stSkill(float seconds)
    {
        Debug.Log("전기스킬");
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().src = 2;
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().dst = 3;
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().spawntime = 0.4f;
        GameObject.Find("background").GetComponent<background>().elecEvolveBackground();

        yield return new WaitForSeconds(seconds);

        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().src = 0;
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().dst = 3;
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().spawntime = 0.7f;
        GameObject.Find("background").GetComponent<background>().normalBackground();
    }
}

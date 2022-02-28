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

    public void PlayerMove(float speed) //�÷��̾� �̵� ���� �Լ�
    {
        int zPos= 0;

        if (transform.localPosition.x > 500f) //ȭ���� �� ���� ������ �ݴ�� ���Ѵ�
        {
            gameManager.I.speed *= -1;
            transform.localPosition = new Vector3(Mathf.Min(transform.localPosition.x, 500f), -590f, 0f); //������ ���� ������ �÷��̾� ��ǥ�� 2.8f �Ѿ�� �ʰ� ó��
        }

        if (transform.localPosition.x < -500f)
        {
            gameManager.I.speed *= -1;
            transform.localPosition = new Vector3(Mathf.Max(transform.localPosition.x, -500f), -590f, 0f); // ���� ���� ������ �÷��̾� ��ǥ�� -2.8f �Ѿ�� �ʰ� ó��
        }

        if (Input.GetMouseButtonDown(0)) //Ŭ���ϸ� �ݴ�� ���Ѵ�
        {
            gameManager.I.speed *= -1;
            sfxManager.I.PlaySfx("PlayerTouch"); //��ġ�ϸ� �Ҹ���
        }

        transform.localPosition += new Vector3(gameManager.I.speed * Time.deltaTime, 0, zPos);
        

    }

    void OnCollisionEnter2D(Collision2D coll)

    {

        if (coll.gameObject.tag == "elements") //���Ҹ� �Ծ��� ��
        {
            
            bool isfire = coll.gameObject.name.Contains("fire");
            bool iswater = coll.gameObject.name.Contains("water");
            bool iselec = coll.gameObject.name.Contains("elec");
            
           

            if (isfire) //�� ������ ���
            {

                FireEffectFrontAnim.SetTrigger("EatFire");
                FireEffectBackAnim.SetTrigger("EatFire");

                if (isFireEvolved) // �� ��ȭ ���� �� ���ھ�/���� ����
                {
                    PlayerAnim.SetTrigger("EatElement"); //�Դ� �ִϸ��̼� Ʈ���� On
                    sfxManager.I.PlaySfx("EatElement");
                    gameManager.I.addScore(this.pointAdd); //���� ȹ��
                    gameManager.I.addFirePoint(this.pointAdd); //�� �������� ȹ��
                    comboBonus(combo);
                    combo += 1;

                }
                else if (isWaterEvolved || isElecEvolved) // ��,���� ��ȭ �� ���� X, ü�� ����  
                {
                    PlayerAnim.SetTrigger("EatMinus"); //���̳ʽ� �ִϸ��̼� Ʈ���� On
                    sfxManager.I.PlaySfx("EatMinusElement");
                    gameManager.I.minusCurrentHp(-3);
                    combo = 0;
                }
                else //� ��ȭ�� ���� �ʾ��� ���
                {
                    PlayerAnim.SetTrigger("EatElement"); //�Դ� �ִϸ��̼� Ʈ���� On
                    sfxManager.I.PlaySfx("EatElement");
                    gameManager.I.addScore(this.pointAdd); //���� ȹ��
                    gameManager.I.addFirePoint(this.pointAdd); //�� �������� ȹ��
                }

            }
            else if (iswater) //�� ������ ���
            {
                WaterEffectFrontAnim.SetTrigger("EatWater"); // �� ���� ���� ����Ʈ �ִϸ��̼� ���
                WaterEffectBackAnim.SetTrigger("EatWater");

                if (isWaterEvolved) // �� ��ȭ ���� �� ���ھ�/���� ����
                {
                    PlayerAnim.SetTrigger("EatElement"); //�Դ� �ִϸ��̼� Ʈ���� On
                    sfxManager.I.PlaySfx("EatElement");
                    gameManager.I.addScore(this.pointAdd); //���� ȹ��
                    gameManager.I.addWaterPoint(this.pointAdd); // �� �������� ȹ��
                    comboBonus(combo);
                    combo += 1;
                }
                else if (isFireEvolved || isElecEvolved) // ��,���� ��ȭ �� ���� X, ü�� ����  
                {
                    PlayerAnim.SetTrigger("EatMinus"); //���̳ʽ� �ִϸ��̼� Ʈ���� On
                    sfxManager.I.PlaySfx("EatMinusElement");
                    gameManager.I.minusCurrentHp(-3);
                    combo = 0;
                }
                else //� ��ȭ�� ���� �ʾ��� ���
                {
                    PlayerAnim.SetTrigger("EatElement"); //�Դ� �ִϸ��̼� Ʈ���� On
                    sfxManager.I.PlaySfx("EatElement");
                    gameManager.I.addScore(this.pointAdd); //���� ȹ��
                    gameManager.I.addWaterPoint(this.pointAdd); // �� �������� ȹ��
                }
            }
            else if (iselec) // ���� ������ ���
            {

                ElecEffectFrontAnim.SetTrigger("EatElec");
                ElecEffectBackAnim.SetTrigger("EatElec");

                if (isElecEvolved) // ���� ��ȭ ���� �� ���ھ�/���� ����
                {
                    PlayerAnim.SetTrigger("EatElement"); //�Դ� �ִϸ��̼� Ʈ���� On
                    sfxManager.I.PlaySfx("EatElement");
                    gameManager.I.addScore(this.pointAdd); //���� ȹ��
                    gameManager.I.addElecPoint(this.pointAdd); // ���� �������� ȹ��
                    comboBonus(combo);
                    combo += 1;
                }
                else if (isFireEvolved || isWaterEvolved) // ��,�� ��ȭ �� ���� X, ü�� ����  
                {
                    PlayerAnim.SetTrigger("EatMinus"); //���̳ʽ� �ִϸ��̼� Ʈ���� On
                    sfxManager.I.PlaySfx("EatMinusElement");
                    gameManager.I.minusCurrentHp(-3);
                    combo = 0;
                }
                else //� ��ȭ�� ���� �ʾ��� ���
                {
                    PlayerAnim.SetTrigger("EatElement"); //�Դ� �ִϸ��̼� Ʈ���� On
                    sfxManager.I.PlaySfx("EatElement");
                    gameManager.I.addScore(this.pointAdd); //���� ȹ��
                    gameManager.I.addElecPoint(this.pointAdd); // ���� �������� ȹ��
                }
            }

            Destroy(coll.gameObject); //���� ������Ʈ�� �������
        }

        if (coll.gameObject.tag == "Items") //�������� �Ծ��� ��
        {
            sfxManager.I.PlaySfx("EatItem");
            /*PlayerAnim.SetTrigger("EatElement"); //�Դ� �ִϸ��̼� Ʈ���� On*/

            bool isDouble = coll.gameObject.name.Contains("Double");
            bool isTriple = coll.gameObject.name.Contains("Triple");
            bool isGetCoin = coll.gameObject.name.Contains("GetCoin");
            bool isHpUpSmall = coll.gameObject.name.Contains("HpUpSmall");
            bool isHpUpBig = coll.gameObject.name.Contains("HpUpBig");
            bool isSpeedUp = coll.gameObject.name.Contains("SpeedUp");


            if (isDouble) //���� �������� ���
            {
                Debug.Log("��� ���� 2��");
                StartCoroutine(UseDoubleItem(5f));
            }
            else if (isTriple) //Ʈ���� �������� ���
            {
                Debug.Log("��� ���� 3��");
                StartCoroutine(UseTripleItem(5f));
            }
            else if (isGetCoin) //��ȭ ȹ�� �������� ���
            {
                Debug.Log("�� 100");
                gameManager.I.itemCoin += 100;
            }
            else if (isHpUpSmall) //ü�� ȸ��(��) �������� ���
            {
                Debug.Log("ü�� 5 ȸ��");
                gameManager.I.currentHp += 5;
            }
            else if (isHpUpBig) //ü�� ȸ��(��) �������� ���
            {
                Debug.Log("ü�� 15 ȸ��");
                gameManager.I.currentHp += 15;
            }
            else if (isSpeedUp) //���ǵ� �� �������� ���
            {
                Debug.Log("���ǵ� ��!");
                StartCoroutine(UseSpeedUp(5f));
            }


            Destroy(coll.gameObject); //������ ������Ʈ�� �������
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

    void FireElementEvolve() //�ִϸ��̼� ��Ʈ�ѷ��� �� ���� ���� �Ѱ��༭ ��ȭ�ϰԲ� �ϴ� �Լ�
    {
        int totalFirePoint = gameManager.I.totalFirePoint;
        EvolveAnim.SetInteger("FireEvolvePoint", totalFirePoint);
        EvolveAnim.SetBool("Fire2ndisUnlocked", dataManager.I.Fire2ndisUnlocked);
        EvolveAnim.SetBool("Fire3rdisUnlocked", dataManager.I.Fire3rdisUnlocked);

    }

    void WaterElementEvolve() //�ִϸ��̼� ��Ʈ�ѷ��� �� ���� ���� �Ѱ��༭ ��ȭ�ϰԲ� �ϴ� �Լ�
    {
        int totalWaterPoint = gameManager.I.totalWaterPoint;
        EvolveAnim.SetInteger("WaterEvolvePoint", totalWaterPoint);
        EvolveAnim.SetBool("Water2ndisUnlocked", dataManager.I.Water2ndisUnlocked);
        EvolveAnim.SetBool("Water3rdisUnlocked", dataManager.I.Water3rdisUnlocked);

    }

    void ElecElementEvolve()    //�ִϸ��̼� ��Ʈ�ѷ��� ���� ���� ���� �Ѱ��༭ ��ȭ�ϰԲ� �ϴ� �Լ�
    {
        int totalElecPoint = gameManager.I.totalElecPoint;
        EvolveAnim.SetInteger("ElecEvolvePoint", totalElecPoint);
        EvolveAnim.SetBool("Elec2ndisUnlocked", dataManager.I.Elec2ndisUnlocked);
        EvolveAnim.SetBool("Elec3rdisUnlocked", dataManager.I.Elec3rdisUnlocked);
    }

    public void evolveCheck1st() //1�� ��ȭ�� �ߴ°�?
    {
        is1stEvolved = true;
    }

    public void evolveCheck2nd() //2�� ��ȭ�� �ߴ°�?
    {
        is2ndEvolved = true;
    }

    public void evolveCheck3rd() //3�� ��ȭ�� �ߴ°�?
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




    //��ȭ ��ų

    public void Fire1stSkill()
    {
        Debug.Log("�� ��ų ����ƴ°�?");
        StartCoroutine(Fire1stSkill(4f));
    }

    public void Water1stSkill()
    {
        Debug.Log("�� ��ų ����ƴ°�?");
        StartCoroutine(Water1stSkill(4f));
    }

    public void Elec1stSkill()
    {
        Debug.Log("���� ��ų ����ƴ°�?");
        StartCoroutine(Elec1stSkill(4f));
    }


    IEnumerator Fire1stSkill(float seconds)
    {
        Debug.Log("�� ��ų");
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().src = 0;
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().dst = 1;
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().spawntime = 0.4f;
        GameObject.Find("background").GetComponent<background>().fireEvolveBackground();

        yield return new WaitForSeconds(seconds);

        Debug.Log("�� ��ų ���� ����");
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().src = 0;
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().dst = 3;
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().spawntime = 0.7f;
        GameObject.Find("background").GetComponent<background>().normalBackground();
    }

    IEnumerator Water1stSkill(float seconds)
    {
        Debug.Log("���� ��ų");
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
        Debug.Log("���⽺ų");
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

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopSceneUICtrl : MonoBehaviour
{
    public RectTransform StandardButton;
    public GameObject Standard;
    public GameObject StandardEquipe;
    public GameObject StandardTaget;
    public GameObject StandardCom;

    public RectTransform OneButton;
    public GameObject One;
    public GameObject OneEquipe;
    public GameObject OneTaget;
    public GameObject OneCom;

    public RectTransform TwoButton;
    public GameObject Two;
    public GameObject TwoEquipe;
    public GameObject TwoTaget;
    public GameObject TwoCom;

    public GameObject SkinOneLock;
    public GameObject SkinOneLock1;

    public GameObject SkinTwoLock;
    public GameObject SkinTwoLock1;

    public AudioSource audio;

    private Vector3 stdVec = new Vector3(2.611823f, 2.611823f, 2.611823f);
    void Start()
    {
        Load();
        if (Singleton.BGM)
            audio.Play();
    }
    
    void Update()
    {

    }

    void OnDisable()
    {
        Save();
    }

    void Save()
    {
        PlayerPrefs.SetInt("SkinNum", Singleton.SkinNum);
        PlayerPrefs.Save();
    }

    void Load()
    {
        int Score = Singleton.Score;
        if (Score >= 50)
        {
            SkinOneLock.SetActive(false);
            SkinOneLock1.SetActive(false);
        }

        if (Score >= 100)
        {
            SkinTwoLock.SetActive(false);
            SkinTwoLock1.SetActive(false);
        }

        StandardButton.localScale = stdVec;
        Standard.SetActive(false);
        StandardEquipe.SetActive(true);
        StandardTaget.SetActive(false);
        StandardCom.SetActive(false);

        OneButton.localScale = stdVec;
        One.SetActive(false);
        OneEquipe.SetActive(true);
        OneTaget.SetActive(false);
        OneCom.SetActive(false);

        TwoButton.localScale = stdVec;
        Two.SetActive(false);
        TwoEquipe.SetActive(true);
        TwoTaget.SetActive(false);
        TwoCom.SetActive(false);

        if (Singleton.SkinNum == 0)
        {
            StandardButton.localScale = stdVec * 1.3f;
            Standard.SetActive(true);
            StandardEquipe.SetActive(false);
            StandardTaget.SetActive(true);
            StandardCom.SetActive(true);
        }
        if (Singleton.SkinNum == 1)
        {
            OneButton.localScale = stdVec * 1.3f;
            One.SetActive(true);
            OneEquipe.SetActive(false);
            OneTaget.SetActive(true);
            OneCom.SetActive(true);
        }
        if (Singleton.SkinNum == 2)
        {
            TwoButton.localScale = stdVec * 1.3f;
            Two.SetActive(true);
            TwoEquipe.SetActive(false);
            TwoTaget.SetActive(true);
            TwoCom.SetActive(true);
        }
    }

    public void Back()
    {
        Application.LoadLevel(1);
    }

    public void StandardSkinButton()
    {
        StandardButton.localScale = stdVec * 1.3f;
        OneButton.localScale = stdVec;
        TwoButton.localScale = stdVec;

        Standard.SetActive(true);
        One.SetActive(false);
        Two.SetActive(false);
    }

    public void StandardSkinEquipeButton()
    {
        StandardTaget.SetActive(true);
        OneTaget.SetActive(false);
        TwoTaget.SetActive(false);

        StandardCom.SetActive(true);
        OneCom.SetActive(false);
        TwoCom.SetActive(false);

        StandardEquipe.SetActive(false);
        OneEquipe.SetActive(true);
        TwoEquipe.SetActive(true);
        Singleton.SkinNum = 0;
    }

    public void SkinOneButton()
    {
        StandardButton.localScale = stdVec;
        OneButton.localScale = stdVec * 1.3f;
        TwoButton.localScale = stdVec;

        Standard.SetActive(false);
        One.SetActive(true);
        Two.SetActive(false);
    }

    public void SkinOneEquipeButton()
    {
        StandardTaget.SetActive(false);
        OneTaget.SetActive(true);
        TwoTaget.SetActive(false);

        StandardCom.SetActive(false);
        OneCom.SetActive(true);
        TwoCom.SetActive(false);

        StandardEquipe.SetActive(true);
        OneEquipe.SetActive(false);
        TwoEquipe.SetActive(true);
        Singleton.SkinNum = 1;
    }

    public void SkinTwoButton()
    {
        StandardButton.localScale = stdVec;
        OneButton.localScale = stdVec;
        TwoButton.localScale = stdVec * 1.3f;

        Standard.SetActive(false);
        One.SetActive(false);
        Two.SetActive(true);
    }

    public void SkinTwoEquipeButton()
    {
        StandardTaget.SetActive(false);
        OneTaget.SetActive(false);
        TwoTaget.SetActive(true);

        StandardCom.SetActive(false);
        OneCom.SetActive(false);
        TwoCom.SetActive(true);

        StandardEquipe.SetActive(true);
        OneEquipe.SetActive(true);
        TwoEquipe.SetActive(false);
        Singleton.SkinNum = 2;
    }
}

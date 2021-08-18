using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainSceneUICtrl : MonoBehaviour
{
    public Transform SuttinStarTra;
    public Animator SuttingSartAni;
    public GameObject Option;
    public Toggle BgmTg;
    public Toggle SfxTg;
    public AudioSource audio;
    // Use this for initialization
    void Start()
    {
        StartCoroutine("SuttingSt");
        BgmTg.isOn = Singleton.BGM;
        SfxTg.isOn = Singleton.SFX;
        if(Singleton.BGM)
            audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnDisable()
    {
        Save();
    }

    void Save()
    {
        Singleton.BGM = BgmTg.isOn;
        Singleton.SFX = SfxTg.isOn;
        
    }

    public void GotoShop()
    {
        Application.LoadLevel(2);
    }

    public void GotoCrtedit()
    {
        Application.LoadLevel(3);
    }
    public void GotoGame()
    {
        Application.LoadLevel(4);
    }
    public void OptionOn()
    {
        Option.SetActive(true);
    }

    public void SoundOn()
    {
        if (BgmTg.isOn)
        {
            audio.Play();
        }
        else
        {
            audio.Stop();
        }
    }

    public void OptionOff()
    {
        Option.SetActive(false);
        Save();
    }

    IEnumerator SuttingSt()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.RandomRange(3f, 5f));
            SuttinStarTra.localPosition = new Vector3(0f, Random.RandomRange(60f, 600f), 0f);
            SuttingSartAni.Play(0);
        }
    }
}

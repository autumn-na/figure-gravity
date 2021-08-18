using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour
{
    public static Singleton instance = null;
    public static bool BGM;
    public static bool SFX;
    public static int SkinNum;
    public static int Score;
    public static Singleton Instance
    {
        get
        {
            if (instance == null)
                Debug.LogError("Singleton == null");
            return instance;
        }
    }
    public void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        Score = PlayerPrefs.GetInt("Score");
        SkinNum = PlayerPrefs.GetInt("SkinNum");
        if (PlayerPrefs.GetInt("BGM") != 0)
        {
            BGM = true;
        }
        else
        {
            BGM = false;
        }
        if (PlayerPrefs.GetInt("SFX") != 0)
        {
            SFX = true;
        }
        else
        {
            SFX = false;
        }
        Debug.Log(BGM);
        Debug.Log(SFX);
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
        PlayerPrefs.SetInt("Score",Score);
        if (BGM)
        {
            PlayerPrefs.SetInt("BGM", 1);
        }
        else
        {
            PlayerPrefs.SetInt("BGM", 0);
        }
        if (SFX)
        {
            PlayerPrefs.SetInt("SFX", 1);
        }
        else
        {
            PlayerPrefs.SetInt("SFX", 0);
        }

        PlayerPrefs.SetInt("SkinNum", SkinNum);
        PlayerPrefs.Save();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppMain : MonoBehaviour {
    [SerializeField]
    private Text titleName;

    [SerializeField]
    private Text txtPlay;

    [SerializeField]
    private Sprite spriteSoundOn;

    [SerializeField]
    private Sprite spriteSoundOff;

    [SerializeField]
    private Image imgSound;

    bool isSoundOn;
    bool isInit;

    // Use this for initialization
    void Start () {
        OnInit();
    }

    void OnInit()
    {
        if (isInit)
            return;
        isInit = true;
        OnupdateSound();
    }

    void OnupdateSound()
    {
        imgSound.sprite = (isSoundOn) ? spriteSoundOn : spriteSoundOff;
    }

    #region Function
    public void OnPlay()
    {
        Debug.Log("OnPlay");
    }

    public void OnGetHighScore()
    {
        Debug.Log("OnGetHighScore");
    }

    public void OnGetFreeDiamond()
    {
        Debug.Log("OnGetFreeDiamond");
    }

    public void OnSetSound()
    {
        Debug.Log("OnSetSound");
        isSoundOn = !isSoundOn;
        OnupdateSound();
    }

    public void OnShare()
    {
        Debug.Log("OnShare");
    }

    public void OnRate()
    {
        Debug.Log("OnRate");
    }
    #endregion
}

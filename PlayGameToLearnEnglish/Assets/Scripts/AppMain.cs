using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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

    [SerializeField]
    private GameObject gObjRate;

    public float timeRotate = 0.5f;

    bool isSoundOn;
    bool isInit;

    Sequence rateSequence;
    

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
        OnAutoRotationBtnRate();
    }

    void OnAutoRotationBtnRate()
    {
        if (rateSequence == null)
            rateSequence = DOTween.Sequence();
        rateSequence.Append(gObjRate.transform.DORotate(new Vector3(0, 0, 45), timeRotate));
        rateSequence.Append(gObjRate.transform.DORotate(new Vector3(0, 0, -45), timeRotate));
        rateSequence.Append(gObjRate.transform.DORotate(new Vector3(0, 0, 0), timeRotate/2));
        rateSequence.SetLoops(-1);
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

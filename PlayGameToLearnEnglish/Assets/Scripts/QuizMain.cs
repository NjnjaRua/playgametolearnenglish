using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizMain : BasePopup {
    [SerializeField]
    private Text coin;

    [SerializeField]
    private GridLayoutGroup gridImages;

    [SerializeField]
    private GameObject imagePrefab;

    [SerializeField]
    private GridLayoutGroup gridResults;

    [SerializeField]
    private GridLayoutGroup gridLetters;

    [SerializeField]
    private GameObject gObjNext;

    PopupManager puManager;
    UserData userData;
    int quizId;
    
    // Use this for initialization
    void Start () {
        puManager = PopupManager.getInstance();
        userData = UserData.GetInstance();
    }

    public void OnShowPopup(int _quizId)
    {
        if (_quizId < 0)
            return;
        ShowPopup();
        OnUpdate();
    }

    public void OnHidePopup()
    {
        HidePopup();
    }

    public void OnUpdate()
    {   
        if (userData == null)
            userData = UserData.GetInstance();
        coin.text = Util.NumberFormat(userData.GetCoin());
        OnUpdateImages();
    }

    void OnUpdateImages()
    {
        if (gridImages == null || imagePrefab == null)
            return;
        int i = 0, lenChild = gridImages.transform.childCount;
        for (i = 0; i < lenChild; i++)
            gridImages.transform.GetChild(i).gameObject.SetActive(false);
        GameObject gObj;
        for (i = 0; i < 4; i++)
        {
            gObj = null;
            if (i < lenChild)
                gObj = gridImages.transform.GetChild(i).gameObject;
            if (gObj == null)
            {
                gObj = Instantiate(imagePrefab, Vector3.one, Quaternion.identity, gridImages.transform) as GameObject;
                gObj.transform.localScale = Vector3.one;
            }
            gObj.SetActive(true);
            //todo update image
        }
    }

    public void OnBack()
    {
        //back Categories quiz
        if (puManager == null)
            return;
        OnHidePopup();
        puManager.OnShowPopupCategoriesQuiz();
    }

    public void OnOpenLetter()
    {
        //open 1 letter by coin
    }

    public void OnShare()
    {
        //share
    }

    public void OnRemove()
    {
        //remove 1 letter
    }

    public void OnSkip()
    {
        //skip this level
    }

    public void OnBuyCoin()
    {
        //buy coin
    }
}

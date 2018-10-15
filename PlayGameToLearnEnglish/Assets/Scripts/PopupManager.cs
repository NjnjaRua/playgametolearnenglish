using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour {
    private static PopupManager instance;

    [SerializeField]
    private GameObject blackBackground;

    [SerializeField]
    private Transform popupContainerTf;
    private Dictionary<string, BasePopup> popupDict = new Dictionary<string, BasePopup>();

    public delegate void PopupGetComplete(BasePopup original, BasePopup newPopup);

    [SerializeField]
    private MainMenu mainMenu;

    [SerializeField]
    private CategoriesQuiz categoriesQuiz;

    private void Awake()
    {
        instance = this;
    }

    public static PopupManager getInstance()
    {
        return instance;
    }

    public void OpenBlackBG()
    {
        this.blackBackground.SetActive(true);
    }

    public void CloseBlackBG()
    {
        this.blackBackground.SetActive(false);
    }

#region Get Popup By Prefabs

    public void GetPopup(BasePopup originalPu, PopupGetComplete completeFunc)
    {
        BasePopup _popup = null;
        if (!popupDict.TryGetValue(originalPu.uiElement.elementName, out _popup))
            StartCoroutine(generateBasePopup(originalPu, completeFunc, popupContainerTf, popupDict));
        else
            completeFunc(originalPu, _popup);
    }

    IEnumerator generateBasePopup(BasePopup originalPu, PopupGetComplete completeFunc, Transform parentTF, Dictionary<string, BasePopup> pDict)
    {
        BasePopup _popup = GameObject.Instantiate(originalPu, Vector3.zero, Quaternion.identity, parentTF);
        _popup.gameObject.transform.localScale = Vector3.one;
        pDict[originalPu.uiElement.elementName] = _popup;
        yield return new WaitForSeconds(0.2f);
        if (completeFunc != null)
            completeFunc(originalPu, _popup);
    }

#endregion

    public void HideAll()
    {
        CloseBlackBG();
        HideAllPopup();
    }

    public void HideAllPopup()
    {
        foreach (var item in popupDict.Values)
        {
            if (item && item.IsOnScreen())
            {
               item.HidePopup();
            }
        }
    }

#region Show/Hide Popup

    public void OnShowPopupMainMenu()
    {
        if (mainMenu == null)
            return;
        GetPopup(mainMenu, (s1, s2) =>
        {
            if (s2 != null)
            {
                MainMenu mainMenu = s2.GetComponent<MainMenu>();
                if (mainMenu != null)
                {
                    mainMenu.OnShowPopup();
                }
            }
        });
    }

    public void OnHidePopupMainMenu()
    {
        if (mainMenu == null)
            return;
        GetPopup(mainMenu, (s1, s2) =>
        {
            if (s2 != null)
            {
                MainMenu mainMenu = s2.GetComponent<MainMenu>();
                if (mainMenu != null)
                {
                    mainMenu.OnHidePopup();
                }
            }
        });
    }

    public void OnShowPopupCategoriesQuiz()
    {
        if (mainMenu == null)
            return;
        GetPopup(categoriesQuiz, (s1, s2) =>
        {
            if (s2 != null)
            {
                CategoriesQuiz categoriesQuiz = s2.GetComponent<CategoriesQuiz>();
                if (categoriesQuiz != null)
                    categoriesQuiz.OnShowPopup();
            }
        });
    }

    public void OnHidePopupCategoriesQuiz()
    {
        if (mainMenu == null)
            return;
        GetPopup(categoriesQuiz, (s1, s2) =>
        {
            if (s2 != null)
            {
                CategoriesQuiz categoriesQuiz = s2.GetComponent<CategoriesQuiz>();
                if (categoriesQuiz != null)
                    categoriesQuiz.OnHidePopup();
            }
        });
    }

    public void OnHidePopupCategoriesQuizForBackKey()
    {
        if (mainMenu == null)
            return;
        GetPopup(categoriesQuiz, (s1, s2) =>
        {
            if (s2 != null)
            {
                CategoriesQuiz categoriesQuiz = s2.GetComponent<CategoriesQuiz>();
                if (categoriesQuiz != null)
                {
                    categoriesQuiz.HidePopupForBackKey();
                    OnShowPopupMainMenu();
                }
            }
        });
    }
    #endregion
}

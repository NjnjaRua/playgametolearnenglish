using DoozyUI;
using UnityEngine;
using UnityEngine.UI;

public class BasePopup : MonoBehaviour {
	public enum BackgroundType
	{
		NONE,//No Show BG
		BLACK_BG, //Touch Will Close Lastest Popup
	}
	public UIElement uiElement;
	public Text titleText;
	public BackgroundType backgroundType;
    protected BasePopup parent;

    public virtual void ShowPopup()
    {
       ShowPopup(parent); 
    }

	public virtual void ShowPopup(BasePopup parent)
    {
        this.parent = parent;
        UIManager.ShowUiElement(uiElement.elementName);

        ShowBackground();
    }
        
    public virtual void HidePopup()
    {
        if (parent != null)
        {
            ShowParent();
            parent = null;
        }
        UIManager.HideUiElement(uiElement.elementName);
        HideBackground();
    }

    protected void ShowBackground()
    {
        switch (backgroundType)
        {
            case BackgroundType.BLACK_BG:
                PopupManager.getInstance().OpenBlackBG();
                break;

            default:
                break;
        }
    }

    private void HideBackground()
    {
        switch (backgroundType)
        {
            case BackgroundType.BLACK_BG:
                PopupManager.getInstance().CloseBlackBG();
                break;

            default:
                break;
        }
    }

    public BasePopup GetParent()
    {
        return parent;
    }

    private void ShowParent()
    {
        PopupManager.getInstance().GetPopup(parent, (s1, s2) =>
        {
            parent.ShowPopup();
        });
    }

    public void SetParent(BasePopup parent)
    {
        this.parent = parent;
    }

    public virtual void HideForAnotherPopup()
	{
		HidePopup ();
	}

	public bool IsOnScreen()
	{
		return uiElement.isVisible;
	}

	public virtual void OnShowBegin()
	{

	}

	public virtual void OnHideBegin()
	{

	}

	public virtual void OnShowFinish()
	{
	}

	public virtual void OnHideFinish()
	{
	}

    public virtual void OnItemClicked(GameObject item)
    {

    }

    public virtual void HidePopupForBackKey()
    {
        HidePopup();
    }

    public virtual void ReopenFromAnotherPopup()
    {
        
    }
}

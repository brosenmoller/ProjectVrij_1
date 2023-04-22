// Adapted from Code by Ralf Zeilstra (Game Developer HKU Year 1 in 2022)

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UIView : MonoBehaviour
{
    public bool defaultView;

    protected Selectable primarySelectable = null;

    public virtual void Initialize() { }
    public virtual void Hide()
    {
        EventSystem.current.SetSelectedGameObject(null);
        gameObject.SetActive(false);
    }
    public virtual void Show()
    {
        if (primarySelectable != null) EventSystem.current.SetSelectedGameObject(primarySelectable.gameObject);
        gameObject.SetActive(true);
    }
}

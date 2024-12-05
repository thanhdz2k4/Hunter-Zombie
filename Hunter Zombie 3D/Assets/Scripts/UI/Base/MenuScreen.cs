using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuScreen : MonoBehaviour
{
    [SerializeField] protected string m_ScreenName;
    [SerializeField] protected UIController m_UIController;
    [SerializeField] protected UIDocument m_Document;

    // visual elements
    protected VisualElement m_Screen;
    protected VisualElement m_Root;
    public event Action ScreenStarted;
    public event Action ScreenEnded;

    protected virtual void OnValidate() 
    {
        if(string.IsNullOrEmpty(m_ScreenName)) m_ScreenName = this.GetType().Name;
    }

    protected virtual void Awake() 
    {
        m_UIController = m_UIController ?? GetComponent<UIController>();
        m_Document = m_Document ?? GetComponent<UIDocument>();
        // if(ValidateDocument()) 
        // {
            SetVisualElements();
            RegisterButtonCallBacks();
        //}
    }

    private bool ValidateDocument()
    {
        if (m_Document != null) return true;
        Debug.LogWarning($"MenuScreen {m_ScreenName}: missing UIDocument. Check Script Execution Order");
        return false;
    }


    protected virtual void SetVisualElements()
    {
        m_Root = m_Document.rootVisualElement;
        m_Screen = GetVisualElement(m_ScreenName);
    }

    protected virtual void RegisterButtonCallBacks()
    {

    }
    
    private VisualElement GetVisualElement(string m_ScreenName)
    {
        //  if (string.IsNullOrEmpty(m_ScreenName) || m_Root == null)
        //     return null;
        Debug.Log(m_Root.Q(m_ScreenName));
        // query and return the element;
        return m_Root.Q(m_ScreenName);
    }

     // Toggle a UI on and off using the DisplayStyle
    public static void ShowVisualElement(VisualElement visualElement, bool state)
    {
        if (visualElement == null)
            return;
        visualElement.style.display = (state) ? DisplayStyle.Flex : DisplayStyle.None;
    }

    public bool IsVisible()
    {
        return (m_Screen.style.display == DisplayStyle.Flex);
    }

    public virtual void ShowScreen()
    {
        ShowVisualElement(m_Screen, true);
        ScreenStarted?.Invoke();
    }

    public virtual void HideScreen()
    {
        ShowVisualElement(m_Screen, false);
        ScreenEnded?.Invoke();        
    }

}

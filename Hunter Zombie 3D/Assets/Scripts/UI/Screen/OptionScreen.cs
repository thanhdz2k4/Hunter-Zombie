using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class OptionScreen : MenuScreen
{
    [Header("ID VISUAL ELEMENTS IN SCREEN")]
    [SerializeField] string id_Chapter__Container;
    [SerializeField] string id_Opinion__Container;
    [SerializeField] string id_Exit__Container;

    [Header("ID BUTTONS IN SCREEN")]
    [SerializeField] string id_Play__Button;
    [SerializeField] string id_Opinion__Button;
    [SerializeField] string id_Exit__Button;
    [SerializeField] string id_Chapter_1__Button;
    [SerializeField] string id_Chapter_2__Button;
    [SerializeField] string id_Chapter_3__Button;
    [SerializeField] string id_Chapter_4__Button;
    [SerializeField] string id_Facebook__Button;
    [SerializeField] string id_Youtube__Button;
    [SerializeField] string id_ItchIO__Button;
    [SerializeField] string id_Email__Button;
    [SerializeField] string id_Quit__Button;

    [Header("ID LABELS")]
    [SerializeField] string id_Play__Label;
    [SerializeField] string id_Opinion__Label;
    [SerializeField] string id_Exit__Label;

    [Header("MARKER")]
    [SerializeField] string id_Marker;
    [SerializeField] int k_MoveTime = 150;
    [SerializeField] float k_Spacing = 100f;
    [SerializeField] float k_yOffset = -8f;

    [Header("LINK CONNECT")]
    [SerializeField] string id_Facebook__Link;
    [SerializeField] string id_Youtube__Link;
    [SerializeField] string id_ItchIO__Link;
    [SerializeField] string id_Email__Link;

    [Header("ID STYLE SHEET")]
    [SerializeField] string id_Select_Label__USS;
    [SerializeField] string id_Unselect_Label__USS;

     [SerializeField] string id_Select_Chapter_Button__USS;
    [SerializeField] string id_Unselect_Chapter_Button__USS;

    [Header("CHAPTER IMAGE")]
    [SerializeField] Texture2D Chapter_1_Image;
    [SerializeField] Texture2D Chapter_2_Image;
    [SerializeField] Texture2D Chapter_3_Image;
    [SerializeField] Texture2D Chapter_4_Image;


    VisualElement m_Chapter__Container;
    VisualElement m_Opinion__Container;
    VisualElement m_Exit__Container;

    VisualElement m_Marker;

    Button m_Play__Button;
    Button m_Opinion__Button;
    Button m_Exit__Button;

    Label m_Play__Label;
    Label m_Opinion__Label;
    Label m_Exit__Label;

    Button m_Chapter_1__Button;
    Button m_Chapter_2__Button;
    Button m_Chapter_3__Button;
    Button m_Chapter_4__Button;

    Button m_Facebook__Button;
    Button m_Youtube__Button;
    Button m_ItchIO__Button;
    Button m_Email__Button;

    Button m_Quit__Button;

    List<VisualElement> Pannels = new List<VisualElement>();

    private void Start() 
    {
        if(m_Chapter__Container != null) Pannels.Add(m_Chapter__Container);
        if(m_Opinion__Container != null) Pannels.Add(m_Opinion__Container);
        if(m_Exit__Container != null) Pannels.Add(m_Exit__Container);

        ShowPanel(m_Chapter__Container, Pannels);
    }

    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        // ------ Container --------
        m_Chapter__Container = m_Root.Q<VisualElement>(id_Chapter__Container);
        m_Opinion__Container = m_Root.Q<VisualElement>(id_Opinion__Container);
        m_Exit__Container = m_Root.Q<VisualElement>(id_Exit__Container);

        m_Marker = m_Root.Q<VisualElement>(id_Marker);
        
        // ----- Label  ------
        m_Play__Label = m_Root.Q<Label>(id_Play__Label);
        m_Opinion__Label = m_Root.Q<Label>(id_Opinion__Label);
        m_Exit__Label = m_Root.Q<Label>(id_Exit__Label);

        // ----- Button ------
        m_Play__Button = m_Root.Q<Button>(id_Play__Button);
        m_Opinion__Button = m_Root.Q<Button>(id_Opinion__Button);
        m_Exit__Button = m_Root.Q<Button>(id_Exit__Button);

        m_Chapter_1__Button = m_Root.Q<Button>(id_Chapter_1__Button);
        m_Chapter_2__Button = m_Root.Q<Button>(id_Chapter_2__Button);
        m_Chapter_3__Button = m_Root.Q<Button>(id_Chapter_3__Button);
        m_Chapter_4__Button = m_Root.Q<Button>(id_Chapter_4__Button);

        m_Facebook__Button = m_Root.Q<Button>(id_Facebook__Button);
        m_Youtube__Button = m_Root.Q<Button>(id_Youtube__Button);
        m_ItchIO__Button = m_Root.Q<Button>(id_ItchIO__Button);
        m_Email__Button = m_Root.Q<Button>(id_Email__Button);

        m_Quit__Button = m_Root.Q<Button>(id_Quit__Button);

    }

    protected override void RegisterButtonCallBacks()
    {
        base.RegisterButtonCallBacks();

        m_Play__Button.RegisterCallback<ClickEvent>(ShowChapterPanel);
        m_Opinion__Button.RegisterCallback<ClickEvent>(ShowOpinionPanel);
        m_Exit__Button.RegisterCallback<ClickEvent>(ShowExitPanel);

        m_Chapter_1__Button.RegisterCallback<ClickEvent>(ShowChapter1);
        m_Chapter_2__Button.RegisterCallback<ClickEvent>(ShowChapter2) ;
        m_Chapter_3__Button.RegisterCallback<ClickEvent>(ShowChapter3) ;
        m_Chapter_4__Button.RegisterCallback<ClickEvent>(ShowChapter4) ;

        // m_Facebook__Button.RegisterCallback<ClickEvent>(ShowFacebook) ;
        // m_Youtube__Button.RegisterCallback<ClickEvent>(ShowYoutube) ;
        // m_ItchIO__Button.RegisterCallback<ClickEvent>(ShowItchIO) ;
        // m_Email__Button.RegisterCallback<ClickEvent>(ShowEmail) ;

        // m_Quit__Button.RegisterCallback<ClickEvent>(ExitGame) ;

       
    }

    private void GeometryChangedEventHandler(GeometryChangedEvent evt)
    {
        throw new NotImplementedException();
    }

    private void ShowPanel(VisualElement panel, List<VisualElement> elements)
    {
        foreach(VisualElement element in elements)
        {
            if(element == panel)
                panel.style.display = DisplayStyle.Flex;
            else 
                element.style.display = DisplayStyle.None;
        }
    }

    private void HighLighElement(VisualElement newSelect, string inacetiveClass, string activeClass, VisualElement root)
    {
        VisualElement currentSelect = root.Query<VisualElement>(classes: activeClass);
        if(currentSelect == newSelect) return;

        currentSelect?.RemoveFromClassList(activeClass);
        currentSelect?.AddToClassList(inacetiveClass);

        newSelect?.RemoveFromClassList(inacetiveClass);
        newSelect?.AddToClassList(activeClass);

    }
    private void MoveActiveMarker(VisualElement targetElement)
    {
        // world space position
        Vector2 targetInWorldSpace = targetElement.parent.LocalToWorld(targetElement.layout.position);

        // convert to local space of menu marker's parent
        Vector3 targetInRootSpace = m_Marker.parent.WorldToLocal(targetInWorldSpace);

        // difference between image sizes
        Vector3 offset = new Vector3(0f, targetElement.parent.layout.height - targetElement.layout.height + k_yOffset, 0f);

        Vector3 newPosition = targetInRootSpace - offset;

        // add extra animation time if moving more than one space 
        Vector3 delta = m_Marker.transform.position - newPosition;
        float distanceInPixels = Mathf.Abs(delta.y / k_Spacing);

        int duration = Mathf.Clamp((int)distanceInPixels * k_MoveTime, k_MoveTime, k_MoveTime * 4);

        m_Marker?.experimental.animation.Position(targetInRootSpace - offset, duration);
    }

    void ClickMarker(ClickEvent evt)
    {
        // Move the marker when we click the target VisualElement directly
        if(evt.propagationPhase == PropagationPhase.AtTarget)
        {
            MoveActiveMarker(evt.target as VisualElement);
        }
    }

    private void ExitGame(ClickEvent evt)
    {
        throw new NotImplementedException();
    }

    private void ShowEmail(ClickEvent evt)
    {
        throw new NotImplementedException();
    }

    private void ShowItchIO(ClickEvent evt)
    {
        throw new NotImplementedException();
    }

    private void ShowYoutube(ClickEvent evt)
    {
        throw new NotImplementedException();
    }

    private void ShowFacebook(ClickEvent evt)
    {
        throw new NotImplementedException();
    }

    private void ShowChapter4(ClickEvent evt)
    {
        throw new NotImplementedException();
    }

    private void ShowChapter3(ClickEvent evt)
    {
        throw new NotImplementedException();
    }

    private void ShowChapter2(ClickEvent evt)
    {
        throw new NotImplementedException();
    }

    private void ShowChapter1(ClickEvent evt)
    {
        throw new NotImplementedException();
    }

    private void ShowExitPanel(ClickEvent evt)
    {
        HighLighElement(m_Exit__Label, id_Unselect_Label__USS, id_Select_Label__USS, m_Root);
        ClickMarker(evt);
        ShowPanel(m_Exit__Container, Pannels);
    }

    private void ShowOpinionPanel(ClickEvent evt)
    {
        HighLighElement(m_Opinion__Label, id_Unselect_Label__USS, id_Select_Label__USS, m_Root);
        ClickMarker(evt);
        ShowPanel(m_Opinion__Container, Pannels);
    }

    private void ShowChapterPanel(ClickEvent evt)
    {
        HighLighElement(m_Play__Label, id_Unselect_Label__USS, id_Select_Label__USS, m_Root);
        ClickMarker(evt);
        ShowPanel(m_Chapter__Container, Pannels);
    }
}

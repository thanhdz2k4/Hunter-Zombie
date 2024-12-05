using System.Collections;
using System.Collections.Generic;
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

    [Header("LINK CONNECT")]
    [SerializeField] string id_Facebook__Link;
    [SerializeField] string id_Youtube__Link;
    [SerializeField] string id_ItchIO__Link;
    [SerializeField] string id_Email__Link;

    [Header("ID STYLE SHEET")]
    [SerializeField] string id_Select__Button;
    [SerializeField] string id_Unselect__Button;


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



    protected override void SetVisualElements()
    {
        base.SetVisualElements();
    }

    protected override void RegisterButtonCallBacks()
    {
        base.RegisterButtonCallBacks();
    }

}

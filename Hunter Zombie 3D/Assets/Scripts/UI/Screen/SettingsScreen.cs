using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public struct DataSetting
    {
    public string name;
    public string desciption;
    public List<string> value;    

    }


public class SettingsScreen : MenuScreen
{

    [Header("ID ELEMENTS UI IN SCREEN")]
    [SerializeField] string id_Target_Display__Button;
    [SerializeField] string id_Display_Mode__Button;
    [SerializeField] string id_Aspect_Ratio__Button;
    [SerializeField] string id_Resolution__Button;
    [SerializeField] string id_Anti_Aliasing__Button;
    [SerializeField] string id_Super_Resolution__Button;
    [SerializeField] string id_Frame_Generation__Button;
    [SerializeField] string id_Low_Latency__Button;
    [SerializeField] string id_Limit_FPS__Button;
    [SerializeField] string id_Show_FPS__Button;
    [SerializeField] string id_Title_Settings__Label;
    [SerializeField] string id_Desciption_Settings__Label;

    [SerializeField] string id_Target_Display__DropDown;
    [SerializeField] string id_Display_Mode__DropDown;
    [SerializeField] string id_Aspect_Ratio__DropDown;
    [SerializeField] string id_Resolution__DropDown;
    [SerializeField] string id_Anti_Aliasing__DropDown;
    [SerializeField] string id_Super_Resolution__DropDown;
    [SerializeField] string id_Frame_Generation__DropDown;
    [SerializeField] string id_Low_Latency__DropDown;

    [SerializeField] string id_Back__Button;


    

    [Header("ID STYLE SHEET")]
    [SerializeField] string id_Select__Button;
    [SerializeField] string id_Unselect__Button;

    [Header("DATA")]
    [SerializeField] DataSetting data_Target_Display__Button;
    [SerializeField] DataSetting data_Display_Mode__Button;
    [SerializeField] DataSetting data_Aspect_Ratio__Button;
    [SerializeField] DataSetting data_Resolution__Button;
    [SerializeField] DataSetting data_Anti_Aliasing__Button;
    [SerializeField] DataSetting data_Super_Resolution__Button;
    [SerializeField] DataSetting data_Frame_Generation__Button;
    [SerializeField] DataSetting data_Low_Latency__Button;
    [SerializeField] DataSetting data_Limit_FPS__Button;
    [SerializeField] DataSetting data_Show_FPS__Button;


    Button m_Target_Display__Button;
    Button m_Display_Mode__Button;
    Button m_Aspect_Ratio__Button;
    Button m_Resolution__Button;
    Button m_Anti_Aliasing__Button;
    Button m_Super_Resolution__Button;
    Button m_Frame_Generation__Button;
    Button m_Low_Latency__Button;
    Button m_Limit_FPS__Button;
    Button m_Show_FPS__Button;
    Label m_Title_Settings__Label;
    Label m_Desciption_Settings__Label;

    DropdownField m_Target_Display__DropDown;
    DropdownField m__Display_Mode__DropDown;
    DropdownField m__Aspect_Ratio__DropDown;
    DropdownField m__Resolution__DropDown;
    DropdownField m__Anti_Aliasing__DropDown;
    DropdownField m__Super_Resolution__DropDown;
    DropdownField m__Frame_Generation__DropDown;
    DropdownField m__Low_Latency__DropDown;

    Button m_Back__Button;



    private void Start()
    {
        SetDataIntoDropdownButton();
        SetDefaultDataDropDownButton();
    }


    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_Target_Display__Button = m_Root.Q<Button>(id_Target_Display__Button);
        m_Display_Mode__Button = m_Root.Q<Button>(id_Display_Mode__Button);
        m_Aspect_Ratio__Button = m_Root.Q<Button>(id_Aspect_Ratio__Button);
        m_Resolution__Button = m_Root.Q<Button>(id_Resolution__Button);
        m_Anti_Aliasing__Button = m_Root.Q<Button>(id_Anti_Aliasing__Button);
        m_Super_Resolution__Button = m_Root.Q<Button>(id_Super_Resolution__Button);
        m_Frame_Generation__Button = m_Root.Q<Button>(id_Frame_Generation__Button);
        m_Low_Latency__Button = m_Root.Q<Button>(id_Low_Latency__Button);
        m_Limit_FPS__Button = m_Root.Q<Button>(id_Limit_FPS__Button);
        m_Show_FPS__Button = m_Root.Q<Button>(id_Show_FPS__Button);
        m_Title_Settings__Label = m_Root.Q<Label>(id_Title_Settings__Label);
        m_Desciption_Settings__Label = m_Root.Q<Label>(id_Desciption_Settings__Label);

        m_Target_Display__DropDown = m_Root.Q<DropdownField>(id_Target_Display__DropDown);
        m__Display_Mode__DropDown = m_Root.Q<DropdownField>(id_Display_Mode__DropDown);
        m__Aspect_Ratio__DropDown = m_Root.Q<DropdownField>(id_Aspect_Ratio__DropDown);
        m__Resolution__DropDown = m_Root.Q<DropdownField>(id_Resolution__DropDown);
        m__Anti_Aliasing__DropDown = m_Root.Q<DropdownField>(id_Anti_Aliasing__DropDown);
        m__Super_Resolution__DropDown = m_Root.Q<DropdownField>(id_Super_Resolution__DropDown);
        m__Frame_Generation__DropDown = m_Root.Q<DropdownField>(id_Frame_Generation__DropDown);
        m__Low_Latency__DropDown = m_Root.Q<DropdownField>(id_Low_Latency__DropDown);

        m_Back__Button = m_Root.Q<Button>(id_Back__Button);


    }


    protected override void RegisterButtonCallBacks()
    {
        base.RegisterButtonCallBacks();
         m_Target_Display__Button.RegisterCallback<ClickEvent>(Show_Target_InformationEvent);
        m_Display_Mode__Button.RegisterCallback<ClickEvent>(Show_Display_InformationEvent);
        m_Aspect_Ratio__Button.RegisterCallback<ClickEvent>(Show_Aspect_InformationEvent);
        m_Resolution__Button.RegisterCallback<ClickEvent>(Show_Resolution_InformationEvent);
        m_Anti_Aliasing__Button.RegisterCallback<ClickEvent>(Show_Anti_InformationEvent);
        m_Super_Resolution__Button.RegisterCallback<ClickEvent>(Show_Super_InformationEvent);
        m_Frame_Generation__Button.RegisterCallback<ClickEvent>(Show_Frame_InformationEvent);
        m_Low_Latency__Button.RegisterCallback<ClickEvent>(Show_Low_InformationEvent);
        m_Limit_FPS__Button.RegisterCallback<ClickEvent>(Show_Limit_InformationEvent);
        m_Show_FPS__Button.RegisterCallback<ClickEvent>(Show_FPS_InformationEvent);

        m_Back__Button.RegisterCallback<ClickEvent>(HandleCloseScreenEvent);
    }

    private void HandleCloseScreenEvent(ClickEvent evt)
    {
        m_UIController.ShowMainScreen();
    }

    private void SetDataIntoDropdownButton()
    {
        m_Target_Display__DropDown.choices = data_Target_Display__Button.value;
        m__Display_Mode__DropDown.choices = data_Display_Mode__Button.value;
        m__Aspect_Ratio__DropDown.choices = data_Aspect_Ratio__Button.value;
        m__Resolution__DropDown.choices = data_Resolution__Button.value;
        m__Anti_Aliasing__DropDown.choices = data_Anti_Aliasing__Button.value;
        m__Super_Resolution__DropDown.choices = data_Super_Resolution__Button.value;
        m__Frame_Generation__DropDown.choices = data_Frame_Generation__Button.value;
        m__Low_Latency__DropDown.choices = data_Low_Latency__Button.value;
    }

    private void SetDefaultDataDropDownButton()
    {
        m_Target_Display__DropDown.index = 0;
        m__Display_Mode__DropDown.index = 0;
        m__Aspect_Ratio__DropDown.index = 0;
        m__Resolution__DropDown.index = 0;
        m__Anti_Aliasing__DropDown.index = 0;
        m__Super_Resolution__DropDown.index = 0;
        m__Frame_Generation__DropDown.index = 0;
        m__Low_Latency__DropDown.index = 0;
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

    

    private void SetData(DataSetting data)
    {
        m_Title_Settings__Label.text = data.name;
        m_Desciption_Settings__Label.text = data.desciption;
    }

    private void Show_Super_InformationEvent(ClickEvent evt)
    {
        HighLighElement(m_Super_Resolution__Button, id_Unselect__Button, id_Select__Button, m_Root);
        SetData(data_Super_Resolution__Button);
    }

    private void Show_FPS_InformationEvent(ClickEvent evt)
    {
        HighLighElement(m_Show_FPS__Button, id_Unselect__Button, id_Select__Button, m_Root);
        SetData(data_Show_FPS__Button);
    }

    private void Show_Limit_InformationEvent(ClickEvent evt)
    {
        HighLighElement(m_Limit_FPS__Button, id_Unselect__Button, id_Select__Button, m_Root);
        SetData(data_Limit_FPS__Button);
    }

    private void Show_Low_InformationEvent(ClickEvent evt)
    {
        HighLighElement(m_Low_Latency__Button, id_Unselect__Button, id_Select__Button, m_Root);
        SetData(data_Low_Latency__Button);
    }

    private void Show_Frame_InformationEvent(ClickEvent evt)
    {
        HighLighElement(m_Frame_Generation__Button, id_Unselect__Button, id_Select__Button, m_Root);
        SetData(data_Frame_Generation__Button);
    }

    private void Show_Anti_InformationEvent(ClickEvent evt)
    {
        HighLighElement(m_Anti_Aliasing__Button, id_Unselect__Button, id_Select__Button, m_Root);
        SetData(data_Anti_Aliasing__Button);
    }

    private void Show_Aspect_InformationEvent(ClickEvent evt)
    {
        HighLighElement(m_Aspect_Ratio__Button, id_Unselect__Button, id_Select__Button, m_Root);
        SetData(data_Aspect_Ratio__Button);
    }

    private void Show_Resolution_InformationEvent(ClickEvent evt)
    {
        HighLighElement(m_Resolution__Button, id_Unselect__Button, id_Select__Button, m_Root);
        SetData(data_Resolution__Button);
    }

    private void Show_Display_InformationEvent(ClickEvent evt)
    {
        HighLighElement(m_Display_Mode__Button, id_Unselect__Button, id_Select__Button, m_Root);
        SetData(data_Display_Mode__Button);
    }

    private void Show_Target_InformationEvent(ClickEvent evt)
    {
        HighLighElement(m_Target_Display__Button, id_Unselect__Button, id_Select__Button, m_Root);
        SetData(data_Target_Display__Button);
    }
}

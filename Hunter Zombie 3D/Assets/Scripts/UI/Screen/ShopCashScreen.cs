using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShopCashScreen : MenuScreen
{
    [Header("ID OF ELEMENTS IN SCREEN")]
    [SerializeField] string id_Group_Items__Visual;
    [SerializeField] string id_Gem_1__Button;
    [SerializeField] string id_Gem_2__Button;
    [SerializeField] string id_Gem_3__Button;
    [SerializeField] string id_Gem_4__Button;
    [SerializeField] string id_Gem_5__Button;
    [SerializeField] string id_Gem_6__Button;
    [SerializeField] string id_Back__Button;

    [Header("VALUE IN ITEMS")]
    [SerializeField] string Gem_1_value = "1,000 0.99";
    [SerializeField] string Gem_2_value = "10,000 1.99";
    [SerializeField] string Gem_3_value = "100,000 5.99";
    [SerializeField] string Gem_4_value = "1,000,000 8.99";
    [SerializeField] string Gem_5_value = "10,000,000 9.99";
    [SerializeField] string Gem_6_value = "100,000,000 00.99";

    [Header("TOAST")]
    [SerializeField] MainToast mainToast;

    VisualElement m_Group_Items__Visual;
    Button m_Gem_1__Button, m_Gem_2__Button, m_Gem_3__Button, m_Gem_4__Button, m_Gem_5__Button, m_Gem_6__Button, m_Back__Button;


    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_Gem_1__Button = m_Root.Q<Button>(id_Gem_1__Button);
        m_Gem_2__Button = m_Root.Q<Button>(id_Gem_2__Button);
        m_Gem_3__Button = m_Root.Q<Button>(id_Gem_3__Button);
        m_Gem_4__Button = m_Root.Q<Button>(id_Gem_4__Button);
        m_Gem_5__Button = m_Root.Q<Button>(id_Gem_5__Button);
        m_Gem_6__Button = m_Root.Q<Button>(id_Gem_6__Button);

        m_Group_Items__Visual = m_Root.Q<VisualElement>(id_Group_Items__Visual);

        m_Back__Button = m_Root.Q<Button>(id_Back__Button);
    }


    protected override void RegisterButtonCallBacks()
    {
        base.RegisterButtonCallBacks();

        m_Gem_1__Button.RegisterCallback<ClickEvent>(HandlerPurchangeGem1);
        m_Gem_2__Button.RegisterCallback<ClickEvent>(HandlerPurchangeGem2);
        m_Gem_3__Button.RegisterCallback<ClickEvent>(HandlerPurchangeGem3);
        m_Gem_4__Button.RegisterCallback<ClickEvent>(HandlerPurchangeGem4);
        m_Gem_5__Button.RegisterCallback<ClickEvent>(HandlerPurchangeGem5);
        m_Gem_6__Button.RegisterCallback<ClickEvent>(HandlerPurchangeGem6);

        m_Back__Button.RegisterCallback<ClickEvent>(HandleExitScreen);
        mainToast.EndPurchase += HandleEndPurchase;
        
    }

    private void HandleEndPurchase()
    {
        m_Group_Items__Visual.style.display = DisplayStyle.Flex;

    }

    private void SetDataInToToast(MainToast toast, string text)
    {
        toast.ShowScreen();
        string[] parts = text.Split(' ');
        toast.SetData("Do you want to exchange " + parts[1] +" dollars for " + parts[0] + " gems?");

    }

    private void HandleExitScreen(ClickEvent evt)
    {
        m_UIController.ShowMainScreen();
    }

    private void HandlerPurchangeGem6(ClickEvent evt)
    {
        SetDataInToToast(mainToast, Gem_6_value);
        m_Group_Items__Visual.style.display = DisplayStyle.None;

    }

    private void HandlerPurchangeGem5(ClickEvent evt)
    {
        SetDataInToToast(mainToast, Gem_5_value);
        m_Group_Items__Visual.style.display = DisplayStyle.None;
    }

    private void HandlerPurchangeGem4(ClickEvent evt)
    {
        SetDataInToToast(mainToast, Gem_4_value);
        m_Group_Items__Visual.style.display = DisplayStyle.None;
    }

    private void HandlerPurchangeGem3(ClickEvent evt)
    {
        SetDataInToToast(mainToast, Gem_3_value);
        m_Group_Items__Visual.style.display = DisplayStyle.None;
    }

    private void HandlerPurchangeGem1(ClickEvent evt)
    {
        SetDataInToToast(mainToast, Gem_1_value);
        m_Group_Items__Visual.style.display = DisplayStyle.None;
    }

    private void HandlerPurchangeGem2(ClickEvent evt)
    {
        SetDataInToToast(mainToast, Gem_2_value);
        m_Group_Items__Visual.style.display = DisplayStyle.None;
    }
}

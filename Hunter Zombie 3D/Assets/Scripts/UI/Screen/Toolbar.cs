using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Toolbar : MenuScreen
{
    [Header("ID OF ELEMENT IN SCREEN")]
    [SerializeField] string id_Add_Coin__Button;
    [SerializeField] string id_Shop__Button;
    [SerializeField] string id_Add_Friend__Button;
    [SerializeField] string id_Settings__Button;

    Button m_Add_Coin__Button, m_Shop__Button, m_Add_Friend__Button, m_Settings__Button;

     

     protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_Add_Coin__Button = m_Root.Q<Button>(id_Add_Coin__Button);
        m_Shop__Button = m_Root.Q<Button>(id_Shop__Button);
        m_Add_Friend__Button = m_Root.Q<Button>(id_Add_Friend__Button);
        m_Settings__Button = m_Root.Q<Button>(id_Settings__Button);

    }


    protected override void RegisterButtonCallBacks()
    {
        base.RegisterButtonCallBacks();

        m_Add_Coin__Button.RegisterCallback<ClickEvent>(ShowAddCoinScreen);
        m_Shop__Button.RegisterCallback<ClickEvent>(ShowShopScreen);
        m_Add_Friend__Button.RegisterCallback<ClickEvent>(ShowAddFiendScreen);
        m_Settings__Button.RegisterCallback<ClickEvent>(ShowSettingsScreen);
    }

    
    private void ShowSettingsScreen(ClickEvent evt)
    {
        throw new NotImplementedException();
    }

    private void ShowAddFiendScreen(ClickEvent evt)
    {
        throw new NotImplementedException();
    }

    private void ShowShopScreen(ClickEvent evt)
    {
        throw new NotImplementedException();
    }

    private void ShowAddCoinScreen(ClickEvent evt)
    {
        m_UIController.ShowCashShowScreen();
    }
}

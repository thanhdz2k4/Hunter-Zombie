using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
public class MainToast : MenuScreen
{

    [Header("ID OF ELEMENTS IN SCREEN")]
    [SerializeField] string id_Toast__Label;
    [SerializeField] string id_Back__Button;
    [SerializeField] string id_Accept__Button;
    Label m_Toast__Label;
    Button m_Back__Button, m_Accept__Button;

    public event Action EndPurchase;


    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_Toast__Label = m_Root.Q<Label>(id_Toast__Label);
        m_Back__Button = m_Root.Q<Button>(id_Back__Button);
        m_Accept__Button = m_Root.Q<Button>(id_Accept__Button);
    }

    protected override void RegisterButtonCallBacks()
    {
        base.RegisterButtonCallBacks();
        m_Back__Button.RegisterCallback<ClickEvent>(HandleBackScreen);
        m_Accept__Button.RegisterCallback<ClickEvent>(HandlePurchase);
    }

    private void HandlePurchase(ClickEvent evt)
    {
        m_Toast__Label.text = "Purchase successful!";
        m_Accept__Button.style.display = DisplayStyle.None;
    }

    private void HandleBackScreen(ClickEvent evt)
    {
        HideScreen();
        EndPurchase.Invoke();
    }

    public void SetData(string toast)
    {
        ShowScreen();
         m_Accept__Button.style.display = DisplayStyle.Flex;
        m_Toast__Label.text = toast;

    }
}

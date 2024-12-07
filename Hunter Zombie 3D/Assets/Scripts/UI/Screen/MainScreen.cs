using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class MainScreen : MenuScreen
{
    [Header("ID OF ELEMENT IN SCREEN")]
    [SerializeField] string id_Equipment__Button;
    [SerializeField] string id_Instruction__Button;
    [SerializeField] string id_Back__Button;
    [SerializeField] string id_Play__Button;
    [SerializeField] string id_Plot__Label;

    [Header("PLOT")]
    [SerializeField] TypeOutScript typeOutScript;

    Button m_Equipment__Button, m_Instruction__Button, m_Play__Button, m_Back__Button;
    Label m_Plot__Label;

    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_Equipment__Button = m_Root.Q<Button>(id_Equipment__Button);
        m_Instruction__Button = m_Root.Q<Button>(id_Instruction__Button);
        m_Play__Button = m_Root.Q<Button>(id_Play__Button);
        m_Back__Button = m_Root.Q<Button>(id_Back__Button);
        m_Plot__Label = m_Root.Q<Label>(id_Plot__Label);

    }

    protected override void RegisterButtonCallBacks()
    {
        base.RegisterButtonCallBacks();
        m_Equipment__Button.RegisterCallback<ClickEvent>(ShowEquipment);
        m_Instruction__Button.RegisterCallback<ClickEvent>(ShowInstruction);
        m_Play__Button.RegisterCallback<ClickEvent>(ShowPlayScreen);
        m_Back__Button.RegisterCallback<ClickEvent>(ShowBeginScreen);

        typeOutScript.OnTextTyped += HandlePlot;
    }

    public override void ShowScreen()
    {
        base.ShowScreen();
        this.typeOutScript.IsTyping = true;
    }

    private void ShowBeginScreen(ClickEvent evt)
    {
        throw new NotImplementedException();
    }

    private void HandlePlot(string text)
    {
        if(m_Plot__Label != null) m_Plot__Label.text = text;
    }

    private void ShowPlayScreen(ClickEvent evt)
    {
        throw new NotImplementedException();
    }

    private void ShowInstruction(ClickEvent evt)
    {
        throw new NotImplementedException();
    }

    private void ShowEquipment(ClickEvent evt)
    {
        throw new NotImplementedException();
    }
}

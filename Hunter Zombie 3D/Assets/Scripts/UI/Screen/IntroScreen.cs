using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class IntroScreen : MenuScreen
{
    [Header("NAME OF ID ELEMENTS IN SCREEN")]
    [SerializeField] private string id_Intro_Title__Label;
    [SerializeField] private string id_Intro_Play__Button;
    [SerializeField] private TypeOutScript typeOutScript;
    private Label m_Intro_Title__Label;
    private Button m_Intro_Play__Button;

    private void Update() 
    {
        AudioEffect();

    }

    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_Intro_Title__Label = m_Root.Q<Label>(id_Intro_Title__Label);
        m_Intro_Play__Button = m_Root.Q<Button>(id_Intro_Play__Button);
    }

    protected override void RegisterButtonCallBacks()
    {
        base.RegisterButtonCallBacks();
        typeOutScript.OnTextTyped += HandleTypeEffect;
        typeOutScript.OnConversationFinished += EndTypeEffect;
        m_Intro_Play__Button.RegisterCallback<ClickEvent>(ShowOptionScreen);
    }

    private void ShowOptionScreen(ClickEvent evt)
    {
        m_UIController.ShowOptionScreen();
    }

    private void EndTypeEffect()
    {
        m_Intro_Play__Button.style.display = DisplayStyle.Flex;
    }

    private void AudioEffect()
    {
        if (typeOutScript.isHasAudio)
        {
            AudioManager.instance.PlayTextTypeAudio();
        }
        else
        {
             AudioManager.instance.PauTextTypeAudio();
        }
    }

    

    private void HandleTypeEffect(string text)
    {
        if (m_Intro_Title__Label != null)
        {
            m_Intro_Title__Label.text = text;
        }
        
    }
}

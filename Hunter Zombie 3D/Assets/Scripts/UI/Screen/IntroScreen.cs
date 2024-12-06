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

    [SerializeField] AudioManager audioManager;
    private Label m_Intro_Title__Label;
    private Button m_Intro_Play__Button;
    [SerializeField] private bool isShow;

    private void Update() 
    {
        if(isShow) AudioEffect();
        
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
    public override void ShowScreen()
    {
         audioManager.PlayTextTypeAudio();
        base.ShowScreen();
        isShow = true;
    }

    public override void HideScreen()
    {
        base.HideScreen();
        isShow = false;
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
             audioManager.PlayTextTypeAudio();
        } else {
            audioManager.PauTextTypeAudio();

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

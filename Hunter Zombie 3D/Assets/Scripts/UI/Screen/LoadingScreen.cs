using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.UIElements;

public class LoadingScreen : MenuScreen
{
    [SerializeField] string id_Loading__Label;
    [SerializeField] TypeOutScript typeOutScript;
    [SerializeField] AudioManager audioManager;

    [SerializeField]Label m_Loading__Label;

    private bool isShow;

    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_Loading__Label = m_Root.Q<Label>(id_Loading__Label);
    }

    protected override void RegisterButtonCallBacks()
    {
        base.RegisterButtonCallBacks();
        typeOutScript.OnTextTyped += HandleTypeEffect;
        typeOutScript.OnConversationFinished += EndTypeEffect;
    }

    public override void ShowScreen()
    {
        base.ShowScreen();
        isShow = true;
    }

    public override void HideScreen()
    {
        base.HideScreen();
        isShow = false;
    }

    private void EndTypeEffect()
    {
        
    }

    private void Update() 
    {
        if(isShow) AudioEffect();
    }

    private void AudioEffect()
    {
        if (typeOutScript.isHasAudio)
        {
            audioManager.PlayTextTypeAudio();
        }
        else
        {
            audioManager.PauTextTypeAudio();
        }
    }

    private void HandleTypeEffect(string text)
    {
        if (m_Loading__Label != null)
        {
            m_Loading__Label.text = text;
        }
    }

    public void TriggerTypeScreen() {
        this.typeOutScript.IsTyping = true;
        this.typeOutScript.isHasAudio = true;
    }
}

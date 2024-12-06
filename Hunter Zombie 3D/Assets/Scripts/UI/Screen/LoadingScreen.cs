using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LoadingScreen : MenuScreen
{
    [SerializeField] string id_Loading__Label;
    [SerializeField] TypeOutScript typeOutScript;

    Label m_Loading__Label;

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

    private void EndTypeEffect()
    {
        
    }

    private void Update() 
    {
        AudioEffect();

    }

    private void AudioEffect()
    {
        if (typeOutScript.isHasAudio)
        {
            AudioManager.instance.PlayTextTypeAudio();
        }
        else
        {
            AudioManager.instance.PlayTextTypeAudio();
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
    }
}

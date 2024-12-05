using System;
using System.Text;
using UnityEngine;

public class TypeOutScript : MonoBehaviour
{
    public bool On = true;
    public bool reset = false;
    public string FinalText;
    public float TotalTypeTime = -1f;
    public float TypeRate;
    private float LastTime;
    public string RandomCharacter;
    public float RandomCharacterChangeRate = 0.1f;
    private float RandomCharacterTime;
    private int i;

    public event Action<string> TextType;

    private string RandomChar()
    {
        byte value = (byte)UnityEngine.Random.Range(41f, 128f);
        return Encoding.ASCII.GetString(new byte[] { value });
    }

    public string Skip()
    {
        On = false;
        return FinalText;
    }

    private void Update()
    {
        HandleText();
    }

    private void HandleText()
    {
        if (TotalTypeTime != -1f)
        {
            TypeRate = TotalTypeTime / (float)FinalText.Length;
        }

        if (On)
        {
            // Update random character periodically
            if (Time.time - RandomCharacterTime >= RandomCharacterChangeRate)
            {
                RandomCharacter = RandomChar();
                RandomCharacterTime = Time.time;
            }

            // Build and display text
            if (i < FinalText.Length)
            {
                TextType?.Invoke(FinalText.Substring(0, i) + RandomCharacter);

                if (Time.time - LastTime >= TypeRate)
                {
                    i++;
                    LastTime = Time.time;
                }

                // Skip spaces
                while (i < FinalText.Length && FinalText[i] == ' ')
                {
                    i++;
                }
            }
            else
            {
                On = false;
                TextType?.Invoke(FinalText);
            }

            // Handle reset
            if (reset)
            {
                TextType?.Invoke("");
                i = 0;
                reset = false;
                On = true;
            }
        }
    }
}

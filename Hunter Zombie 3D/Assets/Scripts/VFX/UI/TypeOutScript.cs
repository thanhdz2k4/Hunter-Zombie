using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class TypeOutScript : MonoBehaviour
{
    public bool On = true;
    public bool reset = false;
    public String FinalText;
    public float TotalTypeTime = -1f;
    public float TypeRate;
    private float LastTime;
    public string RandomCharactor;
    public float RandomCharaterChangeRate = 0.1f;
    private float RandomCharacterTime;
    private int i;

    public event Action<string> TextType;

    private string RandomChar() 
    {
        byte value = (byte) UnityEngine.Random.Range(41f, 128f);
        string c = Encoding.ASCII.GetString(new byte[] {value});
        return c;
    }

    public string Skip() 
    {
        On = false;
        return FinalText;       
    }

    void HandleText() 
    {
        if(TotalTypeTime != -1f) 
        {
            TypeRate = TotalTypeTime/(float)FinalText.Length;
        }

        if(On) 
        {
            if(Time.time - RandomCharacterTime >= RandomCharaterChangeRate) 
            {
                RandomCharactor = RandomChar();
                RandomCharacterTime = Time.time;
            }

            try 
            {
                TextType?.Invoke(FinalText.Substring(0, i) + RandomCharactor);
            }
            catch(ArgumentOutOfRangeException)
            {
                On = false;
            }

            if(Time.time - LastTime >= TypeRate) 
            {
                i++;
                LastTime = Time.time;
            }
            bool isChar = false;

            while(!isChar) 
            {
                if((i+1) < FinalText.Length) 
                {
                    if(FinalText.Substring(i, 1) == " ") 
                    {
                        i++;
                    }
                    else
                    {
                        isChar = false;
                    }
                }
                else
                {
                    isChar = true;
                }
            }

            if(reset == true)
            {
                 TextType?.Invoke("");
                i = 0;
                reset = false;
            }



        }

    }


}

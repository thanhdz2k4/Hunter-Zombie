using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFloatingText : Playable
{
    [SerializeField] GameObject Damage_Text_Prefab;
    [SerializeField] Transform positionSpawnText;
    [SerializeField] Color[] colors;
    
    public override void IsPlay(bool isPlay)
    {
        SpawnText();
    }

    private void SpawnText()
    {
        GameObject obj = Instantiate(Damage_Text_Prefab, positionSpawnText.position, Quaternion.identity);

        //Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        Vector3 eulerAngles = new Vector3(0, 100, 0);
        obj.transform.rotation = Quaternion.Euler(eulerAngles);
        obj.GetComponent<TextMesh>().color = colors[Random.Range(0, colors.Length)];
        obj.GetComponent<TextMesh>().offsetZ = Random.Range(-1, 1);


    }
}

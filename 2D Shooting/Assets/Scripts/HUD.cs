using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//gameMaster에서 관리하는 목숨수로 heartUI관리
public class HUD : MonoBehaviour
{
    public Sprite[] HeartSprites;
    public Image HeartUI;
    private gameMaster gm;



    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameMaster").GetComponent<gameMaster>();
    
    }

    // Update is called once per frame
    void Update()
    {
        HeartUI.sprite = HeartSprites[gm.cherries];
    }
}

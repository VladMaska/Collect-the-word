/*
 __   __   __         ______     _____     __    __     ______     ______     __  __     ______    
/\ \ /  / /\ \       /\  __ \   /\  __-.  /\ "-./  \   /\  __ \   /\  ___\   /\ \/ /    /\  __ \   
\ \ \' /  \ \ \____  \ \  __ \  \ \ \/\ \ \ \ \-./\ \  \ \  __ \  \ \___  \  \ \  _"-.  \ \  __ \  
 \ \__/    \ \_____\  \ \_\ \_\  \ \____-  \ \_\ \ \_\  \ \_\ \_\  \/\_____\  \ \_\ \_\  \ \_\ \_\ 
  \/_/      \/_____/   \/_/\/_/   \/____/   \/_/  \/_/   \/_/\/_/   \/_____/   \/_/\/_/   \/_/\/_/ 

*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using NaughtyAttributes;

public class GenerateTextBlocks : MonoBehaviour {

    public GameObject text;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    int startX;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    void Start(){

        TextCore tx = this.gameObject.GetComponent<TextCore>();

        int n = GameCore.GetWord().Length;

        startX = -( ( n - 1 ) * 150 ) / 2;

        for ( int i = 0; i < n; i++ ){

            GameObject obj = Instantiate( text ) as GameObject;
            obj.transform.SetParent( this.transform, false );
            obj.name = $"{ i + 1 }";
            obj.GetComponent<LetterScript>().letter = $"{ GameCore.GetWord()[i] }";
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2( startX + ( i * 150 ), 0 );

        }

    }

}
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

public class LetterScript : MonoBehaviour {

    public string letter;

    public bool correct;
    public Text text;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    void Start() => text.GetComponent<Text>().text = "";

    void Update(){

        text.text = GameCore.yourWord[ int.Parse( gameObject.name ) - 1 ].ToString();

    }

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    public void Clean(){

        int space = GameCore.spaceForLetter;

        if ( GameCore.yourWord[ int.Parse( gameObject.name ) - 1 ] != ' ' ){

            GameCore.yourWord[ int.Parse( gameObject.name ) - 1 ] = ' ';

            if ( space > int.Parse( gameObject.name ) - 1 ){
                GameCore.spaceForLetter = int.Parse( gameObject.name ) - 1;
            }
            else { GameCore.spaceForLetter = space; }

        }

    }

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

}
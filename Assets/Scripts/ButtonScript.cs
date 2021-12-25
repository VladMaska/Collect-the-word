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

public class ButtonScript : MonoBehaviour {

    public char letter;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    void Start(){

        GameObject.Find( $"/Canvas/Panel/Letters/{ this.gameObject.name }/Text" ).GetComponent<Text>().text = $"{ letter }";

    }

    void Update(){

        GameObject.Find( $"/Canvas/Panel/Letters/{ this.gameObject.name }/Text" ).GetComponent<Text>().text = $"{ letter }";
        
    }

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    public void ClickLetter() => TextCore.WriteLetter( letter );

}
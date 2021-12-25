/*
 __   __   __         ______     _____     __    __     ______     ______     __  __     ______    
/\ \ /  / /\ \       /\  __ \   /\  __-.  /\ "-./  \   /\  __ \   /\  ___\   /\ \/ /    /\  __ \   
\ \ \' /  \ \ \____  \ \  __ \  \ \ \/\ \ \ \ \-./\ \  \ \  __ \  \ \___  \  \ \  _"-.  \ \  __ \  
 \ \__/    \ \_____\  \ \_\ \_\  \ \____-  \ \_\ \ \_\  \ \_\ \_\  \/\_____\  \ \_\ \_\  \ \_\ \_\ 
  \/_/      \/_____/   \/_/\/_/   \/____/   \/_/  \/_/   \/_/\/_/   \/_____/   \/_/\/_/   \/_/\/_/ 

*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIScript : MonoBehaviour {

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    bool hint = false;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    void Start() => hint = false; 

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    public void Hint(){

        if ( !hint ){

            int n = Random.Range( 0, GameCore.GetWord().Length - 1 );
            GameCore.yourWord[ n ] = GameCore.GetWord()[ n ];
            hint = true;

        }

    }

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    public void CleanAll(){

        for ( int i=0; i< GameCore.yourWord.Length; i++ ){

            GameCore.yourWord[ i ] = ' ';

        }

        GameCore.spaceForLetter = 0;

    }

}
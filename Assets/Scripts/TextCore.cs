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

using NaughtyAttributes;

public class TextCore : MonoBehaviour {

    public char l;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    [Button]
    void Test() => WriteLetter( l );

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    public static void WriteLetter( char letter ){

        char l = GameCore.yourWord[ GameCore.spaceForLetter ];

        if ( l == ' ' ){ GameCore.yourWord[ GameCore.spaceForLetter ] = letter; }
        else {

            GameCore.spaceForLetter++;
            WriteLetter( letter );

        }

        GameCore.Check();

    }

}
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

[System.Serializable]
public class keyBoard_1 {

    public bool comp = false;
    public int b = -1;
    public char l = ' ';

}

public class KeyBoard : MonoBehaviour {

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    public keyBoard_1[] kb = new keyBoard_1[ 12 ];
    public char[] needLetters;

    //string options = "ABCDEFGHIKLMNOPQRSTVXYZ";
    string options = GameCore.options;

    public int needLn;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    void Start(){

        SetKeyBoard();
        SetNeedLetters();

        needLn = needLetters.Length;

        for ( int i=0; i< needLn; i++ ){ NewKey(); }

        SetKeys();

    }

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    [Button]
    void SetKeyBoard(){

        for ( int i=0; i<kb.Length; i++ ){

            kb[ i ].comp = false;
            kb[ i ].b = -1;
            kb[ i ].l = ' ';

        }

    }

    [Button]
    void SetNeedLetters(){

        needLetters  = new char[ GameCore.GetWord().Length ];

        for ( int i=0; i<needLetters.Length; i++ ){

            needLetters[ i ] = GameCore.GetWord()[ i ];

        }

    }

    [Button]
    void NewKey(){

        // VladMaska
        int id = Random.Range( 1, kb.Length );

        int letterN = Random.Range( 0, needLetters.Length - 1 );
        char letter = needLetters[ letterN ];

        if ( !kb[ id ].comp ){

            kb[ id ].comp = true;
            kb[ id ].b = id;
            kb[ id ].l = letter;

            Remove( ref needLetters, letterN );

        }
        else { NewKey(); }

    }

    public static void Remove<T>( ref T[] array, int index ){

        for ( int i = index; i < array.Length - 1; i++ ){ array[ i ] = array[ i + 1 ]; }
        System.Array.Resize( ref array, array.Length - 1);

    }

    public void SetKeys(){

        int children = transform.childCount;

        for ( int i = 0; i < children; ++i ){

            if ( kb[ i ].comp ){

                transform.GetChild( i ).GetComponent<ButtonScript>().letter = kb[ i ].l;

            } else {

                transform.GetChild( i ).GetComponent<ButtonScript>().letter = options[ Random.Range( 0, options.Length ) ];

            }

        }

    }

}
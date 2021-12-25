/*
 __   __   __         ______     _____     __    __     ______     ______     __  __     ______    
/\ \ /  / /\ \       /\  __ \   /\  __-.  /\ "-./  \   /\  __ \   /\  ___\   /\ \/ /    /\  __ \   
\ \ \' /  \ \ \____  \ \  __ \  \ \ \/\ \ \ \ \-./\ \  \ \  __ \  \ \___  \  \ \  _"-.  \ \  __ \  
 \ \__/    \ \_____\  \ \_\ \_\  \ \____-  \ \_\ \ \_\  \ \_\ \_\  \/\_____\  \ \_\ \_\  \ \_\ \_\ 
  \/_/      \/_____/   \/_/\/_/   \/____/   \/_/  \/_/   \/_/\/_/   \/_____/   \/_/\/_/   \/_/\/_/ 

*/

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

using WhiteWolf;

public class GameCore : MonoBehaviour {

    public GameObject[] imgs;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    int maxLevel = 6;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    static bool nl;

    public static int level = 1;
    public static int clickedImg = -1;

    /* – – – */

    // RUS

    //public static string options = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
    //public static string[] words = {
    //    "РОЗА",
    //    "ПАНДА",
    //    "ПОЛЬША",
    //    "СВЕТ",
    //    "ЗЕМЛЯ",
    //    "ЯПОНИЯ"
    //};

    // ENG

    public static string options = "ABCDEFGHIKLMNOPQRSTVXYZ";
    public static string[] words = {
        "ROSE",
        "PANDA",
        "POLAND",
        "LIGHT",
        "EARTH",
        "JAPAN"
    };

    /* – – – – – – – – – */

    public static char[] needWord;
    public static char[] yourWord;

    public static int spaceForLetter;

    public static bool error = false;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    void Start(){

        // Set array size
        yourWord = new char[ words[ level - 1 ].Length ];

        // Filed array
        CleanYourWord();

        CloseAll();
        WW_Database.SaveDataInt( $"{level}_1", 2 );
        WW_Database.SaveDataInt( $"{level}_2", 1 );

        WW_Database.SaveDataInt( "coins", 9 );

    }

    void Update(){ if ( nl ){ StartCoroutine( NextLevel() ); } }

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    public void Hide( int n ){

        clickedImg = n;

        for ( int i=0; i<imgs.Length; i++ ){

            if ( i != n - 1 ){ imgs[ i ].SetActive( false ); }

        }

    }

    public void Show(){

        for ( int i=0; i<imgs.Length; i++ ){

            if ( i != clickedImg - 1 ){ imgs[ i ].SetActive( true ); }

        }

    }

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    void OpenAll(){

        for ( int i=0; i<4; i++ ){ WW_Database.SaveDataInt( $"{level}_{i+1}", 2 ); }

    }

    void CloseAll(){

        for ( int i=0; i<4; i++ ){ WW_Database.SaveDataInt( $"{level}_{i+1}", 0 ); }

    }

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    public static string GetWord(){ return words[ level - 1 ]; }

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    public static void Check(){

        string res = null;

        for ( int i=0; i<yourWord.Length; i++ ){ res += yourWord[ i ]; }

        if ( res == GetWord() ){ nl = true; }
        else { nl = false; }

    }

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    public static void CleanYourWord(){ for ( int i=0; i< yourWord.Length; i++ ){ yourWord[ i ] = ' '; } }

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    IEnumerator NextLevel(){

        nl = false;
        spaceForLetter = 0;
        OpenAll();

        yield return new WaitForSeconds( 1 );

        CloseAll();

        if ( level == maxLevel ){ level = 1; }
        else { level++; }

        SceneManager.LoadScene( 0 );

    }

}
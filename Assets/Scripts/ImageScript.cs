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
using WhiteWolf;

public class ImageScript : MonoBehaviour {

    public string id;
    public bool clicked;

    [HorizontalLine]

    public int price;

    [HorizontalLine]

    public GameObject blur;
    public GameObject _lock;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    RectTransform rt;
    Vector2 startPos;
    float scale;

    GameCore core;

    public Sprite[] sprites;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    void Start(){

        id = $"{GameCore.level}_{this.gameObject.name}";

        sprites = Resources.LoadAll<Sprite>( $"{ GameCore.level }" );
        this.gameObject.GetComponent<Image>().sprite = sprites[ int.Parse( this.gameObject.name ) - 1 ];

        core = GameObject.Find( "GameCore" ).GetComponent<GameCore>();

        rt = this.gameObject.GetComponent<RectTransform>();
        startPos = rt.anchoredPosition;

        scale = rt.localScale.x;
        
    }

    void Update(){

        switch ( WW_Database.LoadDataInt( id ) ){

            case 0:

                _lock.SetActive( true );
                blur.SetActive( false );
                break;

            case 1:

                _lock.SetActive( false );
                blur.SetActive( true );
                break;

            case 2:

                _lock.SetActive( false );
                blur.SetActive( false );
                break;

        }
        
    }

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    public void BuyImage(){

        //if ( gameObject.name != "4" ){

        //    WW_Database.MinusInt( "coins", price );

        //    WW_Database.SaveDataInt( id, 2 );
        //    WW_Database.SaveDataInt( $"{GameCore.level}_{ int.Parse( this.gameObject.name ) + 1 }", 1 );

        //}
        //else { WW_Database.SaveDataInt( id, 2 ); }

        WW_Database.MinusInt( "coins", price );

        WW_Database.SaveDataInt( id, 2 );
        WW_Database.SaveDataInt( $"{GameCore.level}_{ int.Parse( this.gameObject.name ) + 1 }", 1 );

    }

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    public void Click(){

        if ( !clicked && WW_Database.LoadDataInt( id ) == 2 ){

            core.Hide( int.Parse( gameObject.name ) );

            rt.anchoredPosition = new Vector2( 0, 0 );
            rt.localScale = new Vector3( scale * 2, scale * 2, scale * 2 );
            clicked = true;

        }
        else {

            core.Show();

            rt.anchoredPosition = startPos;
            rt.localScale = new Vector3( scale, scale, scale );
            clicked = false;

        }

    }

}
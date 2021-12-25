using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using WhiteWolf;

public class Coins : MonoBehaviour {

    public Text text;

    void Update() => text.GetComponent<Text>().text = WW_Database.LoadDataInt( "coins" ).ToString();

}
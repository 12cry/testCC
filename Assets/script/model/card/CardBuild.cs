using System;
using testCC.Assets.script;
using testCC.Assets.script.model;
using UnityEngine;

public class CardBuild : Card {

    public override void action () {
        Debug.Log ("action---");
        this.updateResource ();
        this.build ();
        Utils.takedCardCtrls.Remove (this.cardCtrl);
        this.cardCtrl.destroy ();
        this.afterAction ();
    }
    public void build () {
        if (this.id == 1001) {

        }

    }
}
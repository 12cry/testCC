using System;
using System.IO;
using DG.Tweening;
using testCC.Assets.script;
using testCC.Assets.script.ctrl;
using UnityEngine;
using UnityEngine.UI;

public abstract class Card {
    public CardCtrl cardCtrl;
    // public Texture texture;
    public string cardName;
    public int age;

    public bool canTake;
    public bool canAction;
    public bool taked = false;
    Tweener cardTween;

    public void see () {

        cardTween = cardCtrl.transform.DOMove (new Vector3 (Screen.width / 2, Screen.height / 2, 0), Utils.cardMoveSpeed).SetAutoKill (false);

        ButtonCloseCtrl bcc = ButtonCloseCtrl.instance;
        bcc.card = this;
        bcc.gameObject.SetActive (true);

        UICtrl uiCtrl = UICtrl.instance;
        if (canTake) {
            ButtonTakeCardCtrl btc = ButtonTakeCardCtrl.instance;
            btc.card = this;
            btc.gameObject.SetActive (true);
        }
        if (canAction) {
            ButtonActionCardCtrl btc = ButtonActionCardCtrl.instance;
            btc.card = this;
            btc.gameObject.SetActive (true);
        }

    }
    public void close () {
        cardTween.Rewind ();
    }
    public void take () {
        cardCtrl.transform.DOMove (new Vector3 (Utils.cardWidth / 2 + Utils.takedCardCtrls.Count * 20, Utils.cardWidth / 2, 0 + Utils.takedCardCtrls.Count), Utils.cardMoveSpeed);
        canAction = true;
        canTake = false;
        Utils.takedCardCtrls.Add (cardCtrl);
        taked = true;
    }
    public abstract void action ();
}
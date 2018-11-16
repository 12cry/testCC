using System;
using System.IO;
using DG.Tweening;
using testCC.Assets.script;
using UnityEngine;
using UnityEngine.UI;

public abstract class Card {
    public CardCtrl cardCtrl;
    // public Texture texture;
    public string cardName;
    public int age;

    bool canTake;
    bool canAction;
    Tweener cardTween;

    public void see () {

        cardTween = cardCtrl.transform.DOMove (new Vector3 (1, 5, 0), 2).SetAutoKill (false);

        if (canTake) {
            ButtonTakeCardCtrl btc = ButtonTakeCardCtrl.instance;
            btc.card = this;
            btc.gameObject.SetActive (true);
        }
        if (canAction) {
            ButtonTakeCardCtrl btc = ButtonTakeCardCtrl.instance;
            btc.card = this;
            btc.gameObject.SetActive (true);
        }

    }
    public void nosee () {
        ButtonTakeCardCtrl.instance.gameObject.SetActive (false);
        ButtonTakeCardCtrl.instance.gameObject.SetActive (false);
        cardTween.Rewind();
    }
    public void take () {
        cardCtrl.transform.DOMove (new Vector3 (1, 5, 0), 2);
    }
    public abstract void action ();
}
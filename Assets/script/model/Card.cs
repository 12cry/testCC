using System;
using System.IO;
using DG.Tweening;
using testCC.Assets.script;
using testCC.Assets.script.ctrl;
using testCC.Assets.script.model;
using UnityEngine;
using UnityEngine.UI;

public abstract class Card {
    public CardCtrl cardCtrl;

    public int id;
    public string cardName;
    public int age;
    public Cost cost;
    public Income income;

    public bool canTake;
    public bool canAction;
    public bool taked = false;
    public int takeCiv = 1;

    Tweener cardTween;
    UICtrl uiCtrl = UICtrl.instance;

    public void view () {
        Utils.currentCard = this;

        cardTween = cardCtrl.transform.DOMove (new Vector3 (Screen.width / 2, Screen.height / 2, 0), Utils.cardMoveSpeed).SetAutoKill (false);

        uiCtrl.showBCloseCard ();
        if (canTake) {
            uiCtrl.showBTakeCard ();
        }
        if (canAction) {
            uiCtrl.showBActionCard ();
        }

    }
    public void closeView () {
        cardTween.Rewind ();
        uiCtrl.hideSeeButton ();
    }
    public void take () {
        cardCtrl.transform.DOMove (new Vector3 (Utils.cardWidth / 2 + Utils.takedCardCtrls.Count * 20, Utils.cardWidth / 2, 0 + Utils.takedCardCtrls.Count), Utils.cardMoveSpeed);
        canAction = true;
        canTake = false;
        taked = true;
        Utils.takedCardCtrls.Add (cardCtrl);
        uiCtrl.hideSeeButton ();

        Utils.resource.updateCiv (this.takeCiv);
    }
    public void updateResource () {
        Utils.resource.updateScience (-cost.science);

        Utils.resource.updateFoodIncrement (income.food);
        Utils.resource.updateCapacityIncrement (income.capacity);
        // Utils.resource.updateScienceIncrement (output[2]);
        // Utils.resource.updateCultureIncrement (output[3]);
    }

    public void afterAction () {
        Utils.resource.updateCiv (1);
    }
    public abstract void action ();
}
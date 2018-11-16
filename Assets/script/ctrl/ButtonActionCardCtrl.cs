﻿using Cry.Common;
using UnityEngine;

namespace testCC.Assets.script {
    public class ButtonActionCardCtrl : Singleton<ButtonActionCardCtrl> {
        public Card card;

        public void onClick(){
            card.action();
        }
        protected override void Awake () {
            base.Awake ();
        }
    }
}
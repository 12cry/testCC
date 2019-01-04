using System;
using testCC.Assets.script;
using UnityEngine;

public class CardBuild : Card {
    public int[] input;
    public int[] output;

    public override void action () {
        Debug.Log ("action---");
        Debug.Log (output);
        Utils.resource.updateScience (-input[0]);

        Utils.resource.updateFoodIncrement (output[0]);
        Utils.resource.updateCapacityIncrement (output[1]);
        Utils.resource.updateScienceIncrement (output[2]);
        Utils.resource.updateCultureIncrement (output[3]);
    }
}
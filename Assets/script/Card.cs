using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public abstract class Card {
    public string cardName;
    public int age;
    // public Texture texture;
    public abstract void action ();
}
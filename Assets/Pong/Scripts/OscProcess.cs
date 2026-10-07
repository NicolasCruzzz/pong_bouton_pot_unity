using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;

public class OscProcess : MonoBehaviour
{   
    public extOSC.OSCReceiver oscReceiver;
    public GameManager gameManager;
    public PlayerPaddle playerPaddle;
    public BouncySurface bouncySurface;
    public int potInMin = 0;
    public int potInMax = 1023;
    public float potOutMin = 0.0f;
    public float potOutMax = 1.0f;

 
    // Start is called before the first frame update
    void Start()
    {
        oscReceiver.Bind("/but0", TraiterMessageBut0);
        oscReceiver.Bind("/pot", TraiterMessagePot);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void TraiterMessagePot(OSCMessage message)
    {
     // Validez qu’il y a bien le nombre attendu d’arguments (1 dans l’exemple) :
     if (message.Values.Count != 1)
     {
          Debug.Log("Le message " + message.Address  + " n’a pas le bon nombre d’arguments");
          return; // Quitte la fonction sans exécuter la suite
      }

       // Vérifiez que l’argument est du type attendu (`int` dans l’exemple) :
       if (message.Values[0].Type != OSCValueType.Int)
       {
           Debug.Log("Le premier argument du message " + message.Address  + "n’est pas un entier");
           return; // Quitte la fonction sans exécuter la suite
       }

     // Récupérer la valeur de l’argument :
      int valeur = message.Values[0].IntValue;

       // Deboguer
      // Debug.Log("Reçu : " + message.Address + " " + valeur);

       // TRAITER LA VALEUR ICI !
        float ajuste = (((float)valeur - potInMin) / (potInMax - potInMin) * (potOutMax - potOutMin) + potOutMin);
       // AJOUTER À LA LIGNE SUIVANTE LE CODE POUR APPLIQUER LA VARIABLE ajuste AU DÉPLACEMENT DE LA PALETTE ICI !
        playerPaddle.SetPosition(ajuste);
       // COMME INDICE C’EST QQCH COMME : palette.setVercialPosition( ajuste);

    }

    void TraiterMessageBut0(OSCMessage message)
    {
      // Validez qu’il y a bien le nombre attendu d’arguments (1 dans l’exemple) :
      if (message.Values.Count != 1)
      {
         Debug.Log("Le message " + message.Address  + " n’a pas le bon nombre d’arguments");
         return; // Quitte la fonction sans exécuter la suite
      }


      // Vérifiez que l’argument est du type attendu (`int` dans l’exemple) :
      if (message.Values[0].Type != OSCValueType.Int)
      {
          Debug.Log("Le premier argument du message " + message.Address  + "n’est pas un entier");
          return; // Quitte la fonction sans exécuter la suite
      }
    

      // Récupérer la valeur de l’argument :
      int valeur = message.Values[0].IntValue;

     // Deboguer
     // Debug.Log("Reçu : " + message.Address + " " + valeur);

     // TRAITER LA VALEUR ICI !
     if (valeur == 1)
     {
         gameManager.ThrowBall(); // Ignored if game is already playing, handled in GameManager
     } else {

    }

}

}

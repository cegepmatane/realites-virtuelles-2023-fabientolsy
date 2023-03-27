using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionCube : MonoBehaviour 
{
    private string codeUtilisateur; 

    [Header("Code de validation")]
    public string code = "1234";

    [Header("Mur a desactiver")]
    public GameObject mur;

    private string chiffreTemporaire = "";

    public void afficher(string nom)
    {
        Debug.Log("On appelle le fichier parent depuis le chiffre " + nom +  "!");
        valider(nom);
    }

    private void valider (string nom) 
    {
        if (nom != chiffreTemporaire) {

            codeUtilisateur = codeUtilisateur + nom;

            if (codeUtilisateur.Length == code.Length)
            {
                if (codeUtilisateur == code)
                {
                    Debug.Log("Desactivation du mur");
                    mur.SetActive(false);
                }
                else
                {
                    Debug.Log("Mauvais code saisis");
                    codeUtilisateur = "";
                }
            }
            else { chiffreTemporaire = nom; }
        }

        else
        {
            Debug.Log("Impossible de traiter cette entree !");
        }
    }
}

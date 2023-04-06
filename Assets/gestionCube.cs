using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gestionCube : MonoBehaviour 
{
    private string codeUtilisateur; 

    [Header("Code de validation")]
    public string code = "1234";

    [Header("Mur a desactiver")]
    public GameObject mur;

    [Header("Ecran")]
    public TextMesh affichage ;
    public TextMeshPro affichageTest;

    private string chiffreTemporaire = "";
    private bool finCode = false;

    public void afficher(string nom)
    {
        Debug.Log("On appelle le fichier parent depuis le chiffre " + nom +  "!");
        valider(nom);
    }

    private void valider (string nom) 
    {
        if(finCode == true) { finEntreeCode(); }
        else { 
            if (nom != chiffreTemporaire) {

                codeUtilisateur = codeUtilisateur + nom;
                affichage.text = codeUtilisateur;
                affichageTest.text = codeUtilisateur;

                if (codeUtilisateur.Length == code.Length)
                {
                    if (codeUtilisateur == code)
                    {
                        Debug.Log("Desactivation du mur");
                        mur.SetActive(false);

                        finCode = true;
                        finEntreeCode();
                    }
                    else
                    {
                        Debug.Log("Mauvais code saisis");
                        codeUtilisateur = "";
                        affichage.text = codeUtilisateur;
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

    private void finEntreeCode()
    {
        affichage.text = "";
        affichage.text = "Reussit !";
        affichage.characterSize = .5f;
    }
}

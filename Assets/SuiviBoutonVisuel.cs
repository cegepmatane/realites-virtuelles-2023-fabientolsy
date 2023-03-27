using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SuiviBoutonVisuel : MonoBehaviour
{
    public Transform cibleVisuel;
    public Vector3 localAxis;
    private Vector3 offset;

    private Transform pokeAttachTransform;
    private XRBaseInteractable interactable;
    private Vector3 posInitialLoc;

    public float reinitVitesse = 5;
    public float angleSuivi;

    private bool estSuivi = false;
    private bool geler = false;
    // Start is called before the first frame update
    void Start()
    {
        posInitialLoc= cibleVisuel.localPosition;

        interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(Suivre);
        interactable.hoverExited.AddListener(Reinitialiser);
        interactable.selectEntered.AddListener(Geler);
        
    }
    public void Suivre(BaseInteractionEventArgs survol) 
    {
       if(survol.interactorObject is XRPokeInteractor)
        {
            XRPokeInteractor interaction = (XRPokeInteractor)survol.interactorObject;
            estSuivi= true;
            geler= false;

            pokeAttachTransform = interaction.attachTransform;
            offset = cibleVisuel.position - pokeAttachTransform.position;

            float pokeAngle = Vector3.Angle(offset, cibleVisuel.TransformDirection(localAxis));

            if(pokeAngle < angleSuivi) 
            {
                estSuivi = true;
                geler = false;
            }
        }
    
    }

    public void Reinitialiser(BaseInteractionEventArgs survol) 
    {
        if(survol.interactorObject is XRPokeInteractor) 
        {
            estSuivi= false;
            geler= false;
        }
    }

    public void Geler(BaseInteractionEventArgs survol)
    {
        if (survol.interactorObject is XRPokeInteractor)
        {
            geler = false;
        }

    }


    // Update is called once per frame
    void Update()
    {
        if(geler) 
            return;
        
        if(estSuivi) 
        {
            Vector3 localTargertPosition = cibleVisuel.InverseTransformPoint(pokeAttachTransform.position + offset);
            Vector3 constrainedLocalTargetPosition = Vector3.Project(localTargertPosition, localAxis);

            cibleVisuel.position = cibleVisuel.TransformPoint(constrainedLocalTargetPosition);
        }
        else
        {
            cibleVisuel.localPosition = Vector3.Lerp(cibleVisuel.localPosition, posInitialLoc, Time.deltaTime * reinitVitesse);

        }
        
    }
}

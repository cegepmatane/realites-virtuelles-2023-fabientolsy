using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SuiviBoutonVisuel : MonoBehaviour
{
    public Transform cibleVisuel;
    public Vector3 localAxis;
    public float vitesseRes = 5;
    public float followAngleTreshold = 45;
    private bool geler = false;

    public GameObject gb;

    private Vector3 initialLocalPos;

    private Vector3 offset;
    private Transform pokeAttachTransform;

    private XRBaseInteractable interactable;
    private bool estSuivi;

    private float positTemp = 1000;
     
    // Start is called before the first frame update
    void Start()
    {
        initialLocalPos = cibleVisuel.localPosition;
        interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(Follow);
        interactable.hoverExited.AddListener(Reinitialiser);
        interactable.selectEntered.AddListener(Geler);

    }

    public void Follow(BaseInteractionEventArgs hover)
    {

        if (hover.interactorObject is XRPokeInteractor)
        {
            XRPokeInteractor interactor = (XRPokeInteractor)hover.interactorObject;


            pokeAttachTransform = interactor.attachTransform;
            offset = cibleVisuel.position - pokeAttachTransform.position;

            float pokeAngle = Vector3.Angle(offset, cibleVisuel.TransformDirection(localAxis));

            if (pokeAngle < followAngleTreshold)
            {
                estSuivi = true;
                geler = false;
            }
        }

       

    }

    public void Reinitialiser(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            estSuivi = false;
            geler = false;

        }
    }

    public void Geler(BaseInteractionEventArgs hover)
    {

        if (hover.interactorObject is XRPokeInteractor)
        {
            geler = true;

        }

    }

    void Update()
    {
        if (geler)
        {
            return;
        }

        if (estSuivi)
        {

            Vector3 localTargertPosition = cibleVisuel.InverseTransformPoint(pokeAttachTransform.position + offset);
            Vector3 constrainedLocalTargetPosition = Vector3.Project(localTargertPosition, localAxis);
            cibleVisuel.position = cibleVisuel.TransformPoint(constrainedLocalTargetPosition);

        }
        else
        {
            cibleVisuel.localPosition = Vector3.Lerp(cibleVisuel.localPosition, initialLocalPos, Time.deltaTime * vitesseRes);
        }


        if(positTemp > cibleVisuel.position.y)
        {
            positTemp = cibleVisuel.position.y;
            Debug.Log(positTemp);
        }

        if(cibleVisuel.position.y <= 0.054)
        {
            Debug.Log("Desactivation");
            gb.SetActive(false);
        }
        
    }

}
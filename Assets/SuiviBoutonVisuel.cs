using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PourVisuelBouton : MonoBehaviour
{
    private XRBaseInteractable interactable;
    private bool estSuivi;
    public Vector3 localAxis; 

    public Transform cibleVisuel;
    public Vector3 offset;
    private Transform pokeAttachTransform;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(Follow);

    }

    public void Follow(BaseInteractionEventArgs hover)
    {

        if (hover.interactorObject is XRPokeInteractor)
        {
            XRPokeInteractor interactor = (XRPokeInteractor)hover.interactorObject;
            estSuivi = true;
            pokeAttachTransform = interactor.attachTransform;
            offset = cibleVisuel.position - pokeAttachTransform.position;
        }

    }
    // Update is called once per frame
    void Update()
    {

        if (estSuivi)
        {

            Vector3 localTargertPosition = cibleVisuel.InverseTransformPoint(pokeAttachTransform.position + offset);
            Vector3 constrainedLocalTargetPosition = Vector3.Project(localTargertPosition,localAxis);

            cibleVisuel.position = cibleVisuel.TransformPoint(constrainedLocalTargetPosition);

        }
    }
}
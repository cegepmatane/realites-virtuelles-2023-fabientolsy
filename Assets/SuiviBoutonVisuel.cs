using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SuiviBoutonVisuel : MonoBehaviour
{
    public Transform cibleVisuel;
    private Vector3 offset;
    private Transform pokeAttachTransform;
    private XRBaseInteractable interactable;
    private bool estSuivi = false;
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(Suivre);
        
    }
    public void Suivre(BaseInteractionEventArgs survol) 
    {
       if(survol.interactorObject is XRPokeInteractor)
        {
            XRPokeInteractor interaction = (XRPokeInteractor)survol.interactorObject;
            estSuivi= true;

            pokeAttachTransform = interaction.attachTransform;
            offset = cibleVisuel.position - pokeAttachTransform.position;
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        if(estSuivi) 
        {
        cibleVisuel.position = pokeAttachTransform.position + offset;
        }
        
    }
}

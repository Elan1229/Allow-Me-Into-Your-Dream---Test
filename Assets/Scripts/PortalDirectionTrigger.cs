using UnityEngine;
using UnityEngine.Events;


public class PortalDirectionTrigger : MonoBehaviour
{
    
    [Header("Target Object to Detect")]
    public GameObject targetObject;

    public ChangeLayer ChangeLayer;

    [Header("Events")]
    public UnityEvent OnEnterFront;
    public UnityEvent OnEnterBack;


    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Collided!");

        Debug.Log($"Check1: Collided with {other.name}, Layer: {other.gameObject.layer}, Enabled: {other.enabled}");


        if (other.gameObject == targetObject)
        {
            Vector3 dir = (other.transform.position - transform.position).normalized;
            float dot = Vector3.Dot(dir, transform.forward);

            if (dot > 0)
            {
                Debug.Log("dot > 0!");
                //OnEnterFront?.Invoke(); // call the event
                ChangeLayer.ChangeRendererLayerMask("StencilThisWorld", "WorldA");
                ChangeLayer.ChangeRendererLayerMask("StencilPortalWorld", "WorldB");
                Debug.Log($"Check2: Collided with {other.name}, Layer: {other.gameObject.layer}, Enabled: {other.enabled}");
            }
            else if (dot < 0)
            {
                Debug.Log("dot<0!");
                ChangeLayer.ChangeRendererLayerMask("StencilThisWorld", "WorldB");
                ChangeLayer.ChangeRendererLayerMask("StencilPortalWorld", "WorldA");
                //OnEnterBack?.Invoke(); // call the event
                Debug.Log($"Check2: Collided with {other.name}, Layer: {other.gameObject.layer}, Enabled: {other.enabled}");
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"Still colliding with {other.name}");
    }


}
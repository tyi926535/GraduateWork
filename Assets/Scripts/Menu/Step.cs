using UnityEngine;
using UnityEngine.EventSystems;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class Step : MonoBehaviour, 
    IPointerEnterHandler,
    IPointerExitHandler
{
    public Transform posit;
    public void OnPointerEnter(PointerEventData eventData)
    {
        posit.position = new Vector3((posit.position.x - 50), (posit.position.y));
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        posit.position = new Vector3((posit.position.x + 50), (posit.position.y));
    }

}

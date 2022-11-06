using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Core
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class BackgroundCell : MonoBehaviour, IPointerClickHandler
    {
        [Inject] MouseInputService _mouseInputService;

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Moving");
            _mouseInputService.TryMoveSelectedBlock();    
        }
    }
}
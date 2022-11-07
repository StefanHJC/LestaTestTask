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
            _mouseInputService.TryMoveSelectedBlock(transform.position);    
        }
    }
}
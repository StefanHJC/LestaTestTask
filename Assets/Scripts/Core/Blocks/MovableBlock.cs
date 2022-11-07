using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Core.Blocks
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class MovableBlock : MonoBehaviour, IBlock, IPointerClickHandler, IPointerEnterHandler
    {
        [Inject] private MouseInputService _mouseHandler;

        private SpriteRenderer _renderer;
        private BlockType _type;

        BlockType IBlock.Type => _type;

        public void Init(BlockType type, Sprite sprite)
        {
            _renderer.sprite = sprite;
            _type = type;
        }

        public void MoveTo(Vector2 position)
        {
            transform.position = position;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _mouseHandler.OnSelectBlock(this);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _mouseHandler.OnFocusBlock(this);
        }

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }
    }
}
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Blocks
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class MovableBlock : MonoBehaviour, IBlock, IPointerClickHandler, IPointerEnterHandler
    {
        private SpriteRenderer _renderer;
        private BlockType _type;

        BlockType IBlock.Type { get => _type; }

        public void Init(BlockType type, Sprite sprite)
        {
            _renderer.sprite = sprite;
            _type = type;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }
    }
}
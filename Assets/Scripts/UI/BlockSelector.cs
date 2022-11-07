using UnityEngine;
using Core.Blocks;

namespace UI
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BlockSelector : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;

        private bool _isFreezed;

        public void Focus(MovableBlock block)
        {
            if (_isFreezed)
                return;

            transform.position = block.transform.position;
            _spriteRenderer.gameObject.SetActive(true);
        }

        public void Select(MovableBlock block)
        {   
            _isFreezed = true;

            transform.SetParent(block.transform);
            transform.position = block.transform.position;
            _spriteRenderer.gameObject.SetActive(true);
        }

        public void Deselect(MovableBlock block) 
        {
            _isFreezed = false;

            transform.parent = null;
            transform.position = block.transform.position;
            _spriteRenderer.gameObject.SetActive(false);
        }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.gameObject.SetActive(false);
        }
    }
}
using UnityEngine;
using Core.Blocks;

[CreateAssetMenu(menuName = "New config", fileName = "Config", order = 51)]
public class Config : ScriptableObject
{
    [Header("Block factories settings")]
    [SerializeField] private Sprite _aBlockSprite;
    [SerializeField] private Sprite _bBlockSprite;
    [SerializeField] private Sprite _cBlockSprite;

    [Space]
    [SerializeField] private MovableBlock _dummyBlock;
    [SerializeField] private GameObject _dummyLabel;

    public Sprite ABlockSprite => _aBlockSprite;
    public Sprite BBlockSprite => _bBlockSprite;
    public Sprite CBlockSprite => _cBlockSprite;

    public MovableBlock DummyBlock => _dummyBlock;
    public GameObject DummyLabel => _dummyLabel;

    private void OnValidate()
    {
        // TODO
    }
}

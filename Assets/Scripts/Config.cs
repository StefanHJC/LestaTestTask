using UnityEngine;
using Core.Blocks;

[CreateAssetMenu(menuName = "New config", fileName = "Config", order = 51)]
public class Config : ScriptableObject
{
    [Header("Block factories settings")]
    [SerializeField] private Sprite _aBlockSprite;
    [SerializeField] private Sprite _bBlockSprite;
    [SerializeField] private Sprite _cBlockSprite;
    [SerializeField] private MovableBlock _dummyBlock;

    [Space]
    [Header("Column label settings")]
    [SerializeField] private Sprite _aBlockColumnLabel;
    [SerializeField] private Sprite _bBlockColumnLabel;
    [SerializeField] private Sprite _cBlockColumnLabel;

    public Sprite ABlockSprite => _aBlockSprite;
    public Sprite BBlockSprite => _bBlockSprite;
    public Sprite CBlockSprite => _cBlockSprite;
    public MovableBlock DummyBlock => _dummyBlock;

    public Sprite ABlockLabel => _aBlockColumnLabel;
    public Sprite BBlockLabel => _bBlockColumnLabel;
    public Sprite CBlockLabel => _cBlockColumnLabel;
}

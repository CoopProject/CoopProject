using Reflex;
using Reflex.Scripts.Attributes;
using TMPro;
using UnityEngine;

public class WoodUpgradePanel : MonoBehaviour
{
    [SerializeField] private HelpersBuilding _helpersBuilding;
    [SerializeField] private TextMeshProUGUI _textLevel;
    [SerializeField] private TextMeshProUGUI _textHelperInstance;
    [SerializeField] private TextMeshProUGUI _textExtraction;
    [SerializeField] private TextMeshProUGUI _textNextCountSpawnHelper;
    [SerializeField] private TextMeshProUGUI _textValumeExtraction;
    [SerializeField] private TextMeshProUGUI _buttonPrice;
    [Range(0, 1)][SerializeField] private float _lvlUpProgres = 0;

    private Player _player;

    private float _levelUpStep = 0.2f;
    
    
    [Inject]
    private void Inject(Container container)
    {
        _player = container.Resolve<Player>();
    }

    private void Start()
    {
        SetStartData();
    }

    private void SetStartData()
    {
        _textLevel.text = $"{_helpersBuilding.Level}";
        _textHelperInstance.text = $"{_helpersBuilding.Counter}";
        _textExtraction.text = $"{0}";
        _textValumeExtraction.text = $"{0}";
        _textNextCountSpawnHelper.text = $"{0}";
        _buttonPrice.text = $"{10}";
    }

    public void LvlUp()
    {
        if (_lvlUpProgres <= 0.7)
        {
            
        }

        _lvlUpProgres += _levelUpStep;
    }
}

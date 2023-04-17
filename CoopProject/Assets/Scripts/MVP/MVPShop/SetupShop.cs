using DefaultNamespace.MVC.MVPShop.Prisenters;
using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;
using UnityEngine;

public class SetupShop : MonoBehaviour
{
    [SerializeField] private ViueUI woodViueUI;
    [SerializeField] private ViueUI _goldView;
    [SerializeField] private ViueUI _stoneView;
    [SerializeField] private ViueUI _ironView;
    [SerializeField] private ViueUI _boardsView;
    [SerializeField] private ViueUI _blocksView;
    [SerializeField] private ViueUI _ironIngotsView;
    [SerializeField] private ViueUI _goldIngotsView;
    [SerializeField] private ViueAllSell _viueAllSell;

    private ResourceCollector _resourceCollector;
    private PlayerWallet _playerWallet;

    private Presenter<Log> _presenterlog;
    private Presenter<Gold> _presenterGold;
    private Presenter<Iron> _prisenterIron;
    private Presenter<Stone> _presenterStone;
    private Presenter<Boards> _presenterBoards;
    private Presenter<StoneBlocks> _presenterStoneBlocks;
    private Presenter<IronIngots> _presenterIronIgnots;
    private Presenter<GoldIngots> _presenterGoldIngots;

    private Model _woodModel = new();
    private Model _goldModel = new();
    private Model _stoneModel = new();
    private Model _ironModel = new();
    private Model _boardsModel = new();
    private Model _ironIgnotsModel = new();
    private Model _goldIgnotsModel = new();
    private Model _stoneBlocksModel = new();

    [Inject]
    private void Inject(Container container)
    {
        _resourceCollector = container.Resolve<ResourceCollector>();
        _playerWallet = container.Resolve<PlayerWallet>();
    }

    private void Start()
    {
        _presenterlog = new Presenter<Log>(_woodModel, woodViueUI, _resourceCollector, _playerWallet, _viueAllSell);
        _presenterGold = new Presenter<Gold>(_goldModel, _goldView, _resourceCollector, _playerWallet, _viueAllSell);
        _prisenterIron = new Presenter<Iron>(_ironModel, _ironView, _resourceCollector, _playerWallet, _viueAllSell);
        _presenterStone =
            new Presenter<Stone>(_stoneModel, _stoneView, _resourceCollector, _playerWallet, _viueAllSell);
        _presenterStoneBlocks = new Presenter<StoneBlocks>(_stoneBlocksModel, _blocksView, _resourceCollector,
            _playerWallet, _viueAllSell);
        _presenterBoards =
            new Presenter<Boards>(_boardsModel, _boardsView, _resourceCollector, _playerWallet, _viueAllSell);
        _presenterIronIgnots = new Presenter<IronIngots>(_ironIgnotsModel, _ironIngotsView, _resourceCollector,
            _playerWallet, _viueAllSell);
        _presenterGoldIngots = new Presenter<GoldIngots>(_goldIgnotsModel, _goldIngotsView, _resourceCollector,
            _playerWallet, _viueAllSell);
    }
}
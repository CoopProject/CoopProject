using DefaultNamespace.MVC.MVPShop.Prisenters;
using DefaultNamespace.MVP.MVPShop.Viues;
using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;
using UnityEngine;

public class StatsSetup : MonoBehaviour
{
    [SerializeField] private StatsView woodViueUI;
    [SerializeField] private StatsView _goldView;
    [SerializeField] private StatsView _stoneView;
    [SerializeField] private StatsView _ironView;
    [SerializeField] private StatsView _boardsView;
    [SerializeField] private StatsView _ironIngotsView;
    [SerializeField] private StatsView _goldIngotsView;

    private ResourceCollector _resourceCollector;

    private PresenterStats<Log> _presenterlog;
    private PresenterStats<Gold> _presenterGold;
    private PresenterStats<Iron> _prisenterIron;
    private PresenterStats<Stone> _presenterStone;
    private PresenterStats<Boards> _presenterBoards;
    private PresenterStats<IronIngots> _presenterIronIgnots;
    private PresenterStats<GoldIngots> _presenterGoldIngots;
    
    private Model _woodModel = new ();
    private Model _goldModel = new ();
    private Model _stoneModel = new ();
    private Model _ironModel = new ();
    private Model _boardsModel = new ();
    private Model _ironIgnotsModel = new ();
    private Model _goldIgnotsModel = new ();

    [Inject]
    private void Inject(Container container)
    {
        _resourceCollector = container.Resolve<ResourceCollector>();
    }

    private void Awake()
    {
        _presenterlog = new PresenterStats<Log>(_woodModel, woodViueUI, _resourceCollector);
        _presenterGold = new PresenterStats<Gold>(_goldModel, _goldView, _resourceCollector);
        _prisenterIron = new PresenterStats<Iron>(_ironModel, _ironView, _resourceCollector);
        _presenterStone = new PresenterStats<Stone>(_stoneModel, _stoneView, _resourceCollector);
        _presenterBoards = new PresenterStats<Boards>(_boardsModel, _boardsView, _resourceCollector);
        _presenterIronIgnots = new PresenterStats<IronIngots>(_ironIgnotsModel, _ironIngotsView, _resourceCollector);
        _presenterGoldIngots = new PresenterStats<GoldIngots>(_goldIgnotsModel, _goldIngotsView, _resourceCollector);
    }
}
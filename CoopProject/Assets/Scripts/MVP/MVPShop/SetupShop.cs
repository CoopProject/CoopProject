using DefaultNamespace.MVC.MVPShop.Prisenters;
using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;
using UnityEngine;


public class SetupShop : MonoBehaviour
{
    [SerializeField] private ViuesUI woodViuesUI;
    [SerializeField] private ViuesUI _goldView;
    [SerializeField] private ViuesUI _stoneView;
    [SerializeField] private ViuesUI _ironView;
    [SerializeField] private ViuesUI _boardsView;
    [SerializeField] private ViuesUI _ironIngotsView;
    [SerializeField] private ViuesUI _goldIngotsView;
   
    private ResourceCollector _resourceCollector;
    
    private Presenter<Log> _presenterlog;
    private Presenter<Gold> _presenterGold;
    private Presenter<Iron> _prisenterIron;
    private Presenter<Stone> _presenterStone;
    private Presenter<Boards> _presenterBoards;
    private Presenter<IronIngots> _presenterIronIgnots;
    private Presenter<GoldIngots> _presenterGoldIngots;
    
    private Model _woodModel = new ();
    private Model _goldModel = new ();
    private Model _stoneModel = new ();
    private Model _ironModel = new ();
    private Model _boardsModel = new ();
    private Model _ironIgnotsModel = new ();
    private Model _goldIgnotsModel = new ();
    
    [Inject]
    private void Inject(Container container) => _resourceCollector = container.Resolve<ResourceCollector>();

    
    private void Awake()
    {
        _presenterlog = new Presenter<Log>(_woodModel, woodViuesUI, _resourceCollector);
        _presenterGold = new Presenter<Gold>(_goldModel, _goldView, _resourceCollector);
        _prisenterIron = new Presenter<Iron>(_ironModel, _ironView, _resourceCollector);
        _presenterStone = new Presenter<Stone>(_stoneModel, _stoneView, _resourceCollector);
        _presenterBoards = new Presenter<Boards>(_boardsModel, _boardsView, _resourceCollector);
        _presenterIronIgnots = new Presenter<IronIngots>(_ironIgnotsModel, _ironIngotsView, _resourceCollector);
        _presenterGoldIngots = new Presenter<GoldIngots>(_goldIgnotsModel, _goldIngotsView, _resourceCollector);
    }
}

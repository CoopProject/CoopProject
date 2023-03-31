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
    [SerializeField] private ViueUI _ironIngotsView;
    [SerializeField] private ViueUI _goldIngotsView;
   
    private ResourceCollector _resourceCollector;
    private Player _player;
    
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
    private void Inject(Container container)
    {
        _resourceCollector = container.Resolve<ResourceCollector>();
        _player = container.Resolve<Player>();
    }

    private void Start()
    {
        _presenterlog = new Presenter<Log>(_woodModel, woodViueUI, _resourceCollector,_player);
        _presenterGold = new Presenter<Gold>(_goldModel, _goldView, _resourceCollector,_player);
        _prisenterIron = new Presenter<Iron>(_ironModel, _ironView, _resourceCollector,_player);
        _presenterStone = new Presenter<Stone>(_stoneModel, _stoneView, _resourceCollector,_player);
        _presenterBoards = new Presenter<Boards>(_boardsModel, _boardsView, _resourceCollector,_player);
        _presenterIronIgnots = new Presenter<IronIngots>(_ironIgnotsModel, _ironIngotsView, _resourceCollector,_player);
        _presenterGoldIngots = new Presenter<GoldIngots>(_goldIgnotsModel, _goldIngotsView, _resourceCollector,_player);
    }
}

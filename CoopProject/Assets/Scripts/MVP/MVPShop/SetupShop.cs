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
    
    private ResourceCollector _resourceCollector;
    
    private Presenter<Log> _presenterlog;
    private Presenter<Gold> _presenterGold;
    private Presenter<Iron> _prisenterIron;
    private Presenter<Stone> _presenterStone;
    
    private Model _woodModel = new ();
    private Model _goldModel = new ();
    private Model _stoneModel = new ();
    private Model _ironModel = new ();
    
    [Inject]
    private void Inject(Container container) => _resourceCollector = container.Resolve<ResourceCollector>();

    
    private void Awake()
    {
        _presenterlog = new Presenter<Log>(_woodModel, woodViuesUI,_resourceCollector);
        _presenterGold = new Presenter<Gold>(_goldModel,_goldView, _resourceCollector);
        _prisenterIron = new Presenter<Iron>(_ironModel, _ironView, _resourceCollector);
        _presenterStone = new Presenter<Stone>(_stoneModel, _stoneView, _resourceCollector);
    }
}

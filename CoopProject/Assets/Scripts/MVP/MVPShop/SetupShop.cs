using DefaultNamespace.MVC.MVPShop.Prisenters;
using Reflex;
using Reflex.Scripts.Attributes;
using UnityEngine;

public class SetupShop : MonoBehaviour
{
    [SerializeField] private LogsView logsView;
    [SerializeField] private GoldView goldView;
    [SerializeField] private StoneView stoneView;
    [SerializeField] private IronView ironView;
    
    private LogsPresenter _presenterLogs;
    private GoldPresenter _presenterGold;
    private StonePrisenter _prisenterStone;
    private IronPresenter _presenterIron;
    
    private LogsModel _logsModel = new ();
    private GoldModel _goldModel = new ();
    private StoneModel _stoneModel = new ();
    private IronModel _ironModel = new ();
    
    private  ResourceCollector _resourceCollector;

    [Inject]
    private void Inject(Container container)
    {
        _resourceCollector = container.Resolve<ResourceCollector>();
    }
    
    private void Start()
    {
        _presenterLogs = new LogsPresenter(_logsModel, logsView,_resourceCollector);
        _presenterGold = new GoldPresenter(_goldModel,goldView,_resourceCollector);
        _prisenterStone = new StonePrisenter(_stoneModel,stoneView,_resourceCollector);
        _presenterIron = new IronPresenter(_ironModel,ironView,_resourceCollector);

    }
}

using System;
using Agava.YandexGames;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace.MVC.MVPShop.Prisenters
{
    public class Presenter<T>
    {
        private Model _model;
        private ViewUI _viewUI;
        private ResourceCollector _resourceCollector;
        private PlayerWallet _playerWallet;
        private  ViewAllSell _viewAllSell;

        public Presenter(Model model,ViewUI viewsUI,ResourceCollector resourceCollector,PlayerWallet playerWallet,ViewAllSell viewAllSell)
        {
            _model = model;
            _viewUI = viewsUI;
            _resourceCollector = resourceCollector;
            _playerWallet = playerWallet;
            _viewAllSell = viewAllSell;

            _viewUI.OnActive += SetStartData;
            _viewUI._buttonSale.onClick.AddListener(ClickButtonViue);
            _viewUI._buttonReward.onClick.AddListener(RewardShow);
            
            _viewAllSell.ButtonSellAll.onClick.AddListener(SellAllResource);
            _viewAllSell.ButtonReward.onClick.AddListener(SellAllResourceReward);
        }
        
        private void SetStartData()
        {
            _model.SetValueCount<T>(_resourceCollector);
            _viewUI.SetCountResource(_model.CountElements);
            _viewUI.SetPriceButton(_model.SumResource);
        }

        private void ClickButtonViue()
        {
            _model.SetCoinPlayer(_playerWallet);
            _model.ClearData<T>(_resourceCollector);
            _model.SetValueCount<T>(_resourceCollector);
            _viewUI.SetCountResource(_model.CountElements);
            _viewUI.SetPriceButton(_model.SumResource);
        }

        private void SellAllResource() => _viewUI._buttonSale.onClick.Invoke();

        private void SellAllResourceReward()
        {
            Debug.Log(_viewAllSell.ResourceSum);
            if (_viewAllSell.ResourceSum > 0)
                _viewUI._buttonReward.onClick.Invoke();
            _viewAllSell.Clear();
        } 
            

        private void RewardShow()
        {
            VideoAd.Show(GamePause.OnGamePauseActive,null,GamePause.OffGamePauseActive);
             ClickButtonRewardViue();
        }
        
        private void ClickButtonRewardViue()
        {
            _model.SetRewardCoinPlayer(_playerWallet);
            _model.ClearData<T>(_resourceCollector);
            _model.SetValueCount<T>(_resourceCollector);
            _viewUI.SetCountResource(_model.CountElements);
            _viewUI.SetPriceButton(_model.SumResource);
        }
    }
}
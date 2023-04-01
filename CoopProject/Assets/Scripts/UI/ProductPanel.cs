using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;
using TMPro;
using UnityEngine;

public abstract class ProductPanel<T> : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _textCount;
   [SerializeField] private TextMeshProUGUI _textEndCount;
   [SerializeField] protected T _resourceType;
   [SerializeField] private int _stack = 10;
   
   private ResourceCollector _resourceCollector;
   private int _counter = 0;
   private int _addResourceCount = 0;
   
   [Inject]
   private void Inject(Container container) => _resourceCollector = container.Resolve<ResourceCollector>();

   private void Start()
   {
      _textCount.text = $"{_counter}";
      _textEndCount.text = $"{_addResourceCount}";
   }

   public void SetCount()
   {
      if (ValiadateAdd())
      {
         _counter++;
         _addResourceCount = _counter;
         _textCount.text = $"{_counter}";
         _textEndCount.text = $"{_addResourceCount}";
      }
   }

   public void SetStackCount()
   {
      int countList = _resourceCollector.GetCountList<Log>();
      
      if (countList > _stack && _counter + _stack <= countList)
      {
         _counter += _stack;
         _addResourceCount = _counter;
         _textCount.text = $"{_counter}";
         _textEndCount.text = $"{_addResourceCount}";
      }
   }

   public void Take()
   {
      if (_counter + _stack <= 0)
      {
         _counter -= _stack;
         _textCount.text = $"{_counter}";
         _addResourceCount = _counter;
         _textEndCount.text = $"{_addResourceCount}";
      }
   }

   public void TakeResource()
   {
      for (int i = 0; i < _addResourceCount;i++)
      {
         var boards = new Boards();
         boards.SetPrice();
         _resourceCollector.AddResource<Boards>(boards);
      }
      Reset();
   }

   private bool ValiadateAdd()
   {
      int countList = _resourceCollector.GetCountList<Log>();
      
      if (_counter < countList)
         return true;

      return false;
   }


   private void Reset()
   {
      _counter = 0;
      _addResourceCount = 0;
      _textCount.text = $"{_counter}";
      _textEndCount.text = $"{_addResourceCount}";
      _resourceCollector.SallResource<Log>();
   }
}

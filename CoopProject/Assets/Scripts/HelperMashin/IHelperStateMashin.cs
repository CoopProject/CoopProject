public interface IHelperStateMashin
{
    public void Enter<T>() where T : IStateHelper;
    public void Exit();
}
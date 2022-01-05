namespace ShowcaseApplication.Core
{
    public interface ILoadable
    {
        Task Load(params object[] parameters);
    }
}

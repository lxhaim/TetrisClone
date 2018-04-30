namespace Assets.Scripts.Core
{
    public interface ISpawner<out T>
    {
        T Spawn();
    }
}

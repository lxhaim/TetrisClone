
namespace Assets.Scripts.Core
{
    public interface IRandomProvider<out T>
    {
        T GetRandom();
    }
}

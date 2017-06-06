using UserModule;

namespace BehaviorModule
{
    public interface PersonIterator
    {
        Person first();
        Person next();
        bool isDone();

        Person currentItem();


    }
}

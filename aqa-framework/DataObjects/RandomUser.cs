using aqaframework.Helpers;

namespace aqaframework.DataObjects;

public class RandomUser: User
{
    public RandomUser()
    {
        email = new RandomString(10).result + "@dot.com";
        password = new RandomString(8).result;
    }
}
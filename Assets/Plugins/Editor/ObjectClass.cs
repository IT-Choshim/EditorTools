
/// <summary>
///  实例化类
///  单例
/// </summary>

public class ObjectClass<T> where T:new () {

    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new T();
            }

            return instance;
        }
    }


}

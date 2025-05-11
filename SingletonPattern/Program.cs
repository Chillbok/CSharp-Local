using System.Runtime.InteropServices;

public class Program
{
    static void Main(string[] args)
    {
        //Singleton 클래스에 있는 Instance() 메서드를 호출해 Singleton 클래스의 인스턴스를 가져온다.
        //objectA, objectB, objectC 세 개의 변수가 모두 동일한 Singleton 인스턴스를 참조하게 된다.
        //싱글턴 패턴의 Instance() 메서드는 인스턴스가 없으면 새로 만들어서 반환하고, 이미 있으면 기존 인스턴스를 반환한다.
        Console.WriteLine("첫 번째 인스턴스 요청");
        var objectA = Singleton.Instance();

        Console.WriteLine("두 번째 인스턴스 요청");
        var objectB = Singleton.Instance(); //이미 인스턴스가 있으므로 메시지 출력 X
        if (objectB == objectA)
            Console.WriteLine("첫 번째 인스턴스와 같음");

        Console.WriteLine("세 번째 인스턴스 요청");
        var objectC = Singleton.Instance(); //이미 인스턴스가 있으므로 메시지 출력 X
        if (objectC == objectA)
            Console.WriteLine("첫 번째 인스턴스와 같음");
    }
}

public class Singleton
{
    //private static 필드
    //클래스 내에서 유일한 인스턴스를 저장할 변수
    //static으로 선언해 클래스가 로드될 때 메모리에 할당됨.
    //클래스의 모든 인스턴스(사실상 하나만 존재)가 공유함.
    private static Singleton? staticSingleton; 

    //public static 메서드
    //외부에서 singleton 인스턴스에 접근하는 유일한 방법
    //public으로 선언해 누구나 접근할 수 있게 하고, static으로 선언해 인스턴스를 생성하지 않고도 클래스 이름으로 바로 호출할 수 있게 한다.
    public static Singleton Instance()
    {
        //인스턴스 생성 확인
        //staticSingleton 변수가 null인지 확인한다.
        //null이면 아직 인스턴스가 생성되지 않은 것이므로, 새로운 인스턴스를 생성한다.
        if (staticSingleton == null)
        {
            staticSingleton = new Singleton();
        }
        //null이 아니면 이미 인스턴스가 존재하므로, 기존 인스턴스를 반환한다.
        return staticSingleton;
    }
}
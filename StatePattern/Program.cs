using System;
using System.Security.Cryptography.X509Certificates;

//상태 인터페이스
public interface IState
{
    void Handle(Context context);
}

//구체적인 상태: 정상 상태
public class NormalState : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("정상 상태임");
    }
}

//구체적인 상태: 공격 상태
public class AttackState : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("공격 상태");
    }
}

//Context 클래스
public class Context
{
    private IState currentState;

    public Context()
    {
        currentState = new NormalState();
    }
    public void SetState(IState state)
    {
        currentState = state;
    }
    public void Request()
    {
        currentState.Handle(this);
    }
}

class Program
{
    static void Main(string[] args)
    {
        //Context 객체 생성
        Console.WriteLine("객체 생성");
        Context context = new Context();
        Console.WriteLine("객체 생성됨");

        //현재 상태 출력
        context.Request();

        //상태 변경
        context.SetState(new AttackState());

        //변경된 상태 출력
        context.Request();
    }
}
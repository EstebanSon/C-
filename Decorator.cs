using System;
using System.Drawing;
using System.Windows.Forms;



namespace MySystem
{   
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();

            d1.SetComponent(c);
            d2.SetComponent(d1);

            d2.Operation();

            Console.ReadKey();

        }
    }

    abstract class Component
    {
        public abstract void Operation();
    }

    class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteComponent Operation");
        }
    }

    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }

        public override void Operation()
        {
            if(component != null)
            {
                component.Operation();
            }
            else
            {
                Console.WriteLine("component null");
            }
        }
    }

    class ConcreteDecoratorA : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("ConcreteDecoratorA.Operation()");
        }
    }

    class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Console.WriteLine("ConcreteDecoratorB.Operation()");
        }

        void AddedBehavior()
        {
        }
    }


    /* 
        Decorator Pattern
        - 객체에 추가적인 요건을 동적으로 추가한다
        - 서브클래스를 만드는것을 통해서 유연하게 확할 수 있는 방법을 제공한다
        - 클래스에 새로운 기능을 추가할때 보통 변수나 메소드들이 추가된다. 그럴때마다 추상 클래스나 해당객체에 소스 변경이 있을 수 밖에 없는데, 이것을 없애서 새로운 기능의 클래스만 추가되고 클라이언트 부분에서 기능만 추가하면 된다.
    */

}

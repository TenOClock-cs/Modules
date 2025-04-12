using System;
namespace Module7
{
    public class A
    {
        public virtual void Display() => Console.WriteLine("A");
    }
    public class B : A
    {
        public new void Display() => Console.WriteLine("B");
    }
    public class C : A
    {
        public override void Display() => Console.WriteLine("C");

    }
    public class D : B
    {
        public new void Display() => Console.WriteLine("D");
    }
    public class E : C
    {
        public new void Display() => Console.WriteLine("E");
    }
}
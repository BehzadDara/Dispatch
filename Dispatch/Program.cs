/*
 What's Dispatching?
    it is a way how the programming language calls a method or a function
 Static Dispatch
    Every method is known at the compile time
 Dynamic Dispatch
    Dynamically dispatched methods are determined at run time based on its parameter’s types
        Single dynamic dispatch use just one parameter to select a method (Satisfy by overriding)
        Multiple dynamic Dispatch can take advantage of as many parameters they want (Satisfy by DLR (Dynamic Language Runtime))
*/

#region Static dispatch
Console.WriteLine("Static dispatch:");
Methods.Print(new Bar());
Methods.Print(new FooBar());
Methods.Print(new FooBar() as IBar);
Console.WriteLine();

#endregion

#region Single dynamic dispatch
Console.WriteLine("Single dynamic dispatch:");
(new Survey() as SurveyBase).DoSurvey();
Console.WriteLine();
#endregion

#region Multiple dynamic dispatch
Console.WriteLine("Multiple dynamic dispatch:");
var bar = new Bar();
var foo = new FooBar();
IBar ibar = new FooBar();
IBar[] items = { bar, foo, ibar };

Console.WriteLine("Regular:");
foreach (var item in items)
{
    Methods.Print(item);
}
Console.WriteLine("Dynamic:");
foreach (dynamic item in items)
{
    Methods.Print(item);
}
#endregion

#region Classes
static class Methods
{
    public static void Print(IBar item) { Console.WriteLine("It is an IBar."); }
    public static void Print(Bar item) { Console.WriteLine("It is a Bar."); }
    public static void Print(FooBar item) { Console.WriteLine("It is a FooBar."); }
}
interface IBar { }
class Bar : IBar { }
sealed class FooBar : Bar { }

class SurveyBase { public virtual void DoSurvey() => Console.WriteLine("SurveyBase.DoSurvey"); }
class Survey : SurveyBase { public override void DoSurvey() => Console.WriteLine("Survey.DoSurvey"); }
#endregion
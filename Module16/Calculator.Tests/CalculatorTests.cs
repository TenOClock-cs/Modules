namespace Calculator.Tests;

using global::Calculator;

[TestFixture]
public class Tests
{

    private Calculator calc = new Calculator();
    
    [Test]
    public void Additional_MustReturnCorrectValue()
    {
        
        Assert.That(calc.Additional(3, 5), Is.EqualTo(8));
        
    }
    [Test]
    public void Division_MustReturnCorrectValue()
    {
        
        Assert.That(calc.Division(4, 2), Is.EqualTo(2));
    }
    
    [Test]
    public void Division_MustThrowException()
    {
        
        Assert.Throws<DivideByZeroException>(() => calc.Division(4, 0));
    }
    
    [Test]
    public void Multiply_MustReturnCorrectValue()
    {
        
        Assert.That(calc.Multiply(4, 2), Is.EqualTo(8));
    }

    [Test]
    public void Subtraction_MustReturnCorrectValue()
    {
        
        Assert.That(calc.Subtraction(5, 2), Is.EqualTo(3));
    }
}
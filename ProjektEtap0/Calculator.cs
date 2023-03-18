namespace ProjektEtap0
{
    public class Calculator
    {
        public int add(int x, int y)
        {
            return x + y;
        }

        public int subtract(int x, int y) 
        {
            return x - y; 
        }

        public int multiply(int x, int y)
        {
            return x * y;
        }
        public double divide(double x, double y)
        {
            if (y == 0)
                throw new DivideByZeroException();
            
            return x / y;
        }
    }
}
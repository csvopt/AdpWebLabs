using AdpWebLabs.Domain.Domain.Entities.Base;
using AdpWebLabs.Domain.Domain.Enums;

namespace AdpWebLabs.Domain.Domain.Entities
{
    public class Calculator : Entity
    {
        private double _result;

        public Calculator() {}

        public Calculator(double left, double right, Operation operation)
        {
            this.Left = left;
            this.Right = right;
            this.Operation = operation;
        }

        public double Left { get; private set; }
        public double Right { get; private set; }
        public Operation Operation { get; private set; }
        public double Result
        {
            get { return Calculate(Operation); }
            private set => _result = value;
        }

        private double Calculate(Operation operation)
        {
            return operation switch
            {
                Operation.ADDITION => _result = Left + Right,
                Operation.DIVISION => _result = Left / Right,
                Operation.MULTIPLICATION => _result = Left * Right,
                Operation.SUBTRACTION => _result = Left - Right,
                Operation.REMAINDER => _result = Left % Right,
                _ => _result,
            };
        }
    }
}

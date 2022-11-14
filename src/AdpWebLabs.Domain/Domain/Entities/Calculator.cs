using AdpWebLabs.Domain.Domain.Enums;

namespace AdpWebLabs.Domain.Domain.Entities
{
    public class Calculator
    {
        private readonly double _left;
        private readonly double _right;
        private readonly Operation _operation;
        private double _result;

        public Calculator(double left, double right, Operation operation)
        {
            this._left = left;
            this._right = right;
            this._operation = operation;
        }

        public double Result
        {
            get { return Calculate(_operation); }
            private set { _result = value; }
        }

        private double Calculate(Operation operation)
        {
            return operation switch
            {
                Operation.ADDITION => _result = _left + _right,
                Operation.DIVISION => _result = _left / _right,
                Operation.MULTIPLICATION => _result = _left * _right,
                Operation.SUBTRACTION => _result = _left - _right,
                Operation.REMAINDER => _result = _left % _right,
                _ => _result,
            };
        }
    }
}

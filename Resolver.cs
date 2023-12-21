using System;

namespace Calculator
{
    class Resolver
    {
        private decimal entry = 0;
        private decimal memory = 0;
        private string operation = null;

        public bool IsOperated
        {
            get {
                if (operation != null)
                {
                    return true;
                }
                return false;
            }
        }

        public void Input(decimal entry)
        {
            this.entry = entry;
        }

        public decimal Operate(string operation)
        {
            Resolve();
            memory = entry;
            this.operation = operation;
            return entry;
        }

        public decimal Resolve()
        {
            switch (operation)
            {
                case "+":
                    entry = memory + entry;
                    break;
                case "-":
                    entry = memory - entry;
                    break;
                case "x":
                    entry = memory * entry;
                    break;
                case "÷":
                    entry = memory / entry;
                    break;
                default:
                    break;
            }

            operation = null;
            return entry;
        }

        public void Clear()
        {
            entry = 0;
            memory = 0;
            operation = null;
        }
    }
}
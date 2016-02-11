using System;
using Hermes.Internal.Contracts;

// Internal Interface member implementation: https://msdn.microsoft.com/en-us/library/ms173121.aspx

namespace Hermes.Internal.Engine
{
    internal class EngineExecutionContext :
        IEngineExecutionContext
    {
        private bool _started = false;

        public void Initialize(
            Action work
            )
        {
            if (!_started)
            {
                work();
            }

            _started = true;
        }

        public void Execute(
            Action work
            )
        {
            if (_started)
            {
                work();
                return;
            }

            throw new Exception("Hermes Engine is not started");
        }
    }
}

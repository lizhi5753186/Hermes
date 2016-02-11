using System;

namespace Hermes.Internal.Engine
{
    internal interface IEngineExecutionContext
    {
        void Initialize(Action work);
        void Execute(Action work);
    }

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

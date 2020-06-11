using System;

namespace solidarity_bond
{
    class ConnectionExecutionEngine
    {
        private ConnectionComponent connectionComponent;
        public ConnectionExecutionEngine()
        {
            connectionComponent = new ConnectionComponent();
        }

        public STR_MSG Connection(STR_MSG str_msg)
        {
            return connectionComponent.Connection(str_msg);;
        }
    }
}

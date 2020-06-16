using System;
using System.Data;

namespace solidarity_bond
{
    class StockExecutionEngine
    {
        private StockComponent stockComponent;
        public StockExecutionEngine()
        {
            stockComponent = new StockComponent();
        }

        public STR_MSG Get_stock(STR_MSG str_msg)
        {
            str_msg = stockComponent.Get_stock(str_msg);
            return str_msg;
        }
        public STR_MSG Update_stock(STR_MSG str_msg)
        {
            return stockComponent.Update_stock(str_msg);;
        }
    }
}

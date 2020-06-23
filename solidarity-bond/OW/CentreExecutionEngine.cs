namespace solidarity_bond
{
    public class CentreExecutionEngine
    {
        private CentreComponenent centreComponenent;
        public CentreExecutionEngine()
        {
            centreComponenent = new CentreComponenent();
        }

        public STR_MSG Get_centre(STR_MSG str_msg)
        {
            return centreComponenent.Get_centre(str_msg);;
        }
    }
}
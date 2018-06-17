namespace EpamTechnicalExercise.Model.FundModel
{
    public class FundFactory : IFundFactory
    {
        public IFund GetFund()
        {
            return new Fund();
        }
    }
}
